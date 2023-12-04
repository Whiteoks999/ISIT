using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Обфускатор
{
    public partial class Form1 : Form
    {
        Obfuskator obfuskator;
        public Form1()
        {
            InitializeComponent();
            obfuskator=Obfuskator.GetObfuskator();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); //открытие диалогового окна
            openFileDialog1.Filter = "Text|*.txt"; //расширение файла

            string readFile = File.ReadAllText(openFileDialog1.FileName); //считывание файла
            obfuskator.addSourceCode(readFile); //передача данных файла в обфускатор

            richTextBox1.Text = obfuskator.obfuscate(); //обфусцирование программного кода и его вывод в тектовое поле
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
