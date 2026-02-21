using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD09
{
    //Subscriber
    public class Referee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Referee()
        {
            Id = 10;
            Name = "Hanaa";
        }
        public Referee(int _id,string _name)
        {
            Id = _id;
            Name = _name;
        }

        ////callback method
        //public void Observe()
        //{
        //    Console.WriteLine($"Referee {Name} is observing ....");
        //}

        //callback method
        public void Observe(Location _newLoc)
        {
            Console.WriteLine($"Referee {Name} is observing ..{_newLoc}..");
        }
    }
}
