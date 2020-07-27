using System;
using System.Collections.Generic;
using System.IO; // namespace that provides the methors for the creation, copying, deletion, moving
using System.Linq; // namespace to use Linq
using System.Text;
using System.Threading.Tasks;
using CSProjectNew.Classes; // to import the Classes for the Application

namespace CSProjectNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PAYSLIP APPLICATION - PROJECT FROM THE BOOK 'LEARNING C# IN ONE DAY'");

            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;


            // 1. USER INPUT TO GET THE YEAR AND MOTH 
            while (year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Please try again.");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\nPlease enter the month (integer): ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("\nInvalid input, month must be an integer value between 1 and 12. Please try again.");
                        month = 0; // set the month value to 0 to go back to the loop.
                    }

                } catch (FormatException e){
                    Console.WriteLine(e.Message + " Please try again.");
                }
            }


            // 2. CALCULATE THE PAY FOR EACH STAFF

            myStaff = fr.ReadFile(); // To get the staff list from the file.

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.Write("Enter hours worked for {0}: ", myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay(); // Calling the method to calculate the pay of that staff
                    Console.WriteLine(myStaff[i].ToString()); // To string method to get and print the Staff object.
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--; // reduce the value so that the for loop will interate again for the current staff object instead of moving on to the next element in myStaff.
                }
            }

            PaySlip ps = new PaySlip(month, year); // creating the Payslip object with the constructor
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read(); // statement to prevent the console from closing immediately after the program ends.


        }
    }
}
