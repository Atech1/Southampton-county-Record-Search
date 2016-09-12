using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record_Searcher
{
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
        public async Task<List<Records>> AsyncFindPage(List<Records> Books, int find_number)
        {
           return await Task.Factory.StartNew(() => FindPage(Books, find_number));


        }



    }
}
