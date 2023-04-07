using BlazeRobot;
using BlazeRobot.Result;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BlazeRobot.Result.RoundEnterResult;

namespace BlazeCrashRobot
{
    public partial class Form1 : Form
    {
        private BlazeClient _client;

        private WalletResult.CarteiraModel _wallet { get; set; }

        private GetCurrentUserResult.CurrentUserModel _currentUser { get; set; }

        private double _currentCrashy { get; set; }

        private bool _waitingBet { get; set; }
        private DateTime _lastRefreshHistory { get; set; }

        private List<HistoryResult.Record> _historico { get; set; }

        private List<RoundEnterResultModel> _entradas { get; set; }

        private double winWallet { get; set; }

        private double louse { get; set; }

        private double apostado { get; set; }


        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            Init();
        }

        private async void Init()
        {

            var cacheFolderPath = Path.Combine(Environment.CurrentDirectory, "Cache");

            //var options = new CoreWebView2EnvironmentOptions("--allow-file-access-from-files");

            var environment = await CoreWebView2Environment.CreateAsync(null, cacheFolderPath, null);

            await webView2.EnsureCoreWebView2Async(environment);

            webView2.CoreWebView2.Navigate("https://blaze.com/pt/games/crash");

            _entradas = new List<RoundEnterResultModel>();

            //webView2.NavigationCompleted += WebView2_NavigationCompleted;
        }

        private void WebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //var url = ((WebView2)sender).Source;

            ////var acessToken = webView2.ExecutarScript("localStorage.ACCESS_TOKEN");

            webView2.GetLocalStorage();
        }

        private void IniciarRoboMenuItem_Click(object sender, EventArgs e)
        {
            var gameCrash = webView2.ExecutarScript("document.getElementById('crash').innerText");

            if (gameCrash == null)
            {
                MessageBox.Show("O Game Crash não foi identificado, verifique se você está na página do jogo e tente novamente");
                return;
            }

            var localStorage = webView2.GetLocalStorage();

            if (!localStorage.ContainsKey("ACCESS_TOKEN"))
            {
                MessageBox.Show("Para iniciar o robô, por favor faça login no blaze.");
                return;
            }

            _client = new BlazeClient(localStorage["ACCESS_TOKEN"]);

            var currentUserResponse = _client.Users.GetCurrentUser();

            if (!currentUserResponse.ProcessOK)
            {
                MessageBox.Show("Ocorreu um problema ao identificar usuário.");
                return;
            }

            _currentUser = currentUserResponse.CurrentUser;

            var walletResult = _client.Wallets.GetWallet();

            if (!walletResult.ProcessOK || walletResult.Carteiras.Count == 0)
            {
                MessageBox.Show("Ocorreu um problema ao consultar sua carteira, por favor tente novamente.");
                return;
            }

            _wallet = walletResult.Carteiras[0];

            //webView2.Enabled = false;
            menuStrip1.Visible = false;
            panel.Visible = true;

            MessageBox.Show($"Seja bem vindo {_currentUser.Username} {_currentUser.Email}! O robô está ativo!");

            //Monitorar momento de apostar usando a propriedade crash_y do console que indica o odd atual do game.
            //Se for igual a "1", significa que o jogo está parado aguardando apostas.
            //Se for maior que 1, exemplo 1.0 - 1.01, 1.2, 1.3 etc. significa que o jogo já está em andamento

            var timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_CrashY;
            timer.Start();


            //var carteira = _client.Wallets.GetWallet().Carteiras.First();

            //var apostaResult = _client.Round.Entrar(new BlazeRobot.Request.RoundRequestModel()
            //{
            //    Amount = 0.12,
            //    Type = carteira.Currency.Type,
            //    WalletId = carteira.Id,
            //    AutoCashoutAt = 1.80
            //});

            //var user = blazeClient.Users.GetCurrentUser();
        }

        bool _apostado = false;

        private void Timer_CrashY(object sender, EventArgs e)
        {
            var crashy = webView2.GetCrashY();

            lbCrash.Text = "Crash: " + crashy.ToString();

            if (crashy == 1)
            {
                SetWaitingBet(true);
                CheckSinal();
            }
            else
            {
                SetWaitingBet(false);
            }

            //if (crashy == 1 && _currentCrashy != 1)
            //{
            //    FinishGame();
            //}

            var tempoUltimoRefresh = DateTime.Now - _lastRefreshHistory;

            if (tempoUltimoRefresh.TotalSeconds > 7 && _waitingBet == false && crashy == _currentCrashy)
            {
                _lastRefreshHistory = DateTime.Now;

                if(apostado > 0)
                {
                    if(crashy >= Convert.ToDouble(nrValorCashOut.Value))
                    {
                        var lucro = (apostado * Convert.ToDouble(nrValorCashOut.Value));

                        winWallet += lucro;
                    }

                    apostado = 0;

                    lbWinWallet.Text = $"RobotWallet: {winWallet}";

                }

                FinishGame();
            }

            _currentCrashy = crashy;
        }

        public void FinishGame()
        {
            UpdateHistory();

            _apostado = false;
        }

        private void CheckSinal()
        {
            if (_apostado)
                return;

            RoundEnterResult apostaResult = Apostar();
        }


        private void CheckSinal___()
        {
            if (_historico == null)
                return;

            if (_apostado)
                return;

            var sequencia = _historico.TakeWhile(r => r.CrashPoint <= nrCrashMonitorado.Value).Count();

            lbSequencia.Text = "Sequência: " + sequencia;

            if (sequencia < nrSequencia.Value)
            {
                return;
            }

            var bets = _client.UserHistory.GetHistory();

            if (!bets.ProcessOK)
                return;

            var loss = bets.History.Records.TakeWhile(r => r.Status == "loss");

            lbLoss.Text = "Loss Count: " + loss.Count();

            var totalLoss = bets.History.Records.Where(r => r.Status == "loss").Sum(r => r.Amount);
            var totalWin = bets.History.Records.Where(r => r.Status != "loss").Sum(r => r.Amount);

            Text = $"Win Money: {totalWin} / Loss Money: {totalLoss}: ";


            if (loss.Count() < nrStopLoss.Value)
            {
                RoundEnterResult apostaResult = Apostar();

                if (apostaResult.ProcessOK)
                {
                    _entradas.Add(apostaResult.Model);
                    lbEntradas.Text = $"Entradas: {_entradas.Count}";
                }
            }
        }

        private RoundEnterResult Apostar()
        {
            var entradaResult = _client.Round.Entrar(new BlazeRobot.Request.RoundRequestModel()
            {
                Amount = Convert.ToDouble(nrValorAposta.Value),
                Type = _wallet.Currency.Type,
                WalletId = _wallet.Id,
                AutoCashoutAt = Convert.ToDouble(nrValorCashOut.Value)
            });

            if (entradaResult.ProcessOK)
            {
                _apostado = true;

                apostado = Convert.ToDouble(nrValorAposta.Value);
                winWallet -= apostado;
                lbWinWallet.Text = $"RobotWallet: {winWallet}";

            }

            return entradaResult;
        }

        private void UpdateHistory()
        {
            var historicoResult = _client.History.GetHistory();

            if (!historicoResult.ProcessOK)
                return;

            _historico = historicoResult.History.Records;

            listView1.Items.Clear();
            listView1.Items.AddRange(historicoResult.History.Records.Select(p => new ListViewItem(new[] { p.Id, p.CrashPoint.ToString(), p.CreatedAt.ToString() })).ToArray());
        }

        private void SetWaitingBet(bool waiting)
        {
            _waitingBet = waiting;
            checkBox1.Checked = waiting;
        }
    }
}
