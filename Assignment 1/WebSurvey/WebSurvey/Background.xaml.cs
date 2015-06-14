/* Background.xaml.cs
 *back end code for the backgorund window *
 * Revision History
 * Pranay Sheth, Dewang Patel 06.02.2015: Created
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
using System.ComponentModel;


namespace WebSurvey
{
    /// <summary>
    /// Interaction logic for Background.xaml
    /// </summary>
    public partial class Background : Window
    {
        PersonalInfo personalInfoObject;
        BackgroundInfo bi;
        Database databaseObject;
        public Background(PersonalInfo personalInfoObject2)
        {
            personalInfoObject = personalInfoObject2;
       
            InitializeComponent();
        }
        public Background()
        {
            InitializeComponent();
        }

       public async void btnNext2(object sender, RoutedEventArgs e)
        {
            await databaseObject.InsertAsync(bi);
            History newWindow = new History(personalInfoObject);
            newWindow.Show();
            this.Close();
        }

        private void tbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ComboBoxItem cbi = tbCountry.SelectedItem as ComboBoxItem;
            if (cbi != null)
                {
                    StackPanel sp = cbi.Content as StackPanel;
                    TextBlock block = sp.Children[1] as TextBlock;
                    bi.CountryOfOrigin = block.Text;
                }
            
       }

        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bi= new BackgroundInfo();
            databaseObject = new Database(Database.GetDatabasePath());
            await databaseObject.Init();
            AsyncTableQuery<BackgroundInfo> atqu2 = databaseObject.Table<BackgroundInfo>();
            List<BackgroundInfo> biObject= await atqu2.ToListAsync();
            this.DataContext = bi;
            bi.Email = personalInfoObject.Email;
        }

      private void btnBack2(object sender, RoutedEventArgs e)
        {
          
            expierence newWindow = new expierence(personalInfoObject);
            newWindow.Show();
            this.Close();
        }

      private void tbfield_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
          var comboBox = sender as ComboBox;

          string value = comboBox.SelectedItem as string;
          bi.FieldOfStudy = value;
          // this.Title = "Selected: " + value;
      }

      private void Combobox_loaded(object sender, RoutedEventArgs e)
      {
          List<string> data = new List<string>();
          data.Add("Information Technology");
          data.Add("Business");
          data.Add("Law");
          data.Add("Science");
          data.Add("Arts");
          data.Add("Medicine");

          var comboBox = sender as ComboBox;

          comboBox.ItemsSource = data;

          comboBox.SelectedIndex = 0;
      }    
    }
}
