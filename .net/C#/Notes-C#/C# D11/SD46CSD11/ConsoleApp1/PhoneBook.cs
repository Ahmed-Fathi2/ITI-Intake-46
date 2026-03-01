using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PhoneBook
    {
        int[] numbers;
        string[] names;
        int size;

        public int[] Numbers
        {
            get
            {
                return numbers;
            }

            set
            {
                numbers = value;
            }
        }

        public string[] Names
        {
            get
            {
                return names;
            }

            set
            {
                names = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public PhoneBook()
        {
            size = 5;
            numbers = new int[size];
            names= new string[size];
        }
        public PhoneBook(int _size)
        {
            size = _size;
            numbers = new int[size];
            names = new string[size];
        }
        public void SetEntry(int _index,string _name,int _number)
        {
            if (_index>=0 && _index<size)
            {
                names[_index] = _name;
                numbers[_index] = _number;
            }
        }
        public int GetEntry(string _name)
        {
            for (int i = 0; i < size; i++)
            {
                if (names[i]?.ToLower() == _name?.ToLower())
                {
                    return numbers[i];
                }
            }
            return -1;
        }

        public int this[int _index,string _name]
        {
            set
            {

            }
        }

        public int this[string _name]
        {
            get
            {

            }
        }
    }
}
