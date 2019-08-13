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
    class Car : Vehicle
    {
        // Private member variables
        private string car_type;
        public Car() { }
        // Parameterized constructor
        // Calls base constructor to set common variables
        public Car(string make, string plate, string color, string category, string type) : base(make, plate, color, category)
        {
            this.Car_type = type;
        }
        // Auto generated Getters and Setters
        public override string Car_type {
            get => car_type;
            set => car_type = value; }
    }
}