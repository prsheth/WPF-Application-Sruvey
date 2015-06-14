/* PersonalInfo.cs
 *getters and setters for personal information
 *
 * Revision History
 * Pranay Sheth, Dewang Patel 04.02.2015: Created
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using SQLite;
using System.IO;
namespace WebSurvey
{
    [Table("PersonalData")]

   public class PersonalInfo : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;

        private bool willingToHelp;
        public string Email { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Program { get; set; }
        public string Institution { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string DuratinInCanada { get; set; }
        public bool Working { get; set; }
        public bool WillingToHelp
        {
            get
            {
                return willingToHelp;
            }
            set
            {
                willingToHelp = value;
                OnPropertyChanged("WillingToHelp");
            }
        }
        public bool LanguageDificulties { get; set; }
        public bool SuppliesDificulties { get; set; }
        public bool AccomodationDificulties { get; set; }
        public bool TravelDificulties { get; set; }
        public bool SocialAdaptationDificulties { get; set; }
        public string Comments { get; set; }
       
        

        public PersonalInfo()
        {
            //do nothing
        }

         protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
