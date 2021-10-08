using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges_8_SmartInsurance
{
    public class DriverRepository
    {
        private List<Driver> _drivers = new List<Driver>();
        private int iDCount = default;
        public bool CreateANewDriver(Driver driver)
        {
            if(driver == null)
            {
                return false;
            }
            driver.DriverID = ++iDCount;
            _drivers.Add(driver);
            return true;
        }
        public List<Driver> SeeAllCoveredDrivers()
        {
            return _drivers;
        }
        public Driver FindASpecififcDriver(int id)
        {
            foreach(var d in _drivers)
            {
                if (d.DriverID == id)
                {
                    return d;
                }
            }
                return null;
        }   
        public bool RemoveADriver(int id)
        {
            var removeD = FindASpecififcDriver(id);
            if (removeD == null)
            {
                return false;
            }
            _drivers.Remove(removeD);
            return true;
        }
        public bool UpdateADriver(int id)
        {
            Driver newD = new Driver();
            Driver updateD = FindASpecififcDriver(id);
            if (updateD == null)
            {
                return false;
            }
            updateD.AverageSpeed = newD.AverageSpeed;
            updateD.DriversTrailed = newD.DriversTrailed;
            updateD.FirstName = newD.FirstName;
            updateD.LastName = newD.LastName;
            updateD.StopSignsRan = newD.StopSignsRan;
            updateD.TimesOverSpeedLimit = newD.TimesOverSpeedLimit;
            updateD.TimesCrossingLine = newD.TimesCrossingLine;            
            return true;
        }            
    }
}
