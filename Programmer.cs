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
    class Programmer : Employee
    {
        // Private member variables
        private int nbProjects;
        // Private constant member variable to add value into Annual Salary calculation
        private const int GAIN_FACTOR_PROJECTS = 200;

        // Parameterized constructor
        // Calls base constructor to set common variables
        public Programmer(string name, string age, string birthYear, string monthlySalary, string rate, int projects, string id, Vehicle vehicle) : base(name, age, birthYear, monthlySalary, rate, id, vehicle)
        {
            this.NbProjects = projects;
        }
        // Auto generated Getters and Setters
        public int NbProjects { get => nbProjects; set => nbProjects = value; }
        // Annual Income calculation and considering GAIN_FACTOR_PROJECTS
        public override int AnnualIncome { get => base.AnnualIncome + (GAIN_FACTOR_PROJECTS * this.NbProjects); }
        // Override ToDisplay() method and add Programmer specific details
        public override string ToDisplay()
        {
            string employee_details = "";
            employee_details += base.ToDisplay();
            employee_details += "Annual Income: $ " + this.AnnualIncome + "\n";
            employee_details += "He/She has completed " + this.NbProjects + " projects\n";
            return employee_details;
        }
    }
}