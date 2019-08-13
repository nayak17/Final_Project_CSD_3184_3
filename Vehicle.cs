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
    class Vehicle
    {
        // Private member variables
        private string vehicle_make;
        private string vehicle_plate;
        private string vehicle_color;
        private string vehicle_category;

        public Vehicle()
        {
            // Default constructor
        }
        // Parameterized constructor
        public Vehicle(string make, string plate, string color, string category)
        {
            this.Vehicle_make = make;
            this.Vehicle_plate = plate;
            this.Vehicle_color = color;
            this.Vehicle_category = category;
        }
        // Auto generated Getters and Setters
        public string Vehicle_make { get => vehicle_make; set => vehicle_make = value; }
        public string Vehicle_plate { get => vehicle_plate; set => vehicle_plate = value; }
        public string Vehicle_color { get => vehicle_color; set => vehicle_color = value; }
        public string Vehicle_category { get => vehicle_category; set => vehicle_category = value; }
        // Virtual methods which are to be inherited by derived classes and overridden
        public virtual string Car_type { get; set; }
        public virtual bool Motorcycle_sidecar { get; set; }
    }
}