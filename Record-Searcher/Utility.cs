using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Record_Searcher
{
    //this class is to do all the logic which is to be separated from the UI elements.
    class Utility
    {
        //sets mode, for what type of record you are looking for.
        List<string> paths;
       // string[] BookTitles;
        string BasePath;
        //dictionary setup for the date dictionaries.
       static Dictionary<int, string> WillDates;
       static Dictionary<int, string> DeedDates;
        public Utility()
        {
        
            Intial();
        }
        private Dictionary<int, string> DictionaryGet(Type type)
        {
            //sets up a date dictionary for the record systems.
            
          
            if (type.GetName() == "Deed")
            {
                
                return DeedDates;
            }
            else if(type.GetName() == "Will")
            {
                return WillDates;
            }
            return null;

        }
        public string DateGetter(Type type, int BookNum)
        {
            //grabs the right date from the dictionary, for the right books
            string date = " ";
            //gets the dictionary for the right type of books.
            Dictionary<int, string> dateDict = DictionaryGet(type);
            if (dateDict.Count >= BookNum)
            {
                date = dateDict[BookNum];

                return date;
            }
            else
            {

                return "Error";
            }
        }
        public List<string> FindFiles(string path)
        {
            //this grabs all the files in the folder for the type (which is the path coming in)
            //and adds it to the files to read if it starts with book and ends in .txt
            List<string> paths = new List<string>();
            
                foreach (string file in Directory.GetFiles((path), "*txt"))
                {

                    paths.Add(file);

                }
            return paths;
        }
        public string RecordOutput(Records rec)
        {
            //this will put together a final string to show all the info in the record, for the UI element.
            string display;
            //adds all the info into the display to be displayed.
            display = (rec.Date + "   " + rec.Tag + rec.Title + "  " + rec.LastName+", "+ rec.FirstName + PagesToDisplay(rec.Pages) + "\n");
          //  num_pages = null;
            return display;
        }
        //this method makes it easy to turn this pages list into a string to display and to compare.
        public string PagesToDisplay(List<int> Pages)
        {

            string num_pages = " ";
            
              for(int i = 0; i < Pages.Count; i++)
              {
                  if((Pages.Count - 1) == i)
                  {
                      if (Pages.ToArray()[i] != 0)
                      {
                          num_pages += Pages.ToArray()[i] + " ";
                      }
                  }
                  else
                  {
                      if (Pages.ToArray()[i] != 0)
                      {
                          num_pages += Pages.ToArray()[i] + ", ";
                      }
                  }

              }
            
            return num_pages;
        }
        private void Intial()
        {
            //intializes values
            paths = new List<string>();
            BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DeedDates = new Dictionary<int, string>();
            WillDates = new Dictionary<int, string>();

            #region Dictionary Declarations
            DeedDates.Add(1, "[1749 - 1753]");
            DeedDates.Add(2, "[1753 - 1760]");
            DeedDates.Add(3, "[1763 - 1767]");
            DeedDates.Add(4, "[1767 - 1773]");
            DeedDates.Add(5, "[1773 - 1775]");
            DeedDates.Add(6, "[1773 - 1775]");
            DeedDates.Add(7, "[1787 - 1793]");
            DeedDates.Add(8, "[1793 - 1798]");
            DeedDates.Add(9, "[1798 - 1802]");
            DeedDates.Add(10, "[1802 - 1805]");
            DeedDates.Add(11, "[1805 - 1809]");
            DeedDates.Add(12, "[1809 - 1812]");
            DeedDates.Add(13, "[1812 - 1814]");
            DeedDates.Add(14, "[1814 - 1816]");
            DeedDates.Add(15, "[1816 - 1818]");
            DeedDates.Add(16, "[1818 - 1819]");
            DeedDates.Add(17, "[1819 - 1820]");
            DeedDates.Add(18, "[1821 - 1822]");
            DeedDates.Add(19, "[1822 - 1826]");
            DeedDates.Add(20, "[1826 - 1828]");
            DeedDates.Add(21, "[1828 - 1831]");
            DeedDates.Add(22, "[1831 - 1833]");
            DeedDates.Add(23, "[1833 - 1836]");
            DeedDates.Add(24, "[1836 - 1840]");
            DeedDates.Add(25, "[1840 - 1843]");
            DeedDates.Add(26, "[1843 - 1846]");
            DeedDates.Add(27, "[1846 - 1850]");
            DeedDates.Add(28, "[1850 - 1851]");
            DeedDates.Add(29, "[1851 - 1860]");
            DeedDates.Add(30, "[1860 - 1870]");
            DeedDates.Add(31, "[1870 - 1874]");
            DeedDates.Add(32, "[1874 - 1877]");
            DeedDates.Add(33, "[1877 - 1879]");
            DeedDates.Add(34, "[1879 - 1880]");
            DeedDates.Add(35, "[1880 - 1881]");
            WillDates.Add(1, "[1747 - 1762]");
            WillDates.Add(2, "[1762 - 1772]");
            WillDates.Add(3, "[1772 - 1783]");
            WillDates.Add(4, "[1783 - 1797]");
            WillDates.Add(5, "[1797 - 1804]");
            WillDates.Add(6, "[1804 - 1810]");
            WillDates.Add(7, "[1810 - 1815]");
            WillDates.Add(8, "[1815 - 1818]");
            WillDates.Add(9, "[1812 - 1828]");
            WillDates.Add(10, "[1825 - 1832]");
            WillDates.Add(11, "[1832 - 1837]");
            WillDates.Add(12, "[1837 - 1842]");
            WillDates.Add(13, "[1842 - 1847]");
            WillDates.Add(14, "[1847 - 1852]");
            WillDates.Add(15, "[1852 - 1857]");
            WillDates.Add(16, "[1857 - 1860]");
            WillDates.Add(17, "[1860 - 1863]");
            WillDates.Add(18, "[1867 - 1867]");
            WillDates.Add(19, "[1867 - 1874]");
            WillDates.Add(20, "[1874 - 1881]");
            #endregion Dictionary Declarations
        }
        public static string GetTitle()
        {
            // returns proper book title to use in the reader.
            String title = "Book ";
            return title;
        }
        public string[] DictionaryKeys(string Validtype)
        {
            string[] BookNames;
            if (Type.CorrectType(Validtype))
            {
                if (Validtype == "Deed")
                {
                    BookNames = new string[DeedDates.Count];
                    for (int i = 0; i < DeedDates.Count; i++)
                    {
                        BookNames[i] = "Book " + (i + 1);

                    }
                    return BookNames;
                }
                if (Validtype == "Will")
                {
                    BookNames = new string[WillDates.Count];
                    for (int i = 0; i < WillDates.Count; i++)
                    {
                        BookNames[i] = "Book " + (i + 1);

                    }
                    return BookNames;
                }
                else
                {
                    BookNames = new string[1];
                    return BookNames;

                }
            }
            else
            {
                return new string[1];
            }

        }
       
    }
}
