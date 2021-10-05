using GoldBadgeChallenge_6_Green_Plan.CarInterFaceAndClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_6_Green_Plan
{
    public class CarRepository
    {
        private List<Car> cars = new List<Car>();        
        int idCount = default;        
        public bool CreateACar(Car newCar)
        {
            if (newCar == null)
            {
                return false;
            }
            newCar.ID = ++idCount;
            cars.Add(newCar);
            return true;
        }
        public List<Car> ViewAllCars()
        {
            return cars;
        }
        public Car FindCarById(int id)
        {
            foreach(Car car in cars)
            {
                if (car.ID == id)
                {
                    return car;
                }
            }
            return null;
        }           
        public bool UpdateACar(int id, Car updatedCar) 
        {
            Car oldCar = FindCarById(id);
            if(oldCar == null)
            {
                return false;
            }
            oldCar.FeulType = updatedCar.FeulType;
            oldCar.Make = updatedCar.Make;
            oldCar.Mileage = updatedCar.Mileage;
            oldCar.Model = updatedCar.Model;
            oldCar.Year = updatedCar.Year;
            return true;
        }
        public bool DeleteACar(int id)
        {
            Car car = FindCarById(id);
            if(car == null)
            {
                return false;
            }
            cars.Remove(car);
            return true;
        }
    }
}
