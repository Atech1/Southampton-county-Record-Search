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
        

        public Search()
        {
            RecordSearched = new List<Records>(5);
           

        }

        public List<Records> FindPerson(string SearchFor, List<Records> Record)
        {
            var PersonLookup = Record.ToLookup(x => x.person);
            RecordSearched =  PersonLookup[SearchFor].ToList();
            return RecordSearched;
        }
        public List<Records> FindName(string SearchFor, List<Records> Record, bool LastName )
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

    }
}
