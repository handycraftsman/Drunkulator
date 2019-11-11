using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drunkulator.Models
{
    public class Boose
    {
        public Boose(string[] members, string[] dishes)
        {
            Members = members;
            Dishes = new List<Dish>();
            Cost = 0;
            foreach (var name in dishes)
            {
                Dishes.Add(new Dish(name, members));
            }
        }
        public Boose()
        {
            Members = new string[0];
            Dishes = new List<Dish>();
            Dictionary<string, int> Result = new Dictionary<string, int>();
            Dictionary<string, int> TotalCash = new Dictionary<string, int>();
            Cost = 0;
        }
        public string[] Members { get; set; }
        public List<Dish> Dishes { get; set; }
        public Dictionary<string, int> Result { get; set; }
        public Dictionary<string, int> TotalCash { get; set; }
        public int Cost { get; set; }
        public void Calcultate()
        {
            TotalCash = new Dictionary<string, int>();
            Result = new Dictionary<string, int>();
            foreach (Dish d in Dishes)
            {
                d.Calculate();
            }
            Cost = (from d in Dishes select d.Cost).Sum();
            foreach (string m in Members)
            {
                Result.Add(m,(from d in Dishes where d.Partakers.Keys.Contains(m) select d.Partakers[m].Delta).Sum());
                TotalCash.Add(m, (from d in Dishes where d.Partakers.Keys.Contains(m) select d.Partakers[m].Cash).Sum());
            }
        }
    }

    public class Dish
    {
        public Dish (string name, string[] members)
        {
            Name = name;
            Cost = 0;
            Average = 0;
            Partakers = new Dictionary<string, Contribrution>();
            foreach (var member in members)
            {
                Partakers.Add(member, new Contribrution());
            }
        }
        public Dish()
        {
            Name = "";
            Cost = 0;
            Average = 0;
            Partakers = new Dictionary<string, Contribrution>();
        }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Average { get; set; }
        public Dictionary<string,Contribrution> Partakers { get; set; }

        public void Calculate()
        {
            var MemCount = (from t in Partakers where t.Value.Partaiking select t).Count() ;
            Cost = (from t in Partakers select t.Value.Cash).Sum();
            Average = Cost / MemCount;
            foreach (var p in Partakers)
            {
                p.Value.Delta = p.Value.Partaiking ? (p.Value.Cash - Average) : 0;
            }
        }
    }
    public class Contribrution
    {
        public Contribrution()
        {
            Partaiking = false;
            Cash = 0;
            Delta = 0;
        }
        public bool Partaiking { get; set; }
        public int Cash { get; set; }
        public int Delta { get; set; }
    }
}
