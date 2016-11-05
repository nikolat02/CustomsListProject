using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsListProject
{
    public class CustomList<T> : IEnumerable
    {
        private T[] array;
        private int count;

        public CustomList()
        {
            array = new T[10];
            count = 0;
        }

        public void Add(T an)
        {
            array[count] = an;
            count = count + 1;
        }

        public int GetLength()
        {
            return count;
        }

        public bool Remove(T removeobj)  //Comeback to it
        {
            int index = Find(removeobj);
            if (index < 0)
            {
                return false;
            }

            for (int i = index + 1; i < count; i++)
            {
                array[i - 1] = array[i];
            }
            count--;
            return true;

        }

        public T Get(int index)
        {
            if (index < count && index >= 0)
            {
                return array[index];
            }
            else { return default(T); }
        }

        private int Find(T findobj)
        {
            for (int i = 0; i < count; i++)
            {
                if (findobj.Equals(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < count; index++)
            {
                yield return array[index];
            }

        }

        public CustomList<string> Zip(CustomList <T> List1, CustomList <T> List2)
        {
            CustomList<T> shortlist;
            CustomList<T> longlist;
            CustomList<string> combinedlist = new CustomList<string>();

            if (List1.GetLength() > List2.GetLength())
            {
                longlist = List1;
                shortlist = List2;
            }

            else
            {
                longlist = List2;
                shortlist = List1;
            }

            for (int i = 0; i < longlist.GetLength(); i++)
            {
                if (i >= shortlist.GetLength())
                {
                    combinedlist.Add((dynamic)longlist.Get(i).ToString());
                }
                else
                {
                    combinedlist.Add((dynamic)longlist.Get(i).ToString() + (dynamic)shortlist.Get(i).ToString());
                }
            }
            return combinedlist;
        }

        public static CustomList <T>operator +(CustomList<T> c1, CustomList<T> c2)
        {
            CustomList<T> shortlist;
            CustomList<T> longlist;
            CustomList<T> combinedlist = new CustomList<T>();

            if (c1.GetLength() > c2.GetLength())
            {
                longlist = c1;
                shortlist = c2;
            }

            else
            {
                longlist = c2;
                shortlist = c1;
            }

            for (int i = 0; i < longlist.GetLength(); i++)
            {
                if (i >= shortlist.GetLength())
                {
                    combinedlist.Add(longlist.Get(i));
                }
                else
                {
                    combinedlist.Add((dynamic)longlist.Get(i) + (dynamic)shortlist.Get(i));
                }
            }
            return combinedlist;

        }

        public static CustomList<T> operator -(CustomList<T> c1, CustomList<T> c2)
        {
            CustomList<T> shortlist;
            CustomList<T> longlist;
            CustomList<T> combinedlist = new CustomList<T>();

            if (c1.GetLength() > c2.GetLength())
            {
                longlist = c1;
                shortlist = c2;
            }

            else
            {
                longlist = c2;
                shortlist = c1;
            }

            for (int i = 0; i < longlist.GetLength(); i++)
            {
                if (i >= shortlist.GetLength())
                {
                    combinedlist.Add(longlist.Get(i));
                }
                else
                {
                    combinedlist.Add((dynamic)longlist.Get(i) - (dynamic)shortlist.Get(i));
                }
            }
            return combinedlist;

        }


    }
}









