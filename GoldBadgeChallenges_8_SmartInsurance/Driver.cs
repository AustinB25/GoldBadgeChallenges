using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges_8_SmartInsurance
{
    public class Driver
    {
        public Driver() { }
        public Driver(string firstName, string lastName, DateTime birthDate, double averageSpeed, int timesOverSpeedLimit, int timesCrossingLine, int stopSignsRan, int driversTrailed)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            AverageSpeed = averageSpeed;
            TimesOverSpeedLimit = timesOverSpeedLimit;
            TimesCrossingLine = timesCrossingLine;
            StopSignsRan = stopSignsRan;
            DriversTrailed = driversTrailed;            
        }
        public int DriverID { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public DateTime BirthDate { get; set; }
        public double  AverageSpeed { get; set; }
        public int TimesOverSpeedLimit { get; set; }
        public int TimesCrossingLine { get; set; }
        public int StopSignsRan { get; set; }
        public int DriversTrailed { get; set; }
        public decimal InsuranceRate { get; set; } 
        public int DriverRating { get; set; }
    }    
}
