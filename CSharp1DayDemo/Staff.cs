using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp1DayDemo
{
    public class Staff
    {
        private float hourlyRate;
        private int hWorked; //hours worked

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
 
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if(value > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        } //backed by hWorked

        /// <summary>
        /// Creates a Staff object with a name and hourly rate
        /// </summary>
        /// <param name="name">name of the staff member</param>
        /// <param name="rate">hourly pay rate of the staff member</param>
        public Staff(string name, float rate)
        {
            this.NameOfStaff = name;
            this.hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            this.BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "Staff member " + this.NameOfStaff + " worked " + this.HoursWorked + " making $" + this.TotalPay; ;
        }

    }
}
