using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Timers;

namespace Task_Progress_Bar
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Timers.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
            {
                if (myProBar.Value < myProBar.Maximum)
                {
                    myProBar.Value += 1;
                }
                else
                {
                    timer.Stop();
                }
            }));
        }
        private void TMwindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            double wWidth = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            double wHeight = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            TMwindow.Width = wWidth;
            TMwindow.Top = wHeight - 10;
            TMwindow.Left = 0;
            myGrid.Width = wWidth;
            myProBar.Width = wWidth;
            //myProBar.Maximum = wWidth;
            //double ti = 60000 / wWidth;
            //timer = new System.Timers.Timer(ti);
            timer = new System.Timers.Timer(250);
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Start();
            InitNotifyIcon();
        }
        private void InitNotifyIcon()
        {
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.notifyIcon.Visible = true;
            this.notifyIcon.Text = "单击设置";
            this.notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            //打开菜单项
            System.Windows.Forms.MenuItem open = new System.Windows.Forms.MenuItem("设置");
            open.Click += new EventHandler(Show);
            //退出菜单项
            System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("退出");
            exit.Click += new EventHandler(Close);
            //关联托盘控件
            System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] { open, exit };
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler((o, e) =>
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left) this.Show(o, e);
            });
        }
        private void Show(object sender, EventArgs e)
        {
            //this.Visibility = System.Windows.Visibility.Visible;
            //this.ShowInTaskbar = true;
            //this.Activate();
            setWindow fm2 = new setWindow();
            fm2.ProBarVal += Fm2_ProBarVal;
            fm2.ShowDialog();
        }
        //private void Hide(object sender, EventArgs e)
        //{
        //    this.ShowInTaskbar = false;
        //    this.Visibility = System.Windows.Visibility.Hidden;
        //}
        private void Close(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            System.Windows.Application.Current.Shutdown();
        }

        void Fm2_ProBarVal(double a)
        {
            timer.Stop();
            myProBar.Value = 0;
            double ti = a*1000 / myProBar.Width;
            if (ti<=250)
            {
                ti = 250;
                myProBar.Maximum = a*4;
            }
            else
            {
                myProBar.Maximum = myProBar.Width;
            }
            //System.Windows.MessageBox.Show(ti.ToString());
            timer.Interval = ti;
            timer.Start();
        }

        private void TMwindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.notifyIcon.Visible = false;
        }
    }
}
