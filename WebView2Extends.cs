using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazeCrashRobot
{
	public static class WebView2Extends
	{
		public static string ExecutarScript(this WebView2 webview, string script)
		{
			var task = webview.ExecuteScriptAsync(script);

			while (!task.IsCompleted)
				Application.DoEvents();

			return JsonConvert.DeserializeObject<string>(task.Result);
		}

		public static Dictionary<string, string> GetLocalStorage(this WebView2 webView)
		{
			string json = webView.ExecutarScript("JSON.stringify(localStorage)");

			return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		}

		public static Dictionary<string, string> GetSessionStorage(this WebView2 webView)
		{
			string json = webView.ExecutarScript("JSON.stringify(sessionStorage)");

			return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		}

		public static Dictionary<string, string> GetCookies(this WebView2 webView)
		{
			//obtém cookies
			var json = webView.ExecutarScript("JSON.stringify(document.cookie.split(\";\").reduce( (ac, cv, i) => Object.assign(ac, {[cv.split('=')[0]]: cv.split('=')[1]}), {}))");

			return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		}


	}
}
