using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Record_Searcher
{
    //this class is going to hold info on each of the different data types.
   public class Type
    {
        enum ValidType
        {
          //  none,
            Deed,
            Marriage,
            Will,
            
          //  Minute
        }
        private string type;
       
        //
       private static string BasePath;
       
        public Type(String _StartingType)
        {
            type = null;
            BasePath = Program.DirectoryPath;
            IntializeValues(_StartingType);
            if(type == null)
            {
                //problems. probably should implement an error system that can then fit here and fit in any other errors.
            }

        }

        private void IntializeValues(string _StartingType)
        {
            if (CorrectType(_StartingType))
            {
                type = _StartingType;
            }
            else
            {
                Error.Log("Type being created is not the right type. This is what was passed in: " + _StartingType);
                Error error = new Error();
                error.OnClosing();

            }
            
        }

        //Method to change what the current type is. that way there can keep being one Instance of this object to interface with in the UI.
        //Utility should have to create a new instance everytime this is changed though, so that it can always have the current type. 
        //this will be okay because utility should be a class where you can call a bunch of helper functions to simplify other classes,
        //but shouldn't hold any real data.
        public void ChangeType(string _WantedType, out bool Succeeded)
        {
            if(CorrectType(_WantedType))
            {
                this.type = _WantedType;
                Succeeded = true;
            }
            else
            {
                this.type = null; 
                Succeeded = false;
            }

        }
        //method checks to see if the input into it is a valid type, and allowing it to be public so that it can be easily checked from outside the class.
        public static bool CorrectType(string _WantedType)
        {
            ValidType valtype;
           if( Enum.TryParse(_WantedType, out valtype))
           {
               return true;

           }
            

            return false;

        }

        //makes a path that will be fed into the utility functions that will get all the different files in the folder.
        //this will grab the reference to that folder and make this more generic, rather than grabbing specific folders each time that utility function is called.
        public static string GeneratePathsForTypes(string _WantedBasePath)
        {
            if (CorrectType(_WantedBasePath))
            {
                return Path.Combine(BasePath, _WantedBasePath);
            }
            else
            {

                return Path.Combine(BasePath, "Deed");
            }
        }
        public string GetName()
        {
            return this.type;
        }
       public static string[] NumberOfValidTypes()
        {
           
            string[] types = Enum.GetNames(typeof(ValidType)).ToArray();
            return types;
        }
    }
}