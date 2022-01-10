using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp1DayDemo
{
    public class Manager:Staff
    {
        private const float managerHourlyRate = 50;

        public int Allowance{get; private set;}

        public Manager(string name) : base(name, managerHourlyRate){}

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if(this.HoursWorked > 160)
            {
                this.TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            return "Manager " + this.NameOfStaff + " worked " + this.HoursWorked + " making $" + this.TotalPay;
        }
    }
}
