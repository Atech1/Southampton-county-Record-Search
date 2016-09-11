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
        public  List<Records> FindBook(Type type)
       {
           var BookLookup = Record.ToLookup(x => x.Title);
           RecordSearched = BookLookup[SearchFor].ToList();
           return RecordSearched;
       }
        public int MaxPage(List<Records> Books)
        {
            int LargestPage = 0;
            LargestPage = Books.SelectMany(x => x.Pages).Max();
            return LargestPage;
        }

        public List<Records> FindPage(List<Records> Books, int find_number)
        {
            //change this to be a for loop instead to be easier to understand.
            //cycle through a list of the right books, and ask if Pages.select(x => s.contains(Find_number).any();
            if (find_number > 0)
            {
               // RecordSearched = Books.SelectMany(x => x.Pages.Contains(find_number)).ToList();
            }
            return RecordSearched;
           
        }



    }
}
