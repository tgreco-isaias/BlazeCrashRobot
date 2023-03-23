using BlazeRobot;
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

namespace BlazeCrashRobot
{
    public partial class Form1 : Form
    {

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

            //webView2.NavigationCompleted += WebView2_NavigationCompleted;
        }

        private void WebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //var url = ((WebView2)sender).Source;

            ////var acessToken = webView2.ExecutarScript("localStorage.ACCESS_TOKEN");

            webView2.GetLocalStorage();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Monitorar momento de apostar usando a propriedade crash_y do console que indica o odd atual do game.
            //Se for igual a "1", significa que o jogo está parado aguardando apostas.
            //Se for maior que 1, exemplo 1.0 - 1.01, 1.2, 1.3 etc. significa que o jogo já está em andamento


            var localStorage = webView2.GetLocalStorage();
            var sessionStorage = webView2.GetSessionStorage();
            var cookies = webView2.GetCookies();

            var blazeClient = new BlazeClient(localStorage["ACCESS_TOKEN"]);

            var carteira = blazeClient.Wallets.GetWallet().Carteiras.First();

            var apostaResult = blazeClient.Round.Entrar(new BlazeRobot.Request.RoundRequestModel()
            {
                Amount = 0.12,
                Type = carteira.Currency.Type,
                WalletId = carteira.Id,
                AutoCashoutAt = 1.80
            });

            //var user = blazeClient.Users.GetCurrentUser();
        }
    }
}
