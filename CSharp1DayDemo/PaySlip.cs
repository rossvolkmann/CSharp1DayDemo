using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CSharp1DayDemo
{
    public class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear {JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC} //enums default to being private

        public PaySlip(int month, int year)
        {
            this.month = month;
            this.year = year;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                //the filename to be created for the payslip
                path = f.NameOfStaff + ".txt";

                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year );
                writer.WriteLine("==========================");
                writer.WriteLine("Name of staff: " +f.NameOfStaff);
                writer.WriteLine("Hours worked: " + f.HoursWorked);
                writer.WriteLine("");
                writer.WriteLine("Basic pay: " + f.BasicPay);
                if (f.GetType() == typeof(Manager)) 
                {
                    writer.WriteLine("Allowance: " +((Manager)f).Allowance);
                }else if (f.GetType() == typeof(Admin))
                {
                    writer.WriteLine("Overtime Pay: " + (f.TotalPay - f.BasicPay));
                }
                else
                {
                    Console.WriteLine("WARNING: format exception with Staff " + f.ToString() + ". Staff is not of Admin or Manager type");
                }
                writer.WriteLine("");
                writer.WriteLine("==========================");
                writer.WriteLine("Total pay: " +f.TotalPay);
                writer.WriteLine("==========================");

                writer.Close();
            } 
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                    from f in myStaff
                    where (f.HoursWorked < 10)
                    orderby f.NameOfStaff ascending
                    select new { f.NameOfStaff, f.HoursWorked };

            StreamWriter writer = new StreamWriter("summary.txt");

            writer.WriteLine("Staff with less than 10 working hours");
            writer.WriteLine("");
            foreach(var v in result)
            {
                writer.WriteLine("Name of Staff: " + v.NameOfStaff + ", Hours Worked: " + v.HoursWorked);
            }

            writer.Close();

        }

        public override string ToString()
        {
            return "default PaySlip ToString()";
        }

    }
}
