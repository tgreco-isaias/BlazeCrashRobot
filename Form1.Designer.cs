namespace BlazeCrashRobot
{
	partial class Form1
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnIniciarRoboMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.lbSequencia = new System.Windows.Forms.Label();
            this.lbEntradas = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nrValorCashOut = new System.Windows.Forms.NumericUpDown();
            this.lbWinWallet = new System.Windows.Forms.Label();
            this.lbLoss = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nrStopLoss = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nrValorAposta = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nrCrashMonitorado = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nrSequencia = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbCrash = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrValorCashOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrStopLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrValorAposta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrCrashMonitorado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSequencia)).BeginInit();
            this.SuspendLayout();
            // 
            // webView2
            // 
            this.webView2.AllowExternalDrop = true;
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2.Location = new System.Drawing.Point(0, 30);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(1048, 625);
            this.webView2.TabIndex = 0;
            this.webView2.ZoomFactor = 1D;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIniciarRoboMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnIniciarRoboMenuItem
            // 
            this.btnIniciarRoboMenuItem.Name = "btnIniciarRoboMenuItem";
            this.btnIniciarRoboMenuItem.Size = new System.Drawing.Size(103, 24);
            this.btnIniciarRoboMenuItem.Text = "Iniciar Robô";
            this.btnIniciarRoboMenuItem.Click += new System.EventHandler(this.IniciarRoboMenuItem_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lbSequencia);
            this.panel.Controls.Add(this.lbEntradas);
            this.panel.Controls.Add(this.label7);
            this.panel.Controls.Add(this.nrValorCashOut);
            this.panel.Controls.Add(this.lbWinWallet);
            this.panel.Controls.Add(this.lbLoss);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.nrStopLoss);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.nrValorAposta);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.nrCrashMonitorado);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.nrSequencia);
            this.panel.Controls.Add(this.checkBox1);
            this.panel.Controls.Add(this.listView1);
            this.panel.Controls.Add(this.lbCrash);
            this.panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel.Location = new System.Drawing.Point(0, 30);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(372, 625);
            this.panel.TabIndex = 2;
            this.panel.Visible = false;
            // 
            // lbSequencia
            // 
            this.lbSequencia.AutoSize = true;
            this.lbSequencia.Location = new System.Drawing.Point(241, 126);
            this.lbSequencia.Name = "lbSequencia";
            this.lbSequencia.Size = new System.Drawing.Size(75, 16);
            this.lbSequencia.TabIndex = 16;
            this.lbSequencia.Text = "Sequência:";
            // 
            // lbEntradas
            // 
            this.lbEntradas.AutoSize = true;
            this.lbEntradas.Location = new System.Drawing.Point(206, 328);
            this.lbEntradas.Name = "lbEntradas";
            this.lbEntradas.Size = new System.Drawing.Size(64, 16);
            this.lbEntradas.TabIndex = 15;
            this.lbEntradas.Text = "Entradas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Auto Cashout em:";
            // 
            // nrValorCashOut
            // 
            this.nrValorCashOut.DecimalPlaces = 2;
            this.nrValorCashOut.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nrValorCashOut.Location = new System.Drawing.Point(194, 235);
            this.nrValorCashOut.Name = "nrValorCashOut";
            this.nrValorCashOut.Size = new System.Drawing.Size(154, 22);
            this.nrValorCashOut.TabIndex = 13;
            this.nrValorCashOut.Value = new decimal(new int[] {
            113,
            0,
            0,
            131072});
            // 
            // lbWinWallet
            // 
            this.lbWinWallet.AutoSize = true;
            this.lbWinWallet.Location = new System.Drawing.Point(169, 356);
            this.lbWinWallet.Name = "lbWinWallet";
            this.lbWinWallet.Size = new System.Drawing.Size(67, 16);
            this.lbWinWallet.TabIndex = 12;
            this.lbWinWallet.Text = "Win Count";
            // 
            // lbLoss
            // 
            this.lbLoss.AutoSize = true;
            this.lbLoss.Location = new System.Drawing.Point(13, 356);
            this.lbLoss.Name = "lbLoss";
            this.lbLoss.Size = new System.Drawing.Size(73, 16);
            this.lbLoss.TabIndex = 11;
            this.lbLoss.Text = "Loss Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stop Loss";
            // 
            // nrStopLoss
            // 
            this.nrStopLoss.Location = new System.Drawing.Point(16, 311);
            this.nrStopLoss.Name = "nrStopLoss";
            this.nrStopLoss.Size = new System.Drawing.Size(85, 22);
            this.nrStopLoss.TabIndex = 9;
            this.nrStopLoss.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valor da aposta";
            // 
            // nrValorAposta
            // 
            this.nrValorAposta.DecimalPlaces = 2;
            this.nrValorAposta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nrValorAposta.Location = new System.Drawing.Point(16, 235);
            this.nrValorAposta.Name = "nrValorAposta";
            this.nrValorAposta.Size = new System.Drawing.Size(154, 22);
            this.nrValorAposta.TabIndex = 7;
            this.nrValorAposta.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Valor Monitorado:";
            // 
            // nrCrashMonitorado
            // 
            this.nrCrashMonitorado.DecimalPlaces = 2;
            this.nrCrashMonitorado.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nrCrashMonitorado.Location = new System.Drawing.Point(16, 176);
            this.nrCrashMonitorado.Name = "nrCrashMonitorado";
            this.nrCrashMonitorado.Size = new System.Drawing.Size(154, 22);
            this.nrCrashMonitorado.TabIndex = 5;
            this.nrCrashMonitorado.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sequência saindo abaixo do valor monitorado";
            // 
            // nrSequencia
            // 
            this.nrSequencia.Location = new System.Drawing.Point(13, 120);
            this.nrSequencia.Name = "nrSequencia";
            this.nrSequencia.Size = new System.Drawing.Size(212, 22);
            this.nrSequencia.TabIndex = 3;
            this.nrSequencia.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(15, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Aguardando Aposta";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 383);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(372, 242);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CrashPoint";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CreatedAt";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // lbCrash
            // 
            this.lbCrash.AutoSize = true;
            this.lbCrash.Location = new System.Drawing.Point(12, 11);
            this.lbCrash.Name = "lbCrash";
            this.lbCrash.Size = new System.Drawing.Size(45, 16);
            this.lbCrash.TabIndex = 0;
            this.lbCrash.Text = "Crash:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 655);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.webView2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrValorCashOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrStopLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrValorAposta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrCrashMonitorado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSequencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem btnIniciarRoboMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lbCrash;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown nrCrashMonitorado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nrSequencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nrValorAposta;
        private System.Windows.Forms.Label lbWinWallet;
        private System.Windows.Forms.Label lbLoss;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nrStopLoss;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nrValorCashOut;
        private System.Windows.Forms.Label lbEntradas;
        private System.Windows.Forms.Label lbSequencia;
    }
}

