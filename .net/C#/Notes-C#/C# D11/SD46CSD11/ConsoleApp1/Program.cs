namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            PhoneBook p1=new PhoneBook();
            p1.SetEntry(0, "Nasser", 1234);
            p1.SetEntry(1, "Nasser2", 2234);
            p1.SetEntry(2, "Nasser3", 3234);


            p1[0, "Nasser"] = 1234;
            Console.WriteLine(p1["Nasser"]);

            Console.WriteLine(p1.GetEntry("NASSER"));
        }
    }
}
