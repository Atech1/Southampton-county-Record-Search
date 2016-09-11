using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace Record_Searcher
{
    [Serializable]
    //this class holds all of the UI logic to show the result of the search
    //this works as it will not be the only form.
    public partial class OldStyleBasicForm : Form
    {
        List<Records> CurrentRecords;
        List<List<Records>> AllTypes;
        private Type type;

        public OldStyleBasicForm()
        {
            InitializeComponent();
            Set_ListView();

            textBox1.Focus();

            CurrentRecords = new List<Records>();
            AllTypes = new List<List<Records>>(3);
        }

        private async void Loading(object sender, EventArgs e)
        {
            await LoadForm();
        }

        private async Task LoadForm()
        {
            Click.Enabled = false;
            progressBar1.Show();
            listView1.Enabled = false;

         //   type = new Type("Deed");
            Utility util = new Utility();
            string[] types = Type.NumberOfValidTypes();
            for (int i = 1; i < types.Count() + 1; i++)
            {
                Reader Formatter = new Reader(util.FindFiles(Type.GeneratePathsForTypes(types[i - 1])), Utility.GetTitle());
                List<Records> RunThroughTypeList = new List<Records>();

                RunThroughTypeList = await Formatter.ConvertToRecordAsync(new Type(types[i - 1]));

                AllTypes.Add(RunThroughTypeList);
                progressBar1.Value = i * (100 / types.Count());
            }

            progressBar1.Hide();

            listView1.Enabled = true;
            Click.Enabled = true;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Utility util = new Utility();
            if (textBox1.Text != "")
            {
                
                string SearchFor = textBox1.Text;
                foreach (List<Records> records in AllTypes)
                {
                    CurrentRecords = records;
                    Search search = new Search(SearchFor, CurrentRecords);
                    foreach (Records rec in search.FindPerson())
                    {
                        Set_Display(rec, util.PagesToDisplay(rec.Pages));
                        
                    }
                }
            }
        }

        private void Set_Display(Records rec, string CorrectPages)
        {
            var ToBeDisplayed = new ListViewItem(new[]
            {
                rec.type.GetName(),
                rec.Date,
                rec.Title,
                rec.Tag,
                rec.person,
                CorrectPages
               
            });
            listView1.Items.Add(ToBeDisplayed);
        }
        
        private void Set_ListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Type", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Date", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Title", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Tag", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Person", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Pages", 1000, HorizontalAlignment.Left);

            this.listView1.Sorting = SortOrder.Ascending;

        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Error errors = new Error();
            errors.OnClosing();
        }

        private void Highlight(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.Cyan;

        }

        private void DeLight(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.White;
        }

        private async void buttonReload_Click(object sender, EventArgs e)
        {
            await LoadForm();
        }
    }
}

