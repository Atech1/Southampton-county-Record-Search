using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Record_Searcher
{
    //this is the first form that you see, it picks which style of form a user is shown (Metro or not)
    public partial class Form2 : Form
    {
        bool NewForm;
        Form2 ThisForm;
        public Form2(bool _NewForm)
        {
            this.NewForm = _NewForm;
            InitializeComponent();
            ThisForm = this;
        }

        private void Advanced_SearchClick(object sender, EventArgs e)
        {
            return;
        }

        private void Regular_SearchClick(object sender, EventArgs e)
        {
            if(!NewForm)
            {
                ThisForm.Hide();
                OldStyleBasicForm form = new OldStyleBasicForm();
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
            else
            {
                ThisForm.Hide();
                MetroStyleRegForm form = new MetroStyleRegForm();
                form.Closed += (s, args) => this.Close();
                form.Show();
                
            }
        }
    }
}
