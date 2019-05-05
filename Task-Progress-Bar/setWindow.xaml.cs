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
        public delegate void TransfDelegate(double value);
        public event TransfDelegate ProBarVal;
        public setWindow()
        {
            InitializeComponent();
        }

        private void SetWinLoaded(object sender, RoutedEventArgs e)
        {
            double wWidth = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            double wHeight = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            setWin.Left = wWidth / 2 - setWin.Width / 2;
            setWin.Top = wHeight / 2 - setWin.Height / 2;
        }

        private void TextBox_se1_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_se1, e);
        }
        
        private void TextBox_se1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi9999(textBox_se1);
        }
        private void TextBox_se2_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_se2, e);
        }
        private void TextBox_se2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi59(textBox_se2);
        }
        private void TextBox_mi1_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_mi1, e);
        }
        private void TextBox_mi1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi9999(textBox_mi1);
        }
        private void TextBox_mi2_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_mi2, e);
        }
        private void TextBox_mi2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi59(textBox_mi2);
        }
        private void TextBox_ho1_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_ho1, e);
        }
        private void TextBox_ho1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi9999(textBox_ho1);
        }
        private void TextBox_ho2_KeyDown(object sender, KeyEventArgs e)
        {
            MyKeyDown(textBox_ho2, e);
        }
        private void TextBox_ho2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Xianzhi23(textBox_ho2);
        }
        //限制最大数值
        private void Xianzhi9999(TextBox sender) {
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
        private void Xianzhi59(TextBox sender)
        {
            try
            {
                string strNum = sender.Text;
                if ("" == strNum || null == strNum)
                {
                    return;
                }
                int num = int.Parse(sender.Text);
                sender.Text = num.ToString();
                if (num <= 59)
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
                sender.Text = "59";
            }
        }
        private void Xianzhi23(TextBox sender)
        {
            try
            {
                string strNum = sender.Text;
                if ("" == strNum || null == strNum)
                {
                    return;
                }
                int num = int.Parse(sender.Text);
                sender.Text = num.ToString();
                if (num <= 23)
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
                sender.Text = "23";
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

        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f1 = (MainWindow)this.Owner;
            int ho, mi, se, sum;
            if (radioButton1.IsChecked == true)
            {
                if (textBox_ho1.Text == "")
                {
                    ho = 0;
                }
                else
                {
                    ho = int.Parse(textBox_ho1.Text);
                }
                if (textBox_mi1.Text == "")
                {
                    mi = 0;
                }
                else
                {
                    mi = int.Parse(textBox_mi1.Text);
                }
                if (textBox_se1.Text == "")
                {
                    se = 0;
                }
                else
                {
                    se = int.Parse(textBox_se1.Text);
                }
                sum = ho * 3600 + mi * 60 + se;
                MessageBox.Show(sum.ToString());
                ProBarVal(sum);
            }
            setWin.Close();
        }
    }
}
