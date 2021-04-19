using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMWF.Models;

namespace VMWF
{
    public partial class Form1 : Form
    {
        public int Rest;
        public Form1()
        {
            InitializeComponent();
           // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           
            LoadData1();
            
        }

     

        private void LoadData1()
        {
            foreach (var p in ProductDb.Products)
            {
                dataGridView1.Rows.Add(p.name, p.price, p.rest);
            }

            label1.Text = Rest.ToString();
            label2.Text = CMoneyBag.ten.ToString();
            label3.Text = CMoneyBag.five.ToString();
            label4.Text = CMoneyBag.two.ToString();
            label5.Text = CMoneyBag.one.ToString();

            label6.Text = "Внесите Ваши денешки";
            label6.BackColor = Color.LightYellow;
        }

      
       

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var p in ProductDb.Products)
            {

                if (e.RowIndex == p.id)
                {
                    if(p.price <= Rest)
                    {
                        p.Buy();
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].SetValues(p.name, p.price, p.rest);
                        Rest -= p.price;
                        label1.Text = Rest.ToString();
                        label6.Text = "СПАСИБО!";
                        label6.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        label6.Text = "НЕ ДОСТАТОЧНО СРЕДСТВ";
                        label6.BackColor = Color.Red;
                    }
                   
                }
            }

           
        }

     

        private void Button1_Click(object sender, EventArgs e)
        {
            int n_ten = Rest / 10;
            int n_five = (Rest - n_ten * 10) / 5;
            int n_two = (Rest - n_ten * 10 - n_five * 5) / 2;
            int n_one = (Rest - n_ten * 10 - n_five * 5 - n_two * 2);
            //
            //
            CMoneyBag.ten = CMoneyBag.ten + n_ten;
            CMoneyBag.five = CMoneyBag.five + n_five;
            CMoneyBag.two = CMoneyBag.two + n_two;
            CMoneyBag.one = CMoneyBag.one + n_one;

            MMoneyBag.ten -= n_ten;
            MMoneyBag.five -= n_five;
            MMoneyBag.two -= n_two;
            MMoneyBag.one -= n_one;

            Rest = 0;
            label1.Text = Rest.ToString();
            label2.Text = CMoneyBag.ten.ToString();
            label3.Text = CMoneyBag.five.ToString();
            label4.Text = CMoneyBag.two.ToString();
            label5.Text = CMoneyBag.one.ToString();

            label6.Text = "Внесите Ваши денешки";
            label6.BackColor = Color.LightYellow;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(CMoneyBag.ten > 0)
            {
                CMoneyBag.ten -= 1;

                Rest = Rest + 10;
                MMoneyBag.ten += 1;
                label2.Text = CMoneyBag.ten.ToString();
                label1.Text = Rest.ToString();
                label6.Text = "Внесите Ваши денешки";
                label6.BackColor = Color.LightYellow;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (CMoneyBag.five > 0)
            {
                CMoneyBag.five -= 1;
                Rest = Rest + 5;
                MMoneyBag.five += 1;
                label3.Text = CMoneyBag.five.ToString();
                label1.Text = Rest.ToString();
                label6.Text = "Внесите Ваши денешки";
                label6.BackColor = Color.LightYellow;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (CMoneyBag.two > 0)
            {
                CMoneyBag.two -= 1;
                Rest = Rest + 2;
                MMoneyBag.two += 1;
                label4.Text = CMoneyBag.two.ToString();
                label1.Text = Rest.ToString();
                label6.Text = "Внесите Ваши денешки";
                label6.BackColor = Color.LightYellow;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (CMoneyBag.one > 0)
            {
                CMoneyBag.one -= 1;
                Rest = Rest + 1;
                MMoneyBag.one += 1;
                label5.Text = CMoneyBag.one.ToString();
                label1.Text = Rest.ToString();
                label6.Text = "Внесите Ваши денешки";
                label6.BackColor = Color.LightYellow;
            }
        }
    }
}
