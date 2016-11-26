using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
			array = new T[1000];
			count = 0;
		}

		public void Add(T objectToAdd)
		{
			array[count] = objectToAdd;
			count = count + 1;
		}

		public int GetLength()
		{
			return count;
		}

		public bool Remove(T removeObj)  //Comeback to it
		{
			int index = Find(removeObj);
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

		private int Find(T findObj)
		{
			for (int i = 0; i < count; i++)
			{
				if (findObj.Equals(array[i]))
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
			CustomList<T> shortList;
			CustomList<T> longList;
			CustomList<string> combinedList = new CustomList<string>();

			if (List1.GetLength() > List2.GetLength())
			{
				longList = List1;
				shortList = List2;
			}

			else
			{
				longList = List2;
				shortList = List1;
			}

			for (int i = 0; i < longList.GetLength(); i++)
			{
				if (i >= shortList.GetLength())
				{
					combinedList.Add(longList.Get(i).ToString());
				}
				else
				{
					combinedList.Add(longList.Get(i).ToString() + shortList.Get(i).ToString());
				}
			}
			return combinedList;
		}

		public static CustomList <T>operator +(CustomList<T> customList1, CustomList<T> customList2)
		{
			CustomList<T> shortList;
			CustomList<T> longList;
			CustomList<T> combinedlist = new CustomList<T>();

			if (customList1.GetLength() > customList2.GetLength())
			{
				longList = customList1;
				shortList = customList2;
			}

			else
			{
				longList = customList2;
				shortList = customList1;
			}

			for (int i = 0; i < longList.GetLength(); i++)
			{
				if (i >= shortList.GetLength())
				{
					combinedlist.Add(longList.Get(i));
				}
				else
				{
					combinedlist.Add((dynamic)longList.Get(i) + (dynamic)shortList.Get(i));
				}
			}
			return combinedlist;

		}

        public override string ToString()
        {
            string concatString = "";
            for(int i = 0; i < count; i++)
            {
                concatString = concatString + array[i].ToString() + ",";
            }
            return concatString;
        }

		public static CustomList<T> operator -(CustomList<T> c1, CustomList<T> c2)
		{
			CustomList<T> shortList;
			CustomList<T> longList;
			CustomList<T> combinedList = new CustomList<T>();

			if (c1.GetLength() > c2.GetLength())
			{
				longList = c1;
				shortList = c2;
			}

			else
			{
				longList = c2;
				shortList = c1;
			}

			for (int i = 0; i < longList.GetLength(); i++)
			{
				if (i >= shortList.GetLength())
				{
					combinedList.Add(longList.Get(i));
				}
				else
				{
					combinedList.Add((dynamic)longList.Get(i) - (dynamic)shortList.Get(i));
				}
			}
			return combinedList;

		}


	}
}









