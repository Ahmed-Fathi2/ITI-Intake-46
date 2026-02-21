using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD09
{
    //Publisher
    public class Football
    {
        public int Id { get; set; }
        Location ballLocation;

        public Location BallLocation
        {
            get
            {
                return ballLocation;
            }

            set
            {
                //event will be fired here 
                if(value!=ballLocation)
                {
                    var delta = value - ballLocation;
                    ballLocation = value;
                    //fire event 
                    //if(ballLocationChanged!=null)
                    //    ballLocationChanged();
                    
                    ballLocationChanged?.Invoke(delta);

                }
                
                ballLocation = value;
            }
        }
        public Football()
        {
            Id = 1;
            ballLocation = new Location();
        }
        public Football(int _id,Location _loc)
        {
            Id = _id;
            BallLocation = _loc;
        }

        #region Event framework
        ///public event DelegateType EventName;
        public event Action<Location> ballLocationChanged;

        ///EVENT FIRING MUST BE INSIDE PUBLISHER
        ///
        ////Action<Location> a1=
        ///


        //////Standard Model
        //public event EventHandler locationChanged;
        //protected virtual void OnLocationChanged()
        //{
        //    locationChanged?.Invoke(?);
        //}
        #endregion

    }
}
