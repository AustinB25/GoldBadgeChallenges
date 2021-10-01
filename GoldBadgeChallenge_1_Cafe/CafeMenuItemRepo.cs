using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_1_Cafe
{
    public class CafeMenuItemRepo
    {
        private List<CafeMenuItem> _menuItems = new List<CafeMenuItem>();
        int iDCount = default;
        public bool CreateAMenuItem(CafeMenuItem newItem)
        {
            if(newItem == null)
            {
                return false;
            }
            newItem.ID = ++iDCount;
            _menuItems.Add(newItem);
            return true;
        }
        public List<CafeMenuItem> SeeAllMenuItems()
        {
            return _menuItems;
        }
        public CafeMenuItem FindItemByID(int id)
        {
            foreach(CafeMenuItem item in _menuItems)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
        public bool RemoveAMenuItem(int id)
        {
            CafeMenuItem item = FindItemByID(id);
            if(item == null)
            {
                return false;
            }
           int initialCount =  _menuItems.Count;
            _menuItems.Remove(item);
            return initialCount > _menuItems.Count;
        }
    }
}
