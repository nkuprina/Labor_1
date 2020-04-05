using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Labor_1_Kuprina_Duarte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void открытьCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDlg.Dispose();
        }

        private void сохранитьCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();
        }

        private void выходAltXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информация о приложении и разработчике");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            listBox1.BeginUpdate();

            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in Strings)
            {
                string Str = s.Trim();

                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }

            }
            listBox1.EndUpdate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            richTextBox1.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            string Find = textBox1.Text;
            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();

            AddRec.Owner = this;
            AddRec.ShowDialog();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "алфавиту(по убыванию)")
            {
                System.Collections.ArrayList list = new ArrayList();
                foreach (var item in listBox1.Items)
                {
                    list.Add(item);
                }
                list.Sort();
                list.Reverse();
                listBox1.Items.Clear();
                foreach (var item in list)
                {
                    listBox1.Items.Add(item);
                }
            }
            if (comboBox1.Text == "алфавиту(по возрастанию)")
            {
                System.Collections.ArrayList list = new ArrayList();
                foreach (var item in listBox1.Items)
                {
                    list.Add(item);
                }
                list.Sort();
                listBox1.Items.Clear();
                foreach (var item in list)
                {
                    listBox1.Items.Add(item);
                }
            }
            if (comboBox1.Text == "длине слова(по возрастанию)")
            {
                List<String> list = new List<string>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }
            if (comboBox1.Text == "длине слова(по убыванию)")
            {
                List<String> list = new List<string>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox2.Items.Add(this.listBox1.Text);
            this.listBox1.Items.Remove(this.listBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Add(this.listBox2.Text);
            this.listBox2.Items.Remove(this.listBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "алфавиту(по убыванию)")
            {
                System.Collections.ArrayList list = new ArrayList();
                foreach (var item in listBox2.Items)
                {
                    list.Add(item);
                }
                list.Sort();
                list.Reverse();
                listBox2.Items.Clear();
                foreach (var item in list)
                {
                    listBox2.Items.Add(item);
                }
            }
            if (comboBox2.Text == "алфавиту(по возрастанию)")
            {
                System.Collections.ArrayList list = new ArrayList();
                foreach (var item in listBox2.Items)
                {
                    list.Add(item);
                }
                list.Sort();
                listBox2.Items.Clear();
                foreach (var item in list)
                {
                    listBox2.Items.Add(item);
                }
            }
            if (comboBox2.Text == "длине слова(по возрастанию)")
            {
                List<String> list = new List<string>();
                foreach (var item in listBox2.Items)
                    list.Add(item.ToString());

                listBox2.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox2.Items.Add(item);
            }
            if (comboBox2.Text == "длине слова(по убыванию)")
            {
                List<String> list = new List<string>();
                foreach (var item in listBox2.Items)
                    list.Add(item.ToString());

                listBox2.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox2.Items.Add(item);
            }
        }

        private void listBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
