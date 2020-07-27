using System;
using System.Collections.Generic;
using System.IO; // namespace that provides the methors for the creation, copying, deletion, moving
using System.Linq; // namespace to use Linq

namespace CSProjectNew.Classes
{
    public class PaySlip
    {

        #region Fields

        private int month;
        private int year;

        #endregion

        #region Enum

        // NOTE: No need to specify access modifiers, an enum declared inside a class is private by default

        enum MonthsOfYear { JAN = 1, FEB = 2, MAR = 3, APR = 4, MAY = 5, JUN = 6, JUL = 7, AGO = 8, SEP = 9, OCT = 10, NOV = 11, DEC = 12 }

        // NOTE: No need to assign values to all months since they are in crescent order and its auto increment (just like Excel)
        //enum MonthsOfYear { JAN = 1, FEB = 2, MAR = 3, APR, MAY, JUN, JUL, AGO, SEP, OCT, NOV, DEC }

        #endregion

        #region Constructor

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        #endregion

        #region Methods

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path; // variable to hold the text file name

            foreach (Staff staff in myStaff)
            {
                path = staff.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("===============================");
                    sw.WriteLine("Name of Staff: {0}", staff.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", staff.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", staff.BasicPay); // C specifier to display in currency notation
                    if (staff.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowance: {0}", ((Manager)staff).Allowance); // To access the Allowance Property in the Manager class we need to cast staff into a Manager object
                    }
                    if (staff.GetType() == typeof(Admin))
                    {
                        sw.WriteLine("Overtime Pay: {0}", ((Admin)staff).Overtime); // To access the Overtime Pay Property in the Admin class we need to cast staff into a Admin object
                    }
                    sw.WriteLine("");
                    sw.WriteLine("===============================");
                    sw.WriteLine("Total Pay: {0}", staff.TotalPay);
                    sw.WriteLine("===============================");

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new { staff.NameOfStaff, staff.HoursWorked };

            string path = "summary.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Staff with less then 10 working hours: \n");

                foreach(var staff in result)
                {
                    writer.WriteLine("Name of Staff: {0}, Hours Worked: {1}", staff.NameOfStaff, staff.HoursWorked);
                }

                writer.Close();

            }
        }

        public override string ToString()
        {
            return "month = " + month + "year = " + year;
        }

        #endregion
    }
}
