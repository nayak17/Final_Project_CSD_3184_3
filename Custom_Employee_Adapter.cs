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
    class Custom_Employee_Adapter : BaseAdapter<Employee>
    {
        // Custom adapter to fill the list view on the main activity
        Activity activity;
        List<Employee> employee_list;

        // Custom adapter constructor to set the list and activity
        public Custom_Employee_Adapter(Activity act, List<Employee> emplist)
        {
            this.activity = act;
            this.employee_list = emplist;
        }
        // override method to get element at position in the list
        public override Employee this[int position]
        {
            get { return employee_list[position]; }
        }
        // override getitemid to return item position
        public override long GetItemId(int position)
        {
            return position;
        }
        // Set the view 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var custom_adapter_view = convertView;
            if (custom_adapter_view == null)
            {
                custom_adapter_view = activity.LayoutInflater.Inflate(Resource.Layout.employee_list_custom, null);
            }
            // Get the employee present at the position and display their information.
            Employee emp = employee_list[position];
            custom_adapter_view.FindViewById<TextView>(Resource.Id.employee_fullname).Text = "Name:    " + emp.Employee_name;
            custom_adapter_view.FindViewById<TextView>(Resource.Id.employee_id).Text = "Id:    " + emp.Employee_id;

            return custom_adapter_view;
        }
        // OVerride count method to return List count;
        public override int Count
        {
            get
            {
                return employee_list.Count;
            }
        }
        // Override GetItem method to get the item present in the list in the form of custom object
        public override Java.Lang.Object GetItem(int position)
        {
            return (Employee)employee_list[position];
        }
    }

    class Custom_Employee_AdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}