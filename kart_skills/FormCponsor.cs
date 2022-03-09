using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kart_skills
{
    public partial class FormCponsor : Form
    {
        public FormCponsor()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormCponsor_Load(object sender, EventArgs e)
        {
            var data = DBkarting.FillDataSet("SELECT * FROM Racer").Tables[0];
            List<DisplayRace> racers = new List<DisplayRace>();
            foreach (DataRow row in data.Rows)
            {
                var d = row.ItemArray;
                racers.Add(new DisplayRace($"{d[1]} {d[2]} - 204 (UKR)", d[0].ToString()));
            }
            comboBox1.DataSource = racers;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "name";
        }

        private class DisplayRace
        {
            public DisplayRace(string name, string id)
            {
                this.name = name;
                this.id = id;
            }

            public string name { get; set; }
            public string id { get; set; }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            FormPlayed form = new FormPlayed(moneylabel.Text, comboBox1.SelectedValue.ToString());
            form.Show();
            Close();
        }

      

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(textBoxmoney.Text);
                money -= 10;
                if (money < 0) money = 0;
                textBoxmoney.Text = money.ToString();
                moneylabel.Text = $"$ {money}";
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(textBoxmoney.Text);
                money += 10;
                textBoxmoney.Text = money.ToString();
                textBoxmoney.Text = $"$ {money}";
            }
            catch { }
        }
    }
}

