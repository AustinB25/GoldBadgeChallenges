using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_4_Company_Outings
{
    public class CompanyOuting
    {
        public CompanyOuting() {}

        public CompanyOuting(int peopleInAttendance, DateTime dateOfAttendance, decimal costPerPerson, EventType eventType)
        {            
            PeopleInAttendance = peopleInAttendance;
            DateOfAttendance = dateOfAttendance;
            CostPerPerson = costPerPerson;
            EventType = eventType;
        }

        public int OutingID { get; set; }
        public int PeopleInAttendance { get; set; }
        public DateTime DateOfAttendance { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get { return PeopleInAttendance * CostPerPerson; } }
        public EventType EventType { get; set; }
    }
    public enum EventType
    { 
        Golf = 1,
        Bowling,
        Amusement_Park,
        Concert
    }
}
