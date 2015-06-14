/* expierence.xaml.cs
 *back end code for the expierence window
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
using System.Windows.Shapes;
using SQLite;
using System.IO;
using System.Text.RegularExpressions;
namespace WebSurvey
{
    /// <summary>
    /// Interaction logic for expierence.xaml
    /// </summary>
    public partial class expierence : Window
    {
        private PersonalInfo personalInfoObject;
        Database databaseObject;
        public expierence(PersonalInfo personalInfoObject2)
        {
            personalInfoObject = personalInfoObject2;
            InitializeComponent();
        }
        public expierence()
        {
            InitializeComponent();
        }
       public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
          databaseObject =  new Database(Database.GetDatabasePath());
            //await db.Init();
            AsyncTableQuery<PersonalInfo> atqu = databaseObject.Table<PersonalInfo>();
            List<PersonalInfo> personInfo = await atqu.ToListAsync();
            this.DataContext = personalInfoObject;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            personalInfoObject.Working = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            personalInfoObject.Working = false;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            personalInfoObject.WillingToHelp = true;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            personalInfoObject.WillingToHelp = false;
            MessageBox.Show("Ooops! You missed the chance to win a Tim Hortons free voucher, Select yes and stay caffeinated");
        }

        private void btnNext(object sender, RoutedEventArgs e)
        {
            if (tbemail.Text.Length == 0) //email validation using regular expressions
            {
               MessageBox.Show("Enter your email");
                tbemail.Focus();
                return;
            }
            else if (!Regex.IsMatch(tbemail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Enter a valid email");
                tbemail.Select(0, tbemail.Text.Length);
                tbemail.Focus();
                return;
            }
            
            
            
            if (personalInfoObject.WillingToHelp == true)
            {
                MessageBox.Show("Your free Tim Hortons voucher code is 123456*** ");
                Background newWindow = new Background(personalInfoObject);
                newWindow.Show();
            }
            else if(personalInfoObject.WillingToHelp == false)
            {
                History newWindow = new History(personalInfoObject);
                newWindow.Show();
            }
         //   await db.InsertAsync(pi);
            this.Close();
            
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow(personalInfoObject);
            newWindow.Show();
            this.Close();
        }


        private void tbLength_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            string value = comboBox.SelectedItem as string;
            personalInfoObject.DuratinInCanada = value;
           // this.Title = "Selected: " + value;
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("0-6 months");
            data.Add("6 months - 1 year");
            data.Add("1 - 3 years");

            var comboBox = sender as ComboBox;

            comboBox.ItemsSource = data;

            comboBox.SelectedIndex = 0;
        }
    }
}
