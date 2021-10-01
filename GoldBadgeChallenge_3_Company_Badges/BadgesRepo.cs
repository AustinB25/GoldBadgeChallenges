using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_3_Company_Badges
{
    public class BadgesRepo
    {
        private Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();
        public bool CreateANewBadge(Badge badge)
        {
            if(badge == null)
            {
                return false;
            }
            _badges.Add(badge.BadgeID, badge);
            return true;
        }
        public Dictionary<int, Badge> ViewAllBadges()
        {
            return _badges;
        }
        public Badge FindBadgeByBadgeNumber(int badgeNumber)
        {
            foreach (Badge badge in _badges.Values)
            {
                if (badge.BadgeID == badgeNumber)
                {
                    return badge;
                }
            }
            return null;
        }
        public bool UpdateABadge(int badgeNumber, Badge newBadge)
        {
            Badge oldBadge = FindBadgeByBadgeNumber(badgeNumber);
            if (oldBadge == null)
            {
                return false;
            }
            oldBadge.BadgeID = newBadge.BadgeID;
            oldBadge.DoorAccess = newBadge.DoorAccess;
            oldBadge.Name = newBadge.Name;
            return true;
        }
        public bool DeleteABadge(int badgeNumber)
        {
            Badge deleteBadge = this.FindBadgeByBadgeNumber(badgeNumber);
            if (deleteBadge == null)
            {
                return false;
            }
            int initialbadgeCount = _badges.Count;
            _badges.Remove(deleteBadge.BadgeID);
            return true;

        }
            
    }
}
