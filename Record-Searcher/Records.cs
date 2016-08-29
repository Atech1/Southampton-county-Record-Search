using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record_Searcher
{
    [Serializable]
    //this class is to have a data structure to keep all the records, rather than separate strings, ints, etc.
   public  class Records
    {
       
       //I may want to think about adding a way to keep track of what book number the record is actually a part of
       //rather than keeping that with the book title. that way it can be easier to reference.
     public String Title { get; set; }
     public String FirstName { get; set; }
     public string LastName { get; set; }
     public List<int> Pages { get; set; }
     public string person { get; set; }
     public string Tag { get; set; }
     public int BookNumber { get; set; }
     public string Date { get; set; }
     private Type _type;
     public Type type
     {
         get
         {
           return this._type;
         }


         set
         {
             this._type = value;
             GrabDate();
         }

     }
        private void GrabDate()
        {
            Utility util = new Utility();
            if (BookNumber != 0)
            {
                Date = util.DateGetter(this._type, this.BookNumber);
            }
            else
            {
                Date = "ERROR";
                //should log some error to debug.
                Error.Log("Date did not have an entry in dictionary! Location : Records. number and type:   " + BookNumber.ToString() + " " + type.ToString());
            }
         
        }
    }
}
