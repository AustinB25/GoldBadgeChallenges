using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_6_Green_Plan.CarInterFaceAndClasses
{
    public class Car
    {
        public Car()
        {
        }

        public Car(int year, string make, string model, int mileage, FeulType feulType)
        {            
            Year = year;
            Make = make;
            Model = model;
            Mileage = mileage;
            FeulType = feulType;
        }

        public int ID { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Mileage { get; set; }
        public FeulType FeulType { get; set; }
    }
    public enum FeulType
    {
        Electric,
        Gas,
        Hybrid
    }
}
