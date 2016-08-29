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
    public partial class MetroStyleRegForm : MetroFramework.Forms.MetroForm
    {
        List<Records> CurrentRecords;
        List<List<Records>> AllTypes;
        private Type type;

        public MetroStyleRegForm()
        {
            InitializeComponent();
         //   Set_ListView();

            SearchBox.Focus();

            CurrentRecords = new List<Records>();
            AllTypes = new List<List<Records>>(3);
        }
        private void Set_ListView()
        {
            ListView1.View = View.Details;
            ListView1.GridLines = true;
            ListView1.FullRowSelect = true;
            ListView1.Columns.Add("Type", 50, HorizontalAlignment.Left);
            ListView1.Columns.Add("Date", 100, HorizontalAlignment.Left);
            ListView1.Columns.Add("Title", 100, HorizontalAlignment.Left);
            ListView1.Columns.Add("Tag", 50, HorizontalAlignment.Left);
            ListView1.Columns.Add("Person", 100, HorizontalAlignment.Left);
            ListView1.Columns.Add("Pages", 1000, HorizontalAlignment.Left);

            this.ListView1.Sorting = SortOrder.Ascending;

        }
        private void Search_Click(object sender, EventArgs e)
        {
            ListView1.Clear();
            Utility util = new Utility();
            if (SearchBox.Text != "")
            {
                Search search = new Search();
                string SearchFor = SearchBox.Text;
                Set_ListView();
                foreach (List<Records> records in AllTypes)
                {
                    CurrentRecords = records;
                    foreach (Records rec in search.FindPerson(SearchFor, CurrentRecords))
                    {
                        Set_Display(rec, util.PagesToDisplay(rec.Pages));

                    }
                    foreach(ColumnHeader head in ListView1.Columns)
                    {
                      //  head.AutoResize(ColumnHeaderAutoResizeStyle.None);
                      //  head.Width = 150;
                        head.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

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
            ListView1.Items.Add(ToBeDisplayed);
            
         
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
               // CountProgress =  (i - 1) * (100 / types.Count());
                progressBar1.Value = i * (100 / types.Count());
               
            }
            this.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
            progressBar1.Hide();

            ListView1.Enabled = true;
            Btn1.Enabled = true;
        }

        private async void MetroStyleRegForm_Load(object sender, EventArgs e)
        {
            
          await LoadForm();
        }

        private async void metroTile1_Click(object sender, EventArgs e)
        {
            ListView1.Clear();
            await LoadForm();
        }
      
        }
    }
