using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace MobDev_Project
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button employee_add;
        ListView employee_list;
        SearchView employee_search;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Find all the resources located on the layout
            // Add button, search view, and list view
            employee_add = FindViewById<Button>(Resource.Id.employee_add);
            employee_list = FindViewById<ListView>(Resource.Id.employee_list);
            employee_search = FindViewById<SearchView>(Resource.Id.employee_search);
            // Set list adapter to view all employees in proper manner
            var employee_adapter = new Custom_Employee_Adapter(this, Employee.employees);
            employee_list.Adapter = employee_adapter;

            // Define what happens when user tries to search 
            employee_search.QueryTextChange += (s, e) =>
            {
                List<Employee> search_update = new List<Employee>();
                for(int i = 0; i < Employee.employees.Count; i++)
                {
                    if(Employee.employees[i].Employee_name.ToLower().Contains(e.NewText))
                    {
                        search_update.Add(Employee.employees[i]);
                    }
                }
                employee_adapter = new Custom_Employee_Adapter(this, search_update);
                employee_list.Adapter = employee_adapter;
            };

            // Define what happens when user clicks on any item in the list
            employee_list.ItemClick += (s, e) =>
            {
                Employee employee = (Employee)employee_list.Adapter.GetItem(e.Position);
                Intent employee_info = new Intent(this, typeof(EmployeeInfo));
                employee_info.PutExtra("employee_id", employee.Employee_id);
                StartActivity(employee_info);
            };

            // Define what happens when user clicks on ADD button
            employee_add.Click += (s, e) =>
            {
                Intent add_employee = new Intent(this, typeof(Add_Employee));
                StartActivity(add_employee);
            };
        }

        // OnResume override to make sure the listview is updated with latest employee list
        protected override void OnResume()
        {
            base.OnResume();
            // Clear the search bar on resume
            employee_search.SetQuery("", false);
            // Update the adapter with latest employee list
            var employee_adapter = new Custom_Employee_Adapter(this, Employee.employees);
            employee_list.Adapter = employee_adapter;
        }
    }
}