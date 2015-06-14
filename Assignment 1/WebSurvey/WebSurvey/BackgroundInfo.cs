/* BackgroundInfo.cs
 *getter and setter for background information
 *
 * Revision History
 * Pranay Sheth, Dewang Patel 06.02.2015: Created
 */ 






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System.ComponentModel;


namespace WebSurvey
{
   [Table("Background")]
    
   class BackgroundInfo
    {
        public string CountryOfOrigin { get; set; }
        public string City { get; set; }
        public string FieldOfStudy { get; set; }
        public string Qualification { get; set; }
        public string Email { get; set; }
        public BackgroundInfo()
        {
            //do nothing
        }
    }
    
}
