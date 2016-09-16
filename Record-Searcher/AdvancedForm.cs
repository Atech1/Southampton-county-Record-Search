﻿using System;
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
        const int normalRange = 10;
        string[] types;
        [Flags]
        enum GivenInfo
        {
            NONE = 0,
            TYPE = 1 << 0,
            BOOK = 1 << 1,
            FIRSTNAME = 1 << 2,
            LASTNAME = 1 << 3,
            DATE = 1 << 4,
            PAGE = 1 << 5
        }
      private  GivenInfo _Flags;
        GivenInfo Flags
      {
          get
          {
              return this._Flags;
          }
          set
          {
              this._Flags = value;
              UpdateFlags();

          }
      }

      
        public AdvancedForm()
        {
            InitializeComponent();
            CurrentRecords = new List<Records>();
            AllTypes = new List<List<Records>>(3);
            Set_ListView();
        }
        //loads all the records
        private async Task LoadForm()
        {
            Btn1.Enabled = false;
            progressBar1.Show();
            ListView1.Enabled = false;
            type = new Type("Deed");
            Utility util = new Utility();
            types = Type.NumberOfValidTypes();
            progressBar1.Value = 4;
            Cursor.Current = Cursors.WaitCursor;
            this.UseWaitCursor = true;
            for (int i = 1; i < types.Count() + 1; i++)
            {
                Reader Formatter = new Reader(util.FindFiles(Type.GeneratePathsForTypes(types[i - 1])), Utility.GetTitle());
                List<Records> RunThroughTypeList = new List<Records>();

                RunThroughTypeList = await Formatter.ConvertToRecordAsync(new Type(types[i - 1]));

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
        //reloads records
        private async void Reload(object sender, EventArgs e)
        {
            await LoadForm();
        }
        //sets the data source of the type box.
        private void TypeBoxSet()
        {
            List<string> types = new List<string>();
            types.Add("All");
            types.AddRange(Type.NumberOfValidTypes());
            TypeBox.DataSource = types;

        }
        //runs when type is selected to give the correct number of books to the other box.
        private void TypeSelected(object sender, EventArgs e)
        {
            string selected = this.TypeBox.GetItemText(this.TypeBox.SelectedItem);
            if (selected == "All")
            {
                Flags -= GivenInfo.TYPE;
                BookBox.DataSource = null;
                if(Flags.HasFlag(GivenInfo.BOOK))
                {
                    Flags -= GivenInfo.BOOK;
                }
                return;
            }
            else if (Type.CorrectType(selected))
            {
                Utility util = new Utility();
                BookBox.DataSource = util.DictionaryKeys(new Type(selected));
               // BookBox.Items.Add("None");
                Flags |= GivenInfo.TYPE;

            }
        }
        //gives the correct date to the date box
        private void BookSelected(object sender, EventArgs e)
        {
            if (this.BookBox.SelectedItem != null || (this.BookBox.GetItemText(this.BookBox.SelectedItem) == "None"))
            {
                Utility util = new Utility();
                Type UsedType = new Type(this.TypeBox.GetItemText(this.TypeBox.SelectedItem));
                string selected = this.BookBox.GetItemText(this.BookBox.SelectedItem);
                int i;
                if (Int32.TryParse(selected.Trim('B', 'o', 'k'), out i))
                {
                    DateBox.Text = util.DateGetter(UsedType, i);
                    Flags |= GivenInfo.BOOK;

                }
            }
            else
            {
                Flags -= GivenInfo.BOOK;
                return;
            }
        }
        //checks to see if the date is right when the date is typed rather than passed
        private void ValidateDate(object sender, EventArgs e)
        {
            int date;
            if (int.TryParse(DateBox.Text, out date))
            {
                if (((date - 1749) < 0))
                {
                    DateBox.Text = "1749";
                }
                else if (((1881 - date) < 0))
                {
                    DateBox.Text = "1881";
                }
                Flags |= GivenInfo.DATE;
            }
            else
            {

                return;
            }
        }
        //returns the min year and the max year for purposes of searching dates.
        private int[] GetValidDateRange()
        {
            int[] DateRange = new int[2];
            int i;
            if (DateBox.Text != null)
            {
                //see if a valid number is already in the box.
                if (int.TryParse(DateBox.Text, out i))
                {
                    DateRange[0] = i - normalRange;
                    DateRange[1] = i + normalRange;
                    return DateRange;
                }
                else
                {
                    var info = DateBox.Text.Split('-').Select(x => x.Trim('[', ']')).ToArray();
                    for (int j = 0; j < info.Count(); j++)
                    {
                        if (int.TryParse(info[j], out i))
                        {
                            DateRange[j] = i;

                        }
                        else
                        {
                            DateRange[j] = 0;
                        }

                    }
                    return DateRange;

                }

            }
            return DateRange;
        }
        //checks which search will be called based on the flags raised with the other info passed in.
        private async Task<List<Records>> CheckFlags(GivenInfo flags = GivenInfo.NONE)
        {
            string selectedType = this.TypeBox.GetItemText(this.TypeBox.SelectedItem);
            string selectedBook = this.BookBox.GetItemText(this.BookBox.SelectedItem);
            int selectedPage = 0;
            if (Flags.HasFlag(GivenInfo.PAGE))
            {
                selectedPage = int.Parse(PageBox.Text);
            }
            switch (flags)
            {
                case GivenInfo.NONE:
                    {
                        await LoadForm();
                        break;
                    }
                case GivenInfo.TYPE:
                    {
                        return FindListOfType(selectedType);
                    }
                case GivenInfo.TYPE | GivenInfo.BOOK:
                    {
                        AdvancedSearch search = new AdvancedSearch(FindListOfType(selectedType));
                        return search.FindABook(selectedBook);
                    }
                case GivenInfo.PAGE | GivenInfo.BOOK | GivenInfo.TYPE:
                    {
                        AdvancedSearch search = new AdvancedSearch(FindListOfType(selectedType));
                        
                         List<Records> FoundPages = await search.AsyncFindPage(search.FindABook(selectedBook), selectedPage);
                         return FoundPages;
                    }
            }
            return null;

        }
        //checks to see if the page number is within the right range  1 < x < AdvancedSearch.MaxPage();
        private void CheckPageNumber(object sender, EventArgs e)
        {
            string selectedType = this.TypeBox.GetItemText(this.TypeBox.SelectedItem);
            string selectedBook = this.BookBox.GetItemText(this.BookBox.SelectedItem);
            //The Records are Organized By Type.
            if (Flags.HasFlag(GivenInfo.TYPE) && Flags.HasFlag(GivenInfo.BOOK))
            {
                //sees which type is checked in the box.
                for (int i = 0; i < types.Count(); i++)
                {
                    //finds if the right type has been selected
                    if (types[i] == selectedType)
                    {
                        //grabs the right index of the list holding the records.
                        //it should be in the same position as the type[i] as they were intialized in that order.
                        AdvancedSearch search = new AdvancedSearch(AllTypes[i]);
                        //searches for a specific book title
                        List<Records> Books = search.FindABook(selectedBook);
                        //now finding out if the pagenumber was broken or not.
                        int Max = search.MaxPage(Books);
                        int ActualPage;
                        if (int.TryParse(PageBox.Text, out ActualPage))
                        {
                            if (0 < ActualPage && ActualPage <= Max)
                            {
                                //this is a valid page search.
                                Flags |= GivenInfo.PAGE;
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Choose page between 0 and " + Max);
                                PageBox.Text = "0 - " + Max;
                                return;

                            }
                        }
                    }
                }
            }
            else
            {
                Flags -= GivenInfo.PAGE;
               PageBox.Text = " ";
                return;
            }



        }

        //sets the list display foreach record.
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
        private List<Records> FindListOfType(string selectedType)
        {
            for (int i = 0; i < types.Count(); i++)
            {
                //finds if the right type has been selected
                if (types[i] == selectedType)
                {
                    return AllTypes[i];
                }
            }
            return null;

        }

        private async void search(object sender, EventArgs e)
        {
            if(ListView1.Items.Count != 0)
            {
                ClearListView();
            }
            Utility util = new Utility();
            List<Records> Result = await CheckFlags(Flags);
            foreach (Records rec in Result)
            {
                Set_Display(rec, util.PagesToDisplay(rec.Pages));
            }
            foreach (ColumnHeader head in ListView1.Columns)
            {
                head.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
           
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
        private  void  ClearListView()
        {
            for(int i = ListView1.Items.Count - 1; 0 <= i; i--)
            {
                ListView1.Items[i].Remove();
            }
        }
        private void UpdateFlags()
        {
            TestBox.Text = Flags.ToString();
        }
    }
}

