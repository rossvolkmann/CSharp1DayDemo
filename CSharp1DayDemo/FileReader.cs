using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharp1DayDemo
{
    class FileReader
    {
        

        /// <summary>
        /// Reads from a .txt file of staff of the format:
        /// Name of Staff, Position of Staff
        /// </summary>
        /// <returns></returns>
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff1.txt";
            char[] separator = {','};
            int lineCount = 0;

            try { 
            using(StreamReader reader = new StreamReader(path))
            {
                    while (!reader.EndOfStream)
                    {
                        string[] nextLine = reader.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if(nextLine.Length != 2)
                        {
                            Console.WriteLine("WARNING: input format not correct at line " +lineCount+ ".  Skipping line.");
                            continue;
                        }
                        result[0] = nextLine[0].Trim();
                        result[1] = nextLine[1].Trim();

                        if (result[1].Equals("Admin"))
                        {
                            myStaff.Add(new Admin(result[0].Trim()));
                        }
                        else if (result[1].Equals("Manager"))
                        {
                            myStaff.Add(new Manager(result[0].Trim()));
                        }
                        else
                        {
                            Console.WriteLine("WARNING: position at line " + lineCount + " not recognized.");
                        }
                        lineCount++;
                    }
                reader.Close();
            }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return myStaff;
        }
        
    }
}
