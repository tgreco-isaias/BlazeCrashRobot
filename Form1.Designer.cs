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
			this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// webView2
			// 
			this.webView2.AllowExternalDrop = true;
			this.webView2.CreationProperties = null;
			this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
			this.webView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webView2.Location = new System.Drawing.Point(0, 28);
			this.webView2.Name = "webView2";
			this.webView2.Size = new System.Drawing.Size(919, 497);
			this.webView2.TabIndex = 0;
			this.webView2.ZoomFactor = 1D;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(919, 28);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// testeToolStripMenuItem
			// 
			this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
			this.testeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.testeToolStripMenuItem.Text = "Teste";
			this.testeToolStripMenuItem.Click += new System.EventHandler(this.testeToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(919, 525);
			this.Controls.Add(this.webView2);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
	}
}

