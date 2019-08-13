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
    class Motorcycle : Vehicle
    {
        // Private member variables
        private bool motorcycle_sidecar;
        public Motorcycle() { }
        // Parameterized constructor
        // Calls base constructor to set common variables
        public Motorcycle(string make, string plate, string color, string category, bool sidecar) : base(make, plate, color, category)
        {
            this.Motorcycle_sidecar = sidecar;
        }
        // Auto generated Getters and Setters
        public override bool Motorcycle_sidecar { get => motorcycle_sidecar; set => motorcycle_sidecar = value; }
    }
}