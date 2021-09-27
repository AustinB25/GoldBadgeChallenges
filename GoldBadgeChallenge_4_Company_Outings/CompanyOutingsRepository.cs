using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_4_Company_Outings
{
    public class CompanyOutingsRepository
    {
        private List<CompanyOuting> _companyOutings = new List<CompanyOuting>();
        private int iDCount = default;
        public bool CreateNewOuting(CompanyOuting newCompanyOuting)
        {
            if (newCompanyOuting == null)
            {
                return false;
            }
            newCompanyOuting.OutingID = ++iDCount;
            _companyOutings.Add(newCompanyOuting);
            return true;
        }
        public List<CompanyOuting> SeeAllOutings()
        {
            return _companyOutings;
        }
        public CompanyOuting FindOutingByID(int id)
        {
            foreach (CompanyOuting outing in _companyOutings)
            {
                if (outing.OutingID == id)
                {
                    return outing;
                }
            }
            return null;
        }
    }
}
