using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using Form = System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using build;
using ClassLib;
namespace Web
{
    public partial class Form1 : Form.Form
    {
        DataGrid dg;
        private Form.Button bFind;
        private Form.Button bCancel;
        private Dictionary<string, Form.TextBox> textBox = new Dictionary<string, Form.TextBox>();//Коллекция будет содержать текстбоксы окна
        private Dictionary<string, Form.Label> label = new Dictionary<string, Form.Label>(); //а эта метки

        public Form1(DataGrid DG)
        {
            dg = DG;
            string[] args = new string[dg.Columns.Count];//создается массив строк 
            for (int i1 = 0; i1 < dg.Columns.Count; i1++)
            {
                args[i1] = dg.Columns[i1].Header.ToString();  //в этом массиве хранятся названя столбцов текущего dataGrid
            }
            int i;
            for (i = 0; i < args.Length; i++)//В этом цикле конструируется окно args.Length значит количество критерриев поиска
            {
                textBox.Add(args[i], new Form.TextBox());//создается и добовляется текст бокс в коллекцию
                this.SuspendLayout();
                textBox[args[i]].Location = new System.Drawing.Point(150, ((5 + 20) * i) + 12);
                textBox[args[i]].Name = args[i];
                textBox[args[i]].Size = new System.Drawing.Size(100, 20);
                textBox[args[i]].TabIndex = i;
                this.Controls.Add(textBox[args[i]]);

                label.Add(args[i], new Form.Label());
                this.SuspendLayout();
                label[args[i]].RightToLeft = Form.RightToLeft.Yes;
                label[args[i]].Location = new System.Drawing.Point(0, ((5 + 20) * i) + 12);
                label[args[i]].Name = args[i];
                label[args[i]].Size = new System.Drawing.Size(120, 20);
                label[args[i]].Text = args[i];
                this.Controls.Add(label[args[i]]);
                this.FormBorderStyle = Form.FormBorderStyle.FixedDialog;
            }
            // 
            // Form1
            // 

            bFind = new Form.Button();
            bCancel = new Form.Button();
            bFind.Text = "Поиск";
            bCancel.Text = "Отмена";
            bCancel.Location = new System.Drawing.Point(150, ((5 + 20) * i) + 15);
            bFind.Location = new System.Drawing.Point(30, ((5 + 20) * i) + 15);
            bCancel.Click += new EventHandler(bCancel_Click);
            bFind.Click += new EventHandler(bFind_Click);
            this.Controls.Add(bFind);
            this.Controls.Add(bCancel);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, ((5 + 20) * i) + 45);

            this.Name = "Поиск";
            this.Text = "Поиск";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void bFind_Click(object sender, EventArgs e)
        {
            IList l = (IList)dg.ItemsSource;
            string[] s = new string[textBox.Count];

            for (int i = 0; i < textBox.Count; i++)
            {
                s[i] = textBox[dg.Columns[i].Header.ToString()].Text;

                for (int j = 0; j < dg.Items.Count; j++)
                {
                    string str = ((Zapis)l[j]).get(dg.Columns[i].Header.ToString());
                    //Console.Write(str.IndexOf(s[i]));
                    if (str.IndexOf(s[i]) < 0)
                    {
                        l.RemoveAt(j);
                        j--;
                    }


                }

            }
            dg.ItemsSource = null;
            dg.ItemsSource = l;
            Close();


        }
    }
}
