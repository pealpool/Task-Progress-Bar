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
            if (radioButton1.IsChecked == true)
            {
                radioButton1.IsChecked = true;
                textBox_ho1.IsEnabled = true;
                textBox_mi1.IsEnabled = true;
                textBox_se1.IsEnabled = true;
                textBox_ho2.IsEnabled = false;
                textBox_mi2.IsEnabled = false;
                textBox_se2.IsEnabled = false;
            }
        }

        private void TextBox_se1_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_se1, e);
        }
        
        private void TextBox_se1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_se1);
        }
        private void TextBox_se2_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_se2, e);
        }
        private void TextBox_se2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_se2);
        }
        private void TextBox_mi1_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_mi1, e);
        }
        private void TextBox_mi1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_mi1);
        }
        private void TextBox_mi2_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_mi2, e);
        }
        private void TextBox_mi2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_mi2);
        }
        private void TextBox_ho1_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_ho1, e);
        }
        private void TextBox_ho1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_ho1);
        }
        private void TextBox_ho2_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_ho2, e);
        }
        private void TextBox_ho2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi(textBox_ho2);
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
        private void MyKeyDown(TextBox sender, KeyEventArgs e)
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            setWin.Close();
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked == true)
            {
                //radioButton1.IsChecked = true;
                textBox_ho1.IsEnabled = true;
                textBox_mi1.IsEnabled = true;
                textBox_se1.IsEnabled = true;
                textBox_ho2.IsEnabled = false;
                textBox_mi2.IsEnabled = false;
                textBox_se2.IsEnabled = false;
            }
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            //if (radioButton2.IsChecked == true)
            //{
            //    //radioButton2.IsChecked = true;
            //    textBox_ho2.IsEnabled = true;
            //    textBox_mi2.IsEnabled = true;
            //    textBox_se2.IsEnabled = true;
            //    textBox_ho1.IsEnabled = false;
            //    textBox_mi1.IsEnabled = false;
            //    textBox_se1.IsEnabled = false;
            //}
        }

    }
}
