/* MainWindow.xaml.cs
 *back end code for the main window
 *
 * Revision History
 * Pranay Sheth, Dewang Patel 04.02.2015: Created
 */ 




using System;
using System.Collections.Generic;
using System.Linq;
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
using SQLite;
using System.IO;


namespace WebSurvey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonalInfo personalInfoObject;
        Database databaseObject;
        public MainWindow(PersonalInfo personalInfoObject2)
        {
            personalInfoObject2 = personalInfoObject;
            InitializeComponent();
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public async void  Window_Loaded(object sender, RoutedEventArgs e)
        {
            personalInfoObject = new PersonalInfo();
            this.DataContext = personalInfoObject;
            databaseObject = new Database(Database.GetDatabasePath());
            await databaseObject.Init();
            AsyncTableQuery<PersonalInfo> atqu = databaseObject.Table<PersonalInfo>();
            List<PersonalInfo> personInfo = await atqu.ToListAsync();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            personalInfoObject.Gender = "Male";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            personalInfoObject.Gender = "Female";
        }

        private  void btnNext(object sender, RoutedEventArgs e)
        {
            
            
            if (personalInfoObject.Name == null  || ( personalInfoObject.Name.All(c => Char.IsLetter(c))==false)) //validation for name of user using Linq
            {
                MessageBox.Show("Please enter a valid Name");
            }
            else
            {
                MessageBox.Show("Your free Tim Hortons voucher code is 123****** ");
                expierence newWindow = new expierence(personalInfoObject);
                newWindow.Show();

                //await db.InsertAsync(pi);
                this.Close();
            }
        }

        private void tbProvince_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            string value = comboBox.SelectedItem as string;
            //this.Title = "Selected: " + value;
        }
        private void ComboBox_loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Alberta");
            data.Add("British Columbia");
            data.Add("Manitoba");
            data.Add("New Brunswick");
            data.Add("Newfoundland and Labrador");
            data.Add("Nova Scotia");
            data.Add("Ontario");
            data.Add("Prince Edward Island");
            data.Add("Quebec");
            data.Add("Saskatchewan");
            data.Add("Northwest Territories");
            data.Add("Nunavut");
            data.Add("Yakun");
            

            var comboBox = sender as ComboBox;

            comboBox.ItemsSource = data;

            comboBox.SelectedIndex = 0;
        }
    }
}
