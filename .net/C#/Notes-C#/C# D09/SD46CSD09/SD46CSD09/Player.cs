using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD09
{
    //Subscriber
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public Player()
        {
            Id = 1;
            Name = "Ahmed";
            Team = "Zamalek";
        }
        public Player(int _id,string _name,string _team)
        {
            Id = _id;
            Name = _name;
            Team = _team;
        }

        ////callback method
        //public void Run()
        //{
        //    Console.WriteLine($"Player {Name} is running to ball....");
        //}

        //callback method
        public void Run(Location _newLoc)
        {
            Console.WriteLine($"Player {Name} is running to ball. {_newLoc}...");
        }
    }
}
