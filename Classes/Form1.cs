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
    public partial class Form1 : Form
    {

        List<Records> CurrentRecords;
        List<List<Records>> AllTypes;
        private Type type;
      
        //mode is to check if a user wants deeds, wills, etc. to handle loading them separatly rather than all at once.

        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
            type = new Type("Deed");
             CurrentRecords = new List<Records>();
             AllTypes = new List<List<Records>>(3);
        }

        private void Loading(object sender, EventArgs e)
        {

            Set_List();
        Set_ListView();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            Utility util = new Utility();
            if(textBox1.Text != "")
            {
                Search search = new Search();
                string SearchFor = textBox1.Text;
                foreach (List<Records> records in AllTypes)
                {
                    CurrentRecords = records;
                    foreach (Records rec in search.FindPerson(SearchFor, CurrentRecords))
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

       
        private void Set_List() 
        {
            Utility util = new Utility();
            string[] types = Type.NumberOfValidTypes();
            for(int i = 0; i < types.Count(); i++)
            {
                Reader Formatter = new Reader(util.FindFiles(type.GeneratePathsForTypes(types[i])), util.GetTitle());
                List<Records> RunThroughTypeList = new List<Records>();
                RunThroughTypeList = Formatter.ConvertToRecord(new Type(types[i]));
                AllTypes.Add(RunThroughTypeList);
            }
        }
        }
    }

