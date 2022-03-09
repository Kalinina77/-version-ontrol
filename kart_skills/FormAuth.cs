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
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            var userRole = DBkarting.Cmd($"SELECT [ID_Role] FROM [dbo].[User] WHERE [Email] = '{textBox3.Text}' AND [Password] = '{textBox1.Text}'");
            if (userRole != null)
            {
                switch (userRole)
                {
                    case "A":
                        FormAdmin formAdmin = new FormAdmin();
                        formAdmin.Show();
                        break;
                    case "C":
                        FormCoordMain formCoordinator = new FormCoordMain();
                        formCoordinator.Show();
                        break;
                    case "R":
                        FormRacerMain formRacer = new FormRacerMain();
                        formRacer.Show();
                        break;
                }
            }
            else MessageBox.Show("Пользователя не существует");
        }
    }
    
}
