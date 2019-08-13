using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobDev_Project
{
    class Tester : Employee
    {
        // Private member variables
        private int nbBugs;
        // Private constant member variable to add value into Annual Salary calculation
        private const int GAIN_FACTOR_ERROR = 10;

        // Parameterized constructor
        // Calls base constructor to set common variables
        public Tester(string name, string age, string birthYear, string monthlySalary, string rate, int bugs, string id, Vehicle vehicle) : base(name, age, birthYear, monthlySalary, rate, id, vehicle)
        {
            this.NbBugs = bugs;
        }
        // Auto generated Getters and Setters
        public int NbBugs { get => nbBugs; set => nbBugs = value; }
        // Annual Income calculation and considering GAIN_FACTOR_ERROR
        public override int AnnualIncome { get => base.AnnualIncome + (GAIN_FACTOR_ERROR * this.NbBugs); }
        // Override ToDisplay() method and add Tester specific details
        public override string ToDisplay()
        {
            string employee_details = "";
            employee_details += base.ToDisplay();
            employee_details += "Annual Income: $ " + this.AnnualIncome + "\n";
            employee_details += "He/She has corrected " + this.NbBugs + " bugs\n";
            return employee_details;
        }
    }
}