using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record_Searcher
{
    class Search
    {

        private List<Records> RecordSearched;
        string SearchFor;
        List<Records> Record;

        public Search(string _SearchFor, List<Records> _Record)
        {
            this.Record = _Record;
            this.SearchFor = _SearchFor;
            RecordSearched = new List<Records>(5);
           

        }
        public Search(List<Records> _Record)
        {
            this.Record = _Record;
            RecordSearched = new List<Records>(5);

        }
        public virtual List<Records> FindPerson(string FirstName, string LastName)
        {
            var PersonLookup = Record.ToLookup(x => x.person);
            RecordSearched =  PersonLookup[SearchFor].ToList();
            return RecordSearched;
        }
        public List<Records> FindName( bool LastName )
        {
            
            if(LastName)
            {
                var NameLookup = Record.ToLookup(x => x.LastName);
                return (RecordSearched = NameLookup[SearchFor].ToList());

            }
            else
            {
                 var NameLookup = Record.ToLookup(x => x.FirstName);
                return (RecordSearched = NameLookup[SearchFor].ToList());

            }


        }
        public List<Records> FindName(bool LastName, List<Records> Book, string name)
        {

            if (LastName)
            {
                var NameLookup = Book.ToLookup(x => x.LastName);
                return (RecordSearched = NameLookup[name].ToList());

            }
            else
            {
                var NameLookup = Book.ToLookup(x => x.FirstName);
                return (RecordSearched = NameLookup[name].ToList());

            }


        }
        public List<Records> FindPerson(string name)
        {
            var PersonLookup = Record.ToLookup(x => x.person);
            RecordSearched = PersonLookup[name].ToList();
            return RecordSearched;
        }
        public List<Records> FindName(bool LastName, string name)
        {

            if (LastName)
            {
                var NameLookup = Record.ToLookup(x => x.LastName);
                return (RecordSearched = NameLookup[name].ToList());

            }
            else
            {
                var NameLookup = Record.ToLookup(x => x.FirstName);
                return (RecordSearched = NameLookup[name].ToList());

            }


        }
        public List<Records> FindPerson()
        {
            var PersonLookup = Record.ToLookup(x => x.person);
            RecordSearched = PersonLookup[SearchFor].ToList();
            return RecordSearched;
        }
    }
}
