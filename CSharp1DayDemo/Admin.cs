using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp1DayDemo
{
    class Admin:Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;

        public float Overtime { get; private set; }

        public Admin(string name):base(name, adminHourlyRate)
        {

        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                TotalPay += overtimeRate * (HoursWorked - 160);
            }
        }

        public override string ToString()
        {
            return "Admin " + this.NameOfStaff + " worked " + this.HoursWorked + " making $" + this.TotalPay;
        }
    }
}
