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
    public partial class FormPlayed : Form
    {
        public FormPlayed()
        {
            InitializeComponent();
        }
        public FormPlayed(string money, string racer)
        {
            InitializeComponent();
            moneylabel.Text = money;
            pip.Text = racer;
        }
    }
}
