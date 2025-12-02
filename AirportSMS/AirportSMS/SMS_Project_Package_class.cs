using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirportSMS
{
    public class SMS_Project_Package_class
    {

        // ---------- Models ----------
        public class Manifest
        {
            public string FormatVersion { get; set; } = "1.0";
            public string CreatedBy { get; set; } = "github.com/ajayyadavay";
            public DateTime CreatedOn { get; set; }
            public List<string> Sections { get; set; } = new List<string>();
            public List<string> Required { get; set; } = new List<string>();
        }

        public class SMSProject
        {
            public string ProjectName { get; set; }
            public string ProjectId { get; set; } = Guid.NewGuid().ToString();
            public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
            public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
            // any high-level metadata; new fields may be added later
        }

        public class SPI
        {
            //selecting SPIs
            public bool IsRelatedToObjective { get; set; }
            public bool IsBasedOnDateAndMeasurement { get; set; }
            public bool IsSpecificQuantifiable { get; set; }
            public bool IsRealistic { get; set; }

            //SPIs info
            public string SPI_Id { get; set; }
            public string SPI_Name { get; set; }
            public string SPI_Value_Prev_Obs { get; set; }
            public string SPI_Value_Curr_Target { get; set; }
            public string SPI_Value_Curr_obs { get; set; }

            //Defining SPIs
            public string SPI_Type { get; set; }
            public string SPI_Des { get; set; }
            public string SPI_Manage { get; set; }
            public string SPI_Inform { get; set; }
            public string SPI_Unit { get; set; }
            public string SPI_Calc { get; set; }
          
            //SPIs data
            public double[] PrevYearObserved { get; set; } = new double[13];
            public double[] CurrYearTargetPercent { get; set; } = new double[13];
            public double[] CurrYearTargetValue { get; set; } = new double[13];
            public double[] CurrYearObserved { get; set; } = new double[13];
            
            // Add new properties in future; unknown properties will be ignored when deserializing (see options)
        }



    }
}
