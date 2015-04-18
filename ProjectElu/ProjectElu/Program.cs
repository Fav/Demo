using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectElu
{
    static class Program
    {
        /// <summary>
        /// log4net记录日志
        /// </summary>
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // 处理UI线程异常
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // 处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog()!= DialogResult.OK)
            {
                return;
            }

            Application.Run(new FrmMain());
        }

        #region 处理未捕获异常的挂钩函数
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception error = e.Exception as Exception;
            string message = string.Empty;

            if (error != null)
            {
                message = string.Format("出现应用程序未处理的异常\r\n异常类型：{0}\r\n异常消息：{1}\r\n异常位置：{2}\r\n", error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                message = string.Format("Application ThreadError:{0}", e);
            }

            log.Error(message);
            Console.WriteLine(message);

            // Application.Restart();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = e.ExceptionObject as Exception;
            string message = string.Empty;

            if (error != null)
            {
                message = string.Format("Application UnhandledException:{0};\r\n堆栈信息:{1}", error.Message, error.StackTrace);
            }
            else
            {
                message = string.Format("Application UnhandledError:{0}", e);
            }

            log.Error(message);
            Console.WriteLine(message);

            // Application.Restart();
        }
        #endregion
    }
}
