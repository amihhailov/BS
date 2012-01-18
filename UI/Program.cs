using System;
using System.Threading;
using System.Windows.Forms;

namespace UI {
	internal static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ThreadException += Application_ThreadException;
			Application.Run(new frmMain());
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			MessageBox.Show(e.Exception.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}