using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque
{
    public class BarbequeRepository
    {
        private List<Barbeque> _barbeques = new List<Barbeque>();
        int IDCount = default;
        public bool CreateACompanyBarbeque(Barbeque newBarbeque)
        {
            if (newBarbeque == null)
            {
                return false;
            }
            newBarbeque.ID = ++IDCount;
            _barbeques.Add(newBarbeque);
            return true;
        }
        public List<Barbeque> SeeAllBarbeques()
        {
           return _barbeques;
        }
        public Barbeque FindBbqById(int id)
        {
            foreach (Barbeque bbq in _barbeques)
            {
                if (bbq.ID == id)
                {
                    return bbq;
                }
            }
            return null;
        }
    }
}
