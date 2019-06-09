using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lierda.WPFHelper;

namespace Task_Progress_Bar
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        LierdaCracker cracker = new LierdaCracker();//【回收内存】
        public EventWaitHandle ProgramStarted { get; set; }//只允许运行一个程序
        protected override void OnStartup(StartupEventArgs e)
        {
            cracker.Cracker();//【回收内存】可输入垃圾回收间隔时间，默认30s
            base.OnStartup(e);//【回收内存】

            //只允许运行一个程序
            bool createNew;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "MyTctiApp", out createNew);
            if (!createNew)
            {
                //MessageBox.Show("already run");
                App.Current.Shutdown();
                Environment.Exit(0);
            }
            base.OnStartup(e);
            //------------------------------------
        }

    }
}
