using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Jarvis_Dummy.Model
{
    public class GetJarvisInfo
    {
        [Key]
        public string UEN { get; set; } // 196900049H
        public string BusinessName { get; set; } // Makino Asia Pvt Ltd
        public string BusinessRegisteredAddress { get; set; }     // 48 Pandan Road, Singapore 602289
        public string LegalEntity { get; set; }  // Local Company       
        public int BBA_PostalCode { get; set; }
        public string BBA_Country { get; set; }
        public int BBA_BlockNumber { get; set; }
        public string BBA_StreetName { get; set; }
        public string BBA_BuildingName { get; set; }
        public int BBA_LevelNumber { get; set; }
        public int BBA_UnitNumber { get; set; }
        public int BMA_PostalCode { get; set; }
        public string BMA_Country { get; set; }
        public int BMA_BlockNumber { get; set; }
        public string BMA_StreetName { get; set; }
        public string BMA_BuildingName { get; set; }
        public int BMA_LevelNumber { get; set; }
        public int BMA_UnitNumber { get; set; }
        public string SingpassID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string OfficeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool EmailNotification { get; set; }

        public bool SMSNotification { get; set; }


    }
}


//{
//    "uen": "196900049H",
//  "businessName": "Makino Asia Pvt Ltd",
//  "businessRegisteredAddress": "48 Pandan Road, Singapore 602289",
//  "legalEntity": "Local Company"
//}