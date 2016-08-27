using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Record_Searcher
{
    //this class is for reading, formatting, and then converting all the files into a in memory set of records.
    class Reader
    {
        List<string> pathes;
        string title;
        public Reader(List<string> Paths, string title)
        {
            pathes = new List<string>();
            this.pathes = Paths;
            this.title = title;

        }
        public List<Records> ConvertToRecord(Type type)
        {
            List<Records> AllRecords = new List<Records>();
            List<string> lines = new List<string>();
            int checks = 0;
            lines = format(lines);
            //reverses the list, so that the current line can be removed if it is invalid
            foreach (string l in lines.Reverse<string>())
            {
                checks += 1;
                if ((!String.IsNullOrWhiteSpace(l)) && (l != ""))
                {
                    string thatline = l;
                    var info = l.Split(',').Select(x => x.Trim()).ToArray();
                    //checks to see if it is a valid record with 3 separate types of info.
                    if (info.Length > 3)
                    {
                        Records record = new Records();
                        //grabs the book title
                        record.Title = info[0];
                        //finds the book number from the book title;
                        record.BookNumber = IsParsed(info[0].Trim('B', 'o', 'k'));
                        //TODO Should make 2 declarations to make a first and last name in each record. from info[1] and info[2] respectfully. As well as keeping
                        // both together in case you just want to search for both.
                        record.FirstName = info[2];  
                        record.LastName = info[1].Trim('+', '*', '^');
                        record.person = info[1] + ", " + info[2];
                        //creates a tag from the name, if the name has one of the tag characters "^, *, +"
                        record.Tag = CreateSpecialTag(info[1]);
                       //makes a list of the pages that are associated with the record of the person
                            record.Pages = info.Skip(3).Select(x => IsParsed(x)).ToList();
                        //gets the book type
                            record.type = type;
                        //adds the record to the list of records.
                            AllRecords.Add(record);
                     
                    }
                    else
                    {
                        //if it is not a valid record in the right format, it is removed from the list of records.
                        lines.Remove(l); 
                    }
                }
            }


            return AllRecords;

        }
        private int Length(String str)
        {
            //checks the length of a string, as a way to keep track of how many files it has gone through already.
            using (StreamReader read = new StreamReader(str))
            {
                int count = 0;
                while (read.ReadLine() != null)
                {

                    count++;
                }

                return count;
            }



        }
        private List<string> format(List<string> recordlist)
        {
           
            for(int r = 0; r < pathes.Count; r++)
            {
                //takes the base title and adds the right book number to it.
                string _title;
                _title = title + (r + 1);
                string path = pathes[r];
            
                if (File.Exists(path))
                {
                    using (StreamReader read = new StreamReader(path))
                    {
                        
                        int count = Length(path);
                        string[] lines = new string[count + 1];
                        for (int i = 0; i < count; i++)
                        {
                            lines[i] = read.ReadLine();
                            String line = lines[i].Trim();
                            var parts = line.Split(',');
                            if (!String.IsNullOrWhiteSpace(line))
                            {
                                //checks to see if it is a number that is the opening of a line.
                                if (IsParsed(parts[0]) == 0)
                                {
                                    //if is not a number, it adds the line and the title to the list going to be turned into a record.
                                    lines[i] = _title + ", " + line;
                                    line = null;
                                }
                                else
                                {
                                    // if it is not, logic to format it into having a name rather than a number first
                                    for (int j = 1; j < count - 1; j++)
                                    {
                                        //looks for the last line that had a name, rather than a number first.
                                        if (lines[i - j] != null)
                                        {

                                       
                                            String temp = lines[i - j];
                                            var p = temp.Split(',');
                                            // takes that last line that was right, and takes the current line, and then adds the current line to the last line.
                                            if (IsParsed(p[0]) == 0)
                                            {
                                                lines[i - j] = lines[i - j] + " " + line;
                                                temp = null;
                                                lines[i] = null;
                                             
                                                break;
                                            }
                                                //sets the line it took the info from to null, so that it knows that line is not a line to add stuff to.
                                            else
                                            {
                                                temp = null;
                                                lines[i - j] = null;
                                            }
                                        }
                                    }
                                }

                            }

                        }

                        foreach (string l in lines)
                        {
                      //finally adds the correct list to the list of books to be turned into a list of records.
                            recordlist.Add(l);

                        }
                    }
                   

                }
            }
            return recordlist;
        }
        private int IsParsed(string n)
        {
            int num = 0;
            // this is to check to see if the string number coming in is a valid int. and then it will return if it is.
            if(int.TryParse(n, out num))
            {
                return num;
            }
            else
            {
                //returns 0 because a record cannot have a 0th page and so makes sense to track invalid number inputs by if it is 0.
                return 0;
            }
        }
        private string CreateSpecialTag(string last_name)
        {
            //creates tages of all the special characters to represent the various group tags below.
            if(last_name.Contains('+'))
            {
                return "[African] ";
            }
            else if(last_name.Contains('*'))
            {
                return "[Location] ";
            }
            else if (last_name.Contains('^'))
            {
                return "[Indian] ";
            }

            return " ";
        }
      
    }
}

