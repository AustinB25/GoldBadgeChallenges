﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_3_Company_Badges
{
    public class BadgesUI
    {
    /*    

Here's what they need:
An app that maintains a dictionary of details about employee badge information. (Hint: A dictionary is a collection type in C#. You'll want to use that.)
Essentially, a badge will have a badge number that gives access to a specific list of doors.
    For instance, a developer might have access to Door A1 & A5.A claims agent might have access to B2 & B4.
Create a badge repository:
Create a dictionary of badges.
The key for the dictionary will be the BadgeID.
The value for the dictionary will be the List of Door Names.
The Program will allow a security staff member to do the following:
create a new badge
update doors on an existing badge.
delete all doors from an existing badge.
show a list with all badge numbers and door access
Note: Make sure to keep the responsibilities of your UI, your repo, and your tests separate.
Only your UI class should ever take input from the user.
Here are some example views:
Menu
Hello Security Admin, What would you like to do?
Add a badge
Edit a badge.
List all Badges
#1 Add a badge
What is the number on the badge: 12345
List a door that it needs access to: A5
Any other doors(y/n)? y
List a door that it needs access to: A7
Any other doors(y/n)? n
(Return to main menu.)
#2 Update a badge
What is the badge number to update? 12345
12345 has access to doors A5 & A7.
What would you like to do?
Remove a door
Add a door
> 1
Which door would you like to remove? A5
Door removed.
12345 has access to door A7.
#3 List all badges view
Badge #	Door Access
12345	A7
22345	A1, A4, B1, B2
32345	A4, A5
Out of scope:
You do not need to consider tying an individual badge to a particular user. Just the Badge # will do.
Be sure to Unit Test your Repository methods.*/
    }
}
