using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drunkulator.Models
{
    public class Boose
    {
        Boose(string[] members, string[] dishes)
        {
            Members = members;
            foreach (var dish in dishes)
            {
                //Инициализация объектов Dishes
                //Объекты контрибьюшнс - участник, участие, затраты, итог на участника
            }
        }
        public string[] Members { get; set; }
        public List<Dish> Dishes { get; set; }
    }

    public class Dish
    {
        public string Name { get; set; }
        public string Cost { get; set; }


        public Dictionary<string,int> Contributions { get; set; }
    }
}
