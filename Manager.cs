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
    class Manager : Employee
    {
        // Private member variables
        private int nbClients;
        // Private constant member variables to add values into Annual Salary calculation
        private const int GAIN_FACTOR_CLIENT = 500;
        private const int GAIN_FACTOR_TRAVEL = 100;

        // Parameterized constructor
        // Calls base constructor to set common variables
        public Manager(string name, string age, string birthYear, string monthlySalary, string rate, int clients, string id, Vehicle vehicle) : base(name, age, birthYear, monthlySalary, rate, id, vehicle)
        {
            this.NbClients = clients;
        }

        // Auto generated Getters and Setters
        public int NbClients { get => nbClients; set => nbClients = value; }
        // Annual Income calculation and considering GAIN_FACTOR_CLIENT and GAIN_FACTOR_TRAVEL
        // Our project description doesn't specify the usage of GAIN_FACTOR_TRAVEL so we're keeping 0 as of now.
        public override int AnnualIncome { get => base.AnnualIncome + (GAIN_FACTOR_CLIENT * this.NbClients) + (GAIN_FACTOR_TRAVEL * 0); }
        // Override ToDisplay() method and add Manager specific details
        public override string ToDisplay()
        {
            string employee_details = "";
            employee_details += base.ToDisplay();
            employee_details += "Annual Income: $ " + this.AnnualIncome + "\n";
            employee_details += "He/She has brought " + this.NbClients + " new clients\n";
            return employee_details;
        }
    }
}