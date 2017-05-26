using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record_Searcher
{
    //complete rewrite needed
    class AdvancedSearch : Search
    {
        private List<Records> RecordSearched;
        string SearchFor;
        List<Records> Record;

       public AdvancedSearch (string _SearchFor, List<Records> _Record) : base( _SearchFor,  _Record)
        {
            this.Record = _Record;
            this.SearchFor = _SearchFor;
            RecordSearched = new List<Records>(5);
        }
        public AdvancedSearch(List<Records> _Record) : base(_Record)
       {
           this.Record = _Record;
           RecordSearched = new List<Records>(5);

       }
        //finds all books of type:....
        public  List<Records> FindBooksOfType(Type type)
       {
           var BookLookup = Record.ToLookup(x => x.type);
           RecordSearched = BookLookup[type].ToList();
           return RecordSearched;
       }
        //Finds the max Page in a list of books.
        public int  MaxPage(List<Records> Books)
        {
            int LargestPage = 0;
            var NumberList = Books.Select(x => x.Pages.Max());
            LargestPage = NumberList.Max();
            return LargestPage;
        }
        //this finds a specific book  BookName = Book 1, etc.
        //type is needed to find a exact book, not just all Book 1's.
        public  List<Records> FindABook(string BookName)
        {
         //   List<Records> AllBookOfType = FindBooksOfType(type);
            var BookLookup = Record.ToLookup(x => x.Title);
            RecordSearched = BookLookup[BookName].ToList();
            return RecordSearched;
        }
        //this finds all the records on a specific page
        public List<Records> FindPage(List<Records> Books, int find_number)
        {
            List<Records> PagesinBooks = new List<Records>();
            //change this to be a for loop instead to be easier to understand.
            //cycle through a list of the right books, and ask if Pages.select(x => s.contains(Find_number).any();
            if (find_number > 0)
            {
                foreach(Records record in Books)
                {
                   foreach( int page in record.Pages)
                    {
                        if (page == find_number)
                        {
                            PagesinBooks.Add(record);
                        }
                    }

                }
                return PagesinBooks;
            }
            else
            {
                return RecordSearched;
            }
           
        }
        //async method of finding pages.
        public async Task<List<Records>> AsyncFindPage(List<Records> Books, int find_number)
        {
           return await Task.Factory.StartNew(() => FindPage(Books, find_number));


        }
        public Task<List<Records>> AsyncFindDate(int[] DateRange)
        {
            return Task.Factory.StartNew(() => FindDate(DateRange));
        }
        public Task<List<Records>> AsyncFindDate(int[] DateRange, List<Records> DateRecords)
        {
            return Task.Factory.StartNew(() => FindDate(DateRange, DateRecords));
        }
        //finds the records in a range of dates.
        //instead of doing a min value and a max value, I should instead do a whole range of values to intersect with rather than testing this.
        private List<Records> FindDate(int[] DateRange)
        {
             Utility util = new Utility();
            foreach(Records rec in Record)
            {
                int[] RecordDateRange = util.GetValidDateRange(rec.Date, Program.normalRange);
                for (int i = 0; i < DateRange.Count(); i++)
                {
                    if (RecordDateRange.Contains(DateRange[i]))
                    {
                        RecordSearched.Add(rec);
                        break;
                    }
                }

            }
            return RecordSearched;
        }
        private List<Records> FindDate(int[] DateRange, List<Records> DateRecords)
        {
            Utility util = new Utility();
            foreach (Records rec in DateRecords)
            {
                int[] RecordDateRange = util.GetValidDateRange(rec.Date, Program.normalRange);
                for (int i = 0; i < DateRange.Count(); i++)
                {
                    if (RecordDateRange.Contains(DateRange[i]))
                    {
                        RecordSearched.Add(rec);
                        break;
                    }
                }

            }
            return RecordSearched;
        }
        public override List<Records> FindPerson(string FirstName, string LastName)
        {
            var LastLookup = Record.ToLookup(x => x.LastName);
            var FirstLookup = Record.ToLookup(x => x.FirstName);
            List<Records> result = LastLookup[LastName].Intersect(FirstLookup[FirstName]).ToList();
            return result;
            


        }
        public List<Records> FindTag(Tag tagName)
        {
            var TagLookup = Record.ToLookup(x => x.tag);
            return TagLookup[tagName].ToList();
        }
        public List<Records> FindTag(Tag tagName, List<Records> recs)
        {
            var TagLookup = recs.ToLookup(x => x.tag);
            return TagLookup[tagName].ToList();
        }
    }
}
