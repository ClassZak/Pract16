using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox1.SelectedIndex = 1;
            this.listBox2.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите сумму для перевода в другую валюту", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            {
                bool inputFailed=false;
                byte pointsCount=0;
                for (int i=0;i!=this.textBox1.Text.Length;++i)
                {
                    if (this.textBox1.Text[i] == ',')
                    {
                        pointsCount++;
                    }
                    if (pointsCount > 1)
                    {
                        inputFailed=true;
                        break;
                    }
                }

                if(inputFailed)
                {
                    MessageBox.Show("Слишком много точек", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

           
            try
            {
                string searchQuery = $"https://www.google.ru/search?q={Uri.EscapeDataString(textBox1.Text.Trim())} {listBox1.SelectedItem} в {listBox2.SelectedItem}";
                this.webBrowser1.Navigate(new Uri(searchQuery));
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show($"Неверный формат URL:{Environment.NewLine}{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Ошибка соединения с интернетом:{Environment.NewLine}{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка:{Environment.NewLine}{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && (number!=',') && (number != 8))
            {
                e.Handled = true;
            }
        }
    }
}