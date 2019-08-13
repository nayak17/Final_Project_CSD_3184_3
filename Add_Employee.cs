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
    [Activity(Label = "Add_Employee")]
    public class Add_Employee : Activity
    {
        
        // All variavle declaration used on the main layout page where we add a new Employee.
        EditText employee_fName;
        EditText employee_lName;
        EditText employee_bYear;
        EditText employee_mSalary;
        EditText employee_oRate;
        EditText employee_id;
        Spinner employee_type;
        LinearLayout layout_line8;
        TextView numbers_textview;
        EditText numbers_value;
        RadioGroup vehicle_radio_group;
        RadioButton vehicle_car_radio;
        RadioButton vehicle_motorcycle_radio;
        LinearLayout layout_line10;
        RadioGroup sidecar_radio_group;
        RadioButton sidecar_yes_radio;
        RadioButton sidecar_no_radio;
        LinearLayout layout_line11;
        EditText cartype;
        EditText vehicle_model;
        EditText plate_number;
        Spinner vehicle_color;
        Button employee_reg;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.employee_add);
            
            // Here it fill all the elements which are present on the layout, This is the Creation of Application

            employee_fName = FindViewById<EditText>(Resource.Id.employee_fname);
            employee_lName = FindViewById<EditText>(Resource.Id.employee_lname);
            employee_bYear = FindViewById<EditText>(Resource.Id.employee_byear);
            employee_mSalary = FindViewById<EditText>(Resource.Id.employee_msalary);
            employee_oRate = FindViewById<EditText>(Resource.Id.employee_orate);
            employee_id = FindViewById<EditText>(Resource.Id.employeeid);

            employee_type = FindViewById<Spinner>(Resource.Id.employee_type);

            layout_line8 = FindViewById<LinearLayout>(Resource.Id.layout_line8);
            numbers_textview = FindViewById<TextView>(Resource.Id.numbers_textview);
            numbers_value = FindViewById<EditText>(Resource.Id.numbers_value);


            // layout_line8 will not be visible on the launch, but when  employee type will be selected it will be appear on the screen.
            // viewstate is set to Gone which is for not to show at start.
            layout_line8.Visibility = ViewStates.Gone;


            employee_type.ItemSelected += Employee_type_ItemSelected;

            vehicle_radio_group = FindViewById<RadioGroup>(Resource.Id.vehicle_radio_group);
            vehicle_car_radio = FindViewById<RadioButton>(Resource.Id.vehicle_car_radio);
            vehicle_motorcycle_radio = FindViewById<RadioButton>(Resource.Id.vehicle_motorcycle_radio);

            layout_line10 = FindViewById<LinearLayout>(Resource.Id.layout_line10);
            sidecar_radio_group = FindViewById<RadioGroup>(Resource.Id.sidecar_radio_group);
            sidecar_yes_radio = FindViewById<RadioButton>(Resource.Id.sidecar_yes_radio);
            sidecar_no_radio = FindViewById<RadioButton>(Resource.Id.sidecar_no_radio);

            layout_line11 = FindViewById<LinearLayout>(Resource.Id.layout_line11);
            cartype = FindViewById<EditText>(Resource.Id.cartype);


          
            //These two are based on the user selection. If it is car then it eill be edit text.
            //If it is radio button, it will come up with redio button group for selection yes or no.
            //Both layouts for car and moterbike are set to Gone initially as it will appear after perticular option selection.
            layout_line10.Visibility = ViewStates.Gone;
            layout_line11.Visibility = ViewStates.Gone;
           
            
            // When any of the radio buttons has been selected, it will check if the selection was Car or Motorcycle
            // The function being called will either view Car type layout or Motorcycle side car layout
            vehicle_radio_group.CheckedChange += Vehicle_radio_group_Click;

            vehicle_model = FindViewById<EditText>(Resource.Id.vehicle_model);
            plate_number = FindViewById<EditText>(Resource.Id.plate_number);
            vehicle_color = FindViewById<Spinner>(Resource.Id.vehicle_color);

            employee_reg = FindViewById<Button>(Resource.Id.employee_reg);




            // Define what happens when the register button is clicked
            employee_reg.Click += delegate
            {
                // Check if all the fields are added correctly, otherwise return and show toast that the field entry is missing
                if(employee_fName.Text.Equals("") || employee_lName.Text.Equals("") || employee_bYear.Text.Equals("") || employee_mSalary.Text.Equals("")
                    || employee_oRate.Text.Equals("") || employee_id.Text.Equals("") || employee_type.SelectedItem.ToString() == "Choose a type"
                    || numbers_value.Text.Equals("") || vehicle_model.Text.Equals("") || plate_number.Text.Equals("") 
                    || vehicle_color.SelectedItem.ToString() == "Choose a color")
                {
                    // Show the error about missing fields on the page.
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Missing Fields");
                    alert.SetMessage("You have to fill all the fields to register.");
                    alert.SetPositiveButton("Ok", (senderAlert, args) => {
                        
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
                else
                {
                    // Now that all the visible fields are verified, we need to validate fields being shown after certain selections
                    // Like car type and motorcycle side car layout
                    if(vehicle_car_radio.Checked)
                    {
                        // If vehicle type has been selected as Car
                        if(cartype.Text.Equals(""))
                        {
                            // Show the error that fields are missing
                            AlertDialog.Builder alert = new AlertDialog.Builder(this);
                            alert.SetTitle("Missing Car Type");
                            alert.SetMessage("You have to fill car type to register.");
                            alert.SetPositiveButton("Ok", (senderAlert, args) => {

                            });
                            Dialog dialog = alert.Create();
                            dialog.Show();
                            return;
                        }
                    } else if(vehicle_motorcycle_radio.Checked)
                    {
                        // IF vehicle type has been selected as Motorcycle
                        if(!sidecar_yes_radio.Checked && !sidecar_no_radio.Checked)
                        {
                            // If both radio buttons are unchecked, show error
                            AlertDialog.Builder alert = new AlertDialog.Builder(this);
                            alert.SetTitle("Missing Side Car");
                            alert.SetMessage("You have to select one of the side car options to register.");
                            alert.SetPositiveButton("Ok", (senderAlert, args) => {

                            });
                            Dialog dialog = alert.Create();
                            dialog.Show();
                            return;
                        }
                    }

                    if (int.Parse(employee_bYear.Text) < 1900 || int.Parse(employee_bYear.Text) > int.Parse(DateTime.Now.Year.ToString()))
                    {
                        // birth year can not be less than 1900 and can not be greater than current year
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                        alert.SetTitle("Invalid Birth Year");
                        alert.SetMessage("Employee birth year should be between 1900 and " + DateTime.Now.Year.ToString());
                        alert.SetPositiveButton("Ok", (senderAlert, args) => {

                        });
                        Dialog dialog = alert.Create();
                        dialog.Show();
                        return;
                    }

                    if (int.Parse(employee_oRate.Text) < 10)
                    {
                        // If occupation rate is less than 10, set it back to 10
                        Toast.MakeText(this, "Occupation rate can not be less than 10. Changing it to minimum 10", ToastLength.Short).Show();
                        employee_oRate.Text = "10";
                    } else if (int.Parse(employee_oRate.Text) > 100)
                    {
                        // If occupation rate is greater than 100, set it back to 100
                        Toast.MakeText(this, "Occupation rate can not be greater than 100. Changing it to maximum 100", ToastLength.Short).Show();
                        employee_oRate.Text = "100";
                    }

                    // Check if the employee id already present in the static list or not
                    for(int i = 0; i < Employee.employees.Count; i++)
                    {
                        if(Employee.employees[i].Employee_id == employee_id.Text)
                        {
                            // Employee ID already present. Show error
                            AlertDialog.Builder alert = new AlertDialog.Builder(this);
                            alert.SetTitle("Duplicate Employee ID");
                            alert.SetMessage("Duplicate employee id entered. Enter unique employee id.");
                            alert.SetPositiveButton("Ok", (senderAlert, args) => {

                            });
                            Dialog dialog = alert.Create();
                            dialog.Show();
                            return;
                        }
                    }

                    Employee employee = new Employee();
                    Vehicle vehicle = new Vehicle();

                    if(vehicle_car_radio.Checked)
                    {
                        // Means, employee has a car, prepare Car object
                        vehicle = new Car(vehicle_model.Text, plate_number.Text, vehicle_color.SelectedItem.ToString(), "car", cartype.Text);
                    } else
                    {
                        // Otherwise, employee has a motorcycle, prepare a Motorcycle object
                        // Check if side car is present
                        bool sidecar_present = false;
                        if (sidecar_yes_radio.Checked)
                            sidecar_present = true;
                        vehicle = new Motorcycle(vehicle_model.Text, plate_number.Text, vehicle_color.SelectedItem.ToString(), "motorcycle", sidecar_present);
                    }

                    // We need full name of the employee, and current age
                    string employee_fullname = employee_fName.Text + " " + employee_lName.Text;
                    int employee_age = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(employee_bYear.Text);
                   
                    // Based on employee type selection, create an employee object
                    if(employee_type.SelectedItem.ToString() == "Manager")
                    {
                        // Create a Manager object
                        employee = new Manager(employee_fullname, employee_age.ToString(), employee_bYear.Text, 
                                                employee_mSalary.Text, employee_oRate.Text, int.Parse(numbers_value.Text), 
                                                employee_id.Text, vehicle);
                    } else if(employee_type.SelectedItem.ToString() == "Tester")
                    {
                        // Create a Tester object
                        employee = new Tester(employee_fullname, employee_age.ToString(), employee_bYear.Text,
                                                employee_mSalary.Text, employee_oRate.Text, int.Parse(numbers_value.Text),
                                                employee_id.Text, vehicle);
                    } else
                    {
                        // Create a Programmer object
                        employee = new Programmer(employee_fullname, employee_age.ToString(), employee_bYear.Text,
                                                employee_mSalary.Text, employee_oRate.Text, int.Parse(numbers_value.Text),
                                                employee_id.Text, vehicle);
                    }

                    Employee.employees.Add(employee);
                    // Employee Added Successfully

                    AlertDialog.Builder alert2 = new AlertDialog.Builder(this);
                    alert2.SetTitle("Employee Registered");
                    alert2.SetMessage(employee_fullname + " has been registered.");
                    alert2.SetPositiveButton("Ok", (senderAlert, args) => {
                        Finish();
                    });
                    Dialog dialog2 = alert2.Create();
                    dialog2.Show();
                }
            };
        }

        private void Vehicle_radio_group_Click(object sender, EventArgs e)
        {
            if(vehicle_car_radio.Checked)
            {
                layout_line10.Visibility = ViewStates.Gone;
                layout_line11.Visibility = ViewStates.Visible;
            }

            else if (vehicle_motorcycle_radio.Checked)
            {
                layout_line11.Visibility = ViewStates.Gone;
                layout_line10.Visibility = ViewStates.Visible;
            }
            else
            {
                layout_line10.Visibility = ViewStates.Gone;
                layout_line11.Visibility = ViewStates.Gone;
            }
        }

        private void Employee_type_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if(employee_type.SelectedItem.ToString() == "Manager")
            {
                //This makes Line 8 visible when it is selected with any of the option. here manager
                layout_line8.Visibility = ViewStates.Visible;
                numbers_textview.Text = "# of Clients";
                numbers_value.Hint = "# of Clients";
            } else if (employee_type.SelectedItem.ToString() == "Programmer")
            {
                //This makes Line 8 visible when it is selected with any of the option. here programmer
                layout_line8.Visibility = ViewStates.Visible;
                numbers_textview.Text = "# of Projects";
                numbers_value.Hint = "# of Projects";
            } else if (employee_type.SelectedItem.ToString() == "Tester")
            {
                //This makes Line 8 visible when it is selected with any of the option. here tester
                layout_line8.Visibility = ViewStates.Visible;
                numbers_textview.Text = "# of Bugs";
                numbers_value.Hint = "# of Bugs";
            } else
            {
                layout_line8.Visibility = ViewStates.Gone;
            }
        }
    }
}