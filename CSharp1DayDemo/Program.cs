using System;
using System.Collections.Generic;

namespace CSharp1DayDemo
{
    /// <summary>
    /// This program was taken from the prompts in Learn C# in 1 Day and Learn it Well by Jamie Chan.  I completed it
    /// to orient myself in C# and Visual Studio after nearly a year of Java development for school.  
    /// 
    /// It's a console program that reads names and positions from a .csv file, prompts the user to input information
    /// about their hours worked,and then creates output text files that summarize their pay.  
    /// 
    /// After completing it, I'm going to use it to practice learning git.  
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff;
            FileReader fr;
            int month = -1;
            int year = -1;

            while(year == -1)
            {
                Console.WriteLine("\nPlease enter the year: ");
                try
                {
                    year = Int32.Parse(Console.ReadLine());
                }catch(FormatException e)
                {
                    Console.WriteLine("Please enter the year as an integer.\n");
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while(month == -1)
            {
                Console.WriteLine("\nPlease enter the month: ");
                try
                {
                    month = (Int32.Parse(Console.ReadLine()) - 1);
                    if (month < 0 || month > 11)
                    {
                        month = 0;
                        throw new FormatException();
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter the month as an integer between 1-12.\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            fr = new FileReader(); //update this later to allow for modular text file input
            myStaff = fr.ReadFile();

            for(int i = 0; i < myStaff.Count; i++)
            {
                int hoursWorked = -1;
                try
                {
                    while(hoursWorked == -1) { 
                        Console.WriteLine("Enter hours worked for " + myStaff[i].NameOfStaff);
                        hoursWorked = Int32.Parse(Console.ReadLine());
                        if(hoursWorked < 0)
                        {
                            throw new FormatException();
                        }
                        myStaff[i].HoursWorked = hoursWorked;
                        myStaff[i].CalculatePay();
                        Console.WriteLine(myStaff[i].ToString());

                    }
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    i--; //restart the for loop after a failed read
                }
            }


            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();

        }
    }
}
