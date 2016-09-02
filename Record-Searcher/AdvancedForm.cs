using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
namespace Record_Searcher
{
    public partial class AdvancedForm : MetroFramework.Forms.MetroForm
    {
        List<Records> CurrentRecords;
        List<List<Records>> AllTypes;
        private Type type;

        public AdvancedForm()
        {
            InitializeComponent();
            CurrentRecords = new List<Records>();
            AllTypes = new List<List<Records>>(3);
        }

        private async Task LoadForm()
        {
            Btn1.Enabled = false;
            progressBar1.Show();
            ListView1.Enabled = false;
            // int CountProgress;
            type = new Type("Deed", Program.DirectoryPath);
            Utility util = new Utility();
            string[] types = Type.NumberOfValidTypes();
            progressBar1.Value = 4;
            Cursor.Current = Cursors.WaitCursor;
            this.UseWaitCursor = true;
            for (int i = 1; i < types.Count() + 1; i++)
            {
                Reader Formatter = new Reader(util.FindFiles(type.GeneratePathsForTypes(types[i - 1])), Utility.GetTitle());
                List<Records> RunThroughTypeList = new List<Records>();

                RunThroughTypeList = await Formatter.ConvertToRecordAsync(new Type(types[i - 1], Program.DirectoryPath));

                AllTypes.Add(RunThroughTypeList);
                
                progressBar1.Value = i * (100 / types.Count());

            }
            this.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
            progressBar1.Hide();

            ListView1.Enabled = true;
            Btn1.Enabled = true;
            TypeBoxSet();
        }

        private async void AdvancedForm_Load(object sender, EventArgs e)
        {
            await LoadForm();
        }

        private async void Reload(object sender, EventArgs e)
        {
            await LoadForm();
        }

        private void TypeBoxSet()
        {
            List<string> types = new List<string>();
            types.Add("All");
            types.AddRange(Type.NumberOfValidTypes());
            TypeBox.DataSource = types;
        }

        private void BookBoxUpdate(object sender, EventArgs e)
        {
            string selected = this.TypeBox.GetItemText(this.TypeBox.SelectedItem);
            if(selected == "All")
            {
                return;
            }
            else
            {
                Utility util = new Utility();
                BookBox.DataSource = util.DictionaryKeys(selected);

            }
        }

        private void DateUpdate(object sender, EventArgs e)
        {
            if (this.BookBox.SelectedItem != null)
            {
                Utility util = new Utility();
                Type UsedType = new Type(this.TypeBox.GetItemText(this.TypeBox.SelectedItem), Program.DirectoryPath);
                string selected = this.BookBox.GetItemText(this.BookBox.SelectedItem);
                int i;
                if (Int32.TryParse(selected.Trim('B', 'o', 'k'), out i))
                {
                    DateBox.Text = util.DateGetter(UsedType, i);

                }
            }
            else
            {
                return;
            }
        }

        private void ValidateDate(object sender, EventArgs e)
        {
            int date;
            if(int.TryParse(DateBox.Text, out date))
            {
                if(((date - 1749) < 0))
                {
                    DateBox.Text = "1749";
                }
                else if(((1881 - date) < 0))
                {
                    DateBox.Text = "1881";
                }
            }
            else
            {

                return;
            }
        }

        
    }
}
