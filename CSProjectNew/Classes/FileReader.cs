using System;
using System.Collections.Generic;
using System.IO; // namespace that provides the methors for the creation, copying, deletion, moving

namespace CSProjectNew
{
    public class FileReader
    {

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path)){

                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream) // to go through the entire stream
                    {
                        //Console.WriteLine(reader.ReadLine()); // to console the line from the reader

                        result = reader.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        //result[0] = name and result[1] = position

                        if (result[1] == "Manager")
                        {
                            myStaff.Add(new Manager(result[0])); // to create the manager object and add to the myStaff list
                        }
                        if (result[1]== "Admin")
                        {
                            myStaff.Add(new Admin(result[0])); // to create the admin object and add to the myStaff list
                        }
                    }
                    reader.Close();
                }
            }
            else
            {
                Console.WriteLine("Error: File does not exist.");
            }

            return myStaff; // to return the file object
        }
    }
}
