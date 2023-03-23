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
			var localStorage = webView2.GetLocalStorage();
			var sessionStorage = webView2.GetSessionStorage();
			var cookies = webView2.GetCookies();
		}
	}
}
