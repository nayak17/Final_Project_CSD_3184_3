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
    [Activity(Label = "EmployeeInfo")]
    public class EmployeeInfo : Activity
    {
        TextView employee_info;
        string employee_id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.employee_info);
            employee_id = Intent.GetStringExtra("employee_id");
            // Create your application here
            employee_info = FindViewById<TextView>(Resource.Id.employee_info);
            // Check all the employees in the static list to find the one with
            // same id as passed to this activity
            // Once found, use ToDisplay() method to display the details
            foreach(Employee employee in Employee.employees)
            {
                if(employee.Employee_id == employee_id)
                {
                    employee_info.Text = employee.ToDisplay();
                }
            }
        }
    }
}