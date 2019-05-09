using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
        //以下是回收内存方法：
        //打开【工具】-【NuGet包管理器】-【程序包管理器控制台】
        //输入以下：Install-Package Lierda.WPFHelper
        //完成，关掉。
        //用下面这段代码，搞定
        //---------------------------------
        LierdaCracker cracker = new LierdaCracker();
        protected override void OnStartup(StartupEventArgs e)
        {
            cracker.Cracker();//可输入垃圾回收间隔时间，默认30s
            base.OnStartup(e);
        }
        //------------------------------------
    }
}
