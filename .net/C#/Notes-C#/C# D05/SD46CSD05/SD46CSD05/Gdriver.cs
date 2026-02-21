using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD05
{
    public class Gdriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private Gdriver()
        {
            Id = 1;
            Name = "NVidia";
            Description = "Nvidia card";
        }
        private Gdriver(int _id,string _name,string _desc)
        {
            Id = _id;
            Name = _name;
            Description = _desc;
        }
        public override string ToString()
        {
            return $"{Name}:{Description}";
        }

        #region Create One Object from class  c++ version
        //static Gdriver obj;

        //public static Gdriver CreateOneObject()
        //{
        //    if (obj == null)
        //    {
        //        obj=new Gdriver();
        //        return obj;
        //    }
        //    else
        //    {
        //        return obj;
        //    }
        //}
        #endregion
        #region SingleTon V1
        //static Gdriver obj;
        //public static Gdriver Obj
        //{
        //    get
        //    {
        //        if (obj == null)
        //        {
        //            obj = new Gdriver();
        //        }
        //        return obj;
        //    }
        //}
        #endregion
        #region SingleTon V2
        //public static Gdriver Obj { get; }
        //static Gdriver()
        //{
        //    Obj= new Gdriver();
        //}

        #endregion
        #region SingleTon V3
        public static Gdriver Obj { get; } = new Gdriver();
        #endregion


    }
}
