using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lab.Lab5;
 class Singleton
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static Singleton myObj { get; }
    private Singleton()
    {
     
        Id = 0;
        Name= string.Empty;
        Description = string.Empty;
    }
    private Singleton( int id , string name , string description)
    {
        Id = id;
        Name = name;
        Description = description;
       

    }

    static Singleton()
    {

        myObj = new Singleton();
        
    }











}
