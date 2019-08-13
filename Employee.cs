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
    class Employee : Java.Lang.Object
    {
        // Private member variables
        private string employee_name;
        private string employee_age;
        private string employee_birthYear;
        private string employee_monthlySalary;
        private string employee_rate;
        private string employee_id;
        private Vehicle employee_vehicle = new Vehicle(); 
        
        
        // Public static member variable to store all the employees

        public static List<Employee> employees = new List<Employee>();
        private Car employee_car = new Car();
        private Motorcycle employee_motorcycle = new Motorcycle(); 

        public Employee()
        {
            // Default contrustor
        }
        // Parameterized constructor 
        public Employee(string name, string age, string birthYear, string monthlySalary, string rate, string id, Vehicle vehicle)
        {
            this.Employee_name = name;
            this.Employee_age = age;
            this.Employee_birthYear = birthYear;
            this.Employee_monthlySalary = monthlySalary;
            this.Employee_rate = rate;
            this.Employee_id = id;
            if (vehicle.Vehicle_category == "car")
            {
                this.Employee_vehicle.Vehicle_category = "car";
                this.employee_car = new Car(vehicle.Vehicle_make, vehicle.Vehicle_plate, vehicle.Vehicle_color, vehicle.Vehicle_category, vehicle.Car_type);
            }
            else
            {
                this.Employee_vehicle.Vehicle_category = "motorcycle";
                this.employee_motorcycle = new Motorcycle(vehicle.Vehicle_make, vehicle.Vehicle_plate, vehicle.Vehicle_color, vehicle.Vehicle_category, vehicle.Motorcycle_sidecar);
            }
        }
        // Auto generated Getters and Setters for private members
        public string Employee_name {
            get => employee_name;
            set => employee_name = value;
        }
        public string Employee_age {
            get => employee_age;
            set => employee_age = value;
        }
        public string Employee_birthYear {
            get => employee_birthYear;
            set => employee_birthYear = value;
        }
        public string Employee_monthlySalary {
            get => employee_monthlySalary;
            set => employee_monthlySalary = value;
        }
        public string Employee_rate {
            get => employee_rate;
            set => employee_rate = value;
        }
        public string Employee_id {
            get => employee_id;
            set => employee_id = value;
        }
        internal Vehicle Employee_vehicle {
            get => employee_vehicle;
            set => employee_vehicle = value;
        }
        public virtual int AnnualIncome {
            get => (((int.Parse(this.Employee_monthlySalary) * 12) * int.Parse(this.Employee_rate)) / 100); }
       
        
        // ToDisplay() method to display employee details
        // Method will be overridden by inherited classes to add new value in the output string
        public virtual string ToDisplay()
        {
            string employee_details = "";
            string employee_type = "";
            string vehicle_type = "";
            // Check if the type of current object matches type of Manager class,
            // Programmer class, or Tester class.
            if (this.GetType() == typeof(Manager))
                employee_type = "Manager";
            else if (this.GetType() == typeof(Tester))
                employee_type = "Tester";
            else
                employee_type = "Programmer";

            // Check if the type of vehicle object matches type of Car class,
            // or Motorcycle class
            if (this.Employee_vehicle.Vehicle_category == "car")
                vehicle_type = "Car";
            else
                vehicle_type = "Motorcycle";

            employee_details += "Name: " + this.Employee_name;
            employee_details += ", a " + employee_type + "\n";
            employee_details += "Age: " + this.Employee_age + "\n";
            
            if (vehicle_type == "Car")
            {
                // If employee has a car - print car type
                employee_details += "Employee has a " + vehicle_type + "\n";
                employee_details += "    - Model: " + this.employee_car.Vehicle_make + "\n";
                employee_details += "    - Plate: " + this.employee_car.Vehicle_plate + "\n";
                employee_details += "    - Color: " + this.employee_car.Vehicle_color + "\n";
                employee_details += "    - Type: " + this.employee_car.Car_type + "\n";
            }
            else
            {
                // If employee has a motorcycle, check for the side car and output appropriate message
                employee_details += "Employee has a " + vehicle_type + "\n";
                employee_details += "    - Model: " + this.employee_motorcycle.Vehicle_make + "\n";
                employee_details += "    - Plate: " + this.employee_motorcycle.Vehicle_plate + "\n";
                employee_details += "    - Color: " + this.employee_motorcycle.Vehicle_color + "\n";
                if (this.employee_motorcycle.Motorcycle_sidecar)
                {
                    employee_details += "    - with a side car\n";
                }
                else
                {
                    employee_details += "    - without a side car\n";
                }
            }
            employee_details += "Occupation Rate: " + this.Employee_rate + "%\n";
            return employee_details;
        }
    }
}