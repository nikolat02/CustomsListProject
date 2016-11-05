using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> myIntList = new CustomList<int>();
            CustomList<int> myIntList2 = new CustomList<int>();
            myIntList.Add(1);
            myIntList.Add(2);
            myIntList.Add(3);
            myIntList2.Add(1);
            myIntList2.Add(2);
            myIntList2.Add(3);
            CustomList<int> myTempIntList = myIntList + myIntList2;
            myTempIntList = myIntList - myIntList2;
            int j = myIntList.Get(0);
            foreach (int temp in myIntList) { Console.WriteLine(temp); }
            CustomList<string> tempList = new CustomList<string>();
            Console.ReadKey();
        }

    }
}
