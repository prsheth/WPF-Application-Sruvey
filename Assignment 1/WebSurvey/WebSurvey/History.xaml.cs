/* History.xaml.cs
 *back end code for the history window
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

namespace WebSurvey
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        PersonalInfo personalInfoObject;
        Database databaseObject;
        public History(PersonalInfo personalInfoObject2)
        {
            personalInfoObject = personalInfoObject2;
            InitializeComponent();
        }
        public History()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            databaseObject = new Database(Database.GetDatabasePath());
            //await db.Init();
            AsyncTableQuery<PersonalInfo> atqu = databaseObject.Table<PersonalInfo>();
            List<PersonalInfo> personInfo = await atqu.ToListAsync();
            this.DataContext = personalInfoObject;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            personalInfoObject.LanguageDificulties = true;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            personalInfoObject.SuppliesDificulties = true;
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            personalInfoObject.AccomodationDificulties = true;
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            personalInfoObject.TravelDificulties = true;
        }

        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {
            personalInfoObject.SocialAdaptationDificulties = true;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            personalInfoObject.LanguageDificulties = false;
        }

        private void CheckBox_Unchecked1(object sender, RoutedEventArgs e)
        {
            personalInfoObject.SuppliesDificulties = false;
        }

        private void CheckBox_Unchecked2(object sender, RoutedEventArgs e)
        {
            personalInfoObject.AccomodationDificulties = false;
        }

        private void CheckBox_Unchecked3(object sender, RoutedEventArgs e)
        {
            personalInfoObject.TravelDificulties = false;
        }

        private void CheckBox_Unchecked4(object sender, RoutedEventArgs e)
        {
            personalInfoObject.SocialAdaptationDificulties = false;
        }

        private async void btnSubmit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your free Tim Hortons voucher code is 123456789 ! ");
            MessageBox.Show("Thank you! "+personalInfoObject.Name+" "+"for submitting the survey");
            await databaseObject.InsertAsync(personalInfoObject);
            this.Close();
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            expierence newWindow = new expierence(personalInfoObject);
            newWindow.Show();
            this.Close();
        }

      

      
    }
}
