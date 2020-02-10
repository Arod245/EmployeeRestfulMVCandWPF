using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ApiHelper;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            

        }

        public void GetInfo()
        {
            

            
        }


        public async void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            BindingList<Employee> empList;
            Employee emp = new Employee();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/");
            HttpResponseMessage response = await client.GetAsync("api/Employee");
            empList = response.Content.ReadAsAsync<BindingList<Employee>>().Result;
            string result = await response.Content.ReadAsStringAsync();
            foreach (var item in empList) 
            {
                txtName.Text += item.Name;
                txtAge.Text += item.Age.ToString();
                txtPosition.Text += item.Position;
                txtSalary.Text += item.Salary.ToString();
                //ltbText.ItemsSource = item.Name + item.Age;
            }

       
            
        }

        private void btnPostInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text =="")
            {
                txtName.Text = "Put info here";
            }
            else
            {
                Employee emp = new Employee();
                emp.Name = txtName.Text;
                emp.Position = txtPosition.Text;
                emp.Age = int.Parse(txtAge.Text);
                emp.Salary = int.Parse(txtSalary.Text);

                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44345/");
                HttpResponseMessage response = client.PostAsJsonAsync("api/Employee", emp).Result;

                txtName.Clear();
                txtPosition.Clear();
                txtAge.Clear();
                txtSalary.Clear();
            }
        }
    }
}
