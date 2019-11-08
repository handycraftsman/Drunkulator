using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drunkulator.Models.ViewModels
{
    public class InitialInfo
    {
        public int MembersCount { get; set; }
        public int DishesCount { get; set; }
    }

    public class InitialLists
    {
        public List<string> MembersList { get; set; }
        public List<string> DishesList { get; set; }
    }
}
