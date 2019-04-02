using System;
using System.Collections.Generic;

namespace BasicRecursion
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program prg = new Program();

            // generate random list
            var list = prg.GenerateListOfRandomNumbers();

            Console.WriteLine("This is the start list \r\n");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");

            // Call recursive method
            var sortedList = prg.RemoveDuplicates(list);
            sortedList.Sort();

            Console.WriteLine("This is the list without duplicates (sorted) \r\n");

            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public List<int> GenerateListOfRandomNumbers()
        {
            Random rn = new Random();
            List<int> randomList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                randomList.Add(rn.Next(1, 21));
            }

            return randomList;
        }

        // don't want list or pointer reinstanced in the recursion
        int checkIndex = 0;
        List<int> tempList = new List<int>();

        public List<int> RemoveDuplicates(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (checkIndex >= list.Count)
                {
                    // keep the pointer in bounds
                    checkIndex = 0;
                }
                if (list[checkIndex] == list[i] && checkIndex == i)
                {
                    // found same record so do nothing
                }
                else if (list[checkIndex] == list[i])
                {
                    list.RemoveAt(i);
                    // found duplicate, so remove the duplicate
                }
            }
            // move pointer
            checkIndex++;

            if (checkIndex < list.Count)
            {
                // recursive call
                RemoveDuplicates(list);
            }
            else if (checkIndex == list.Count)
            {
                //store in temp 
                tempList = list;
            }

            // return temp
            return tempList;
        }
    }
}
