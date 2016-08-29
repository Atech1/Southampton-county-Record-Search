using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Record_Searcher
{
    //this class is here to log any errors or strangeness into the text file for it for debugging.
    public class Error
    {
       private static string BasePath;
       static string path;
       static string TxtFileName;
       private static List<string> errors;

        public Error()
        {
            //gets the path info
            TxtFileName = "ErrorLog.txt";
            BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(BasePath, TxtFileName);
        }

        public static void Log(string problem)
        {
            errors = new List<string>();
            //takes any errors that are being logged and adds them to a list of erros that will be logged on closing, unless called sooner.
            errors.Add(problem);
        }

        public void OnClosing()
        {
            //if there is a file at the right path, a writer will write to it.
            if (errors != null)
            {
                if (File.Exists(path))
                {
                    using (StreamWriter writer =
                        new StreamWriter(path))
                    {
                        foreach (string line in errors)
                        {
                            writer.WriteLine(line);
                        }
                        writer.Close();
                    }


                }
                else
                {
                    File.Create(path).Dispose();
                    using (StreamWriter writer =
                       new StreamWriter(path))
                    {
                        writer.WriteLine("This is the Error Log:");
                        foreach (string line in errors)
                        {
                            writer.WriteLine(line);
                        }
                        writer.Close();
                    }

                }
            }
        }
    }
}
