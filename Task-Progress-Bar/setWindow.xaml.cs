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
using System.Windows.Shapes;

namespace Task_Progress_Bar
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class setWindow : Window
    {
        public setWindow()
        {
            InitializeComponent();
        }

        private void SetWinLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_se1_KeyDown(object sender, KeyEventArgs e)
        {
            //TextBox txt = sender as TextBox;
            MyKeyDown(textBox_se1,e)
        }
        private void MyKeyDown(TextBox sender,KeyEventArgs e)
        {
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void TextBox_se1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_se1);
        }
        private void TextBox_se2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void TextBox_se2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_se2);
        }

        private void TextBox_mi1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void TextBox_mi1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_mi1);
        }

        //限制最大数值
        private void Xianzhi(TextBox sender) {
            try
            {
                string strNum = sender.Text;
                if ("" == strNum || null == strNum)
                {
                    return;
                }
                int num = int.Parse(sender.Text);
                sender.Text = num.ToString();
                if (num <= 9999)
                {
                    return;
                }
                else
                {
                    //sender.Text = "";
                    sender.Text = sender.Text.Remove(2);
                    sender.SelectionStart = sender.Text.Length;
                }
            }
            catch
            {
                sender.Text = "";
            }
        }

    }
}
