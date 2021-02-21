using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Double_linked_list_28._09._20
{
	class List<T> : ICloneable, IEnumerable, IEnumerable<T>, ICollection, ICollection<T>
	{
	    private ListItem<T> _head;
		private ListItem<T> _tail;
		private int _size;

		public int Count { get => _size; }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public List()
		{
			_head = null;
			_tail = null;
			_size = 0;
		}

		public void AddItem(T value)
		{
			ListItem<T> newItem = new ListItem<T>(value);

			if (_head == null)
			{
				_head = newItem;
			}
			else
			{
				_tail.next = newItem;
				newItem.prev = _tail;
			}
			_tail = newItem;
			_size++;
		}
		public void AddToStart(T value)
		{
			ListItem<T> newItem = new ListItem<T>(value);

			newItem.next = _head;
			_head = newItem;
			_size++;
		}
		public bool RemoveFirstEnter(T value)
        {
			try
			{
				int index = Find(value);
				if (index < 0)
				{
					throw new IndexOutOfRangeException("Index must be 0 or bigger");
				}
				return RemoveAt(index);
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
        }
		public void RemoveFirst()
		{
			try
			{
				if (_size == 0)
				{
					throw new IndexOutOfRangeException("The list is null");
				}

				_head = _head.next;
				_size--;
				_head.prev = null;
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public void RemoveLast()
		{
			try
			{
				if (_size == 0)
				{
					throw new IndexOutOfRangeException();
				}
				else if (_size == 1)
				{
					RemoveFirst();
				}
				else
				{
					ListItem<T> prevNode = _tail.prev;

					prevNode.next = null;
					_tail = prevNode;
					_size--;
				}
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public bool RemoveAt(int index)
		{
			try
			{
				if (index >= _size)
				{
					throw new IndexOutOfRangeException();
				}

				ListItem<T> delItem = FindItemAt(index);

				if (delItem.prev == null)
				{
					_head.prev = null;
					_head = delItem.next;
				}
				else
				{
					delItem.prev.next = delItem.next;
				}

				if (delItem.next == null)
				{
					_tail.next = null;
					_tail = delItem.prev;
				}
				else
				{
					delItem.next.prev = delItem.prev;
				}
				_size--;
				return true;
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		ListItem<T> FindItemAt(int index)
		{
			ListItem<T> cursor = _head;
			try
			{
				if (index < 0)
				{
					throw new IndexOutOfRangeException();
				}
				for (uint i = 0; i < index; i++)
				{
					cursor = cursor.next;
				}
				return cursor;
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				return cursor;
			}
		}

		public int Find(T data)
		{
			ListItem<T> tmpNode = _head;
			int index = 0;

			while (tmpNode != null)
			{
				if (tmpNode.value.Equals(data))
				{
					return index;
				}
				tmpNode = tmpNode.next;
			}
			return -1;
		}

		public void Print()
		{
			ListItem<T> cursor = _head;
			while (cursor != null)
			{
				Console.Write($"{cursor.value} \t");
				cursor = cursor.next;
			}
			Console.WriteLine();
		}

		public void ReversePrint()
		{
			ListItem<T> cursor = _tail;
			while (cursor != null)
			{
				Console.Write($"{cursor.value} \t");
				cursor = cursor.prev;
			}
			Console.WriteLine();
		}

        public object Clone()
        {
			List<T> tmpList = new List<T>();
			ListItem<T> tmpItem = _head;

			while (tmpItem != null)
			{
				tmpList.AddItem(tmpItem.value);
				tmpItem = tmpItem.next;
			}
			return tmpList;
        }
		public class Enumerator : IEnumerator
		{
			private ListItem<T> _item;
			private List<T> _list;
			

			public Enumerator(List<T> list)
			{
				_list = list;
				_item = new ListItem<T>();
				_item.Next = _list._size == 0 ? null : _list._head;
			}

			public object Current
			{
				get { return _item.value; }
			}

			public bool MoveNext()
			{
				if (_item.Next == null)
                {
					return false;
				}
				_item = _item.Next;
				return true;
			}

			public void Reset()
			{
				_item = new ListItem<T>();
				_item.Next = _list._size == 0 ? null : _list._head;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
			ListItem<T> current = _head;
			while (current != null)
			{
				yield return current.value;
				current = current.Next;
			}
		}

        public void CopyTo(Array array, int index)
        {
			try
			{
				if (array == null)
				{
					throw new ArgumentNullException("Array cannot be null");
				}
				if (index < 0)
				{
					throw new IndexOutOfRangeException("Index cannot be smaller than 0");
				}
				if (Count > array.Length - index)
				{
					throw new ArgumentException("Size of collection is bigger than array");
				}

				ListItem<T> item = _head;
				T[] tempArray = new T[Count - index];

				for (int i = 0; i < Count - index; i++)
				{
					tempArray[i] = item.value;
					item = item.Next;
				}
				array = tempArray;
			}
			catch (ArgumentNullException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
        }

        public void Add(T item)
        {
			AddItem(item);
        }

        public void Clear()
        {
			while (Count != 0)
			{
				RemoveLast();
				_size--;
			}
        }

        public bool Contains(T item)
        {
			try
			{
				if (item == null)
				{
					throw new ArgumentNullException("Item cannot be null");
				}

				ListItem<T> current = _head;
				while (current != null)
				{
					if (current.value.Equals(item))
					{
						return true;
					}
					current = current.Next;
				}
				return false;
			}
			catch (ArgumentNullException ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

        public void CopyTo(T[] array, int arrayIndex)
        {
			try
			{
				if (array == null)
				{
					throw new ArgumentNullException("Array cannot be null");
				}
				if (arrayIndex < 0)
				{
					throw new IndexOutOfRangeException("Index cannot be smaller than 0");
				}
				if (Count > array.Length - arrayIndex)
				{
					throw new ArgumentException("Size of collection is bigger than array");
				}

				ListItem<T> item = _head;
				T[] tempArray = new T[Count - arrayIndex];

				for (int i = 0; i < Count - arrayIndex; i++)
				{
					tempArray[i] = item.value;
					item = item.Next;
				}
				array = tempArray;
			}
			catch (ArgumentNullException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

        public bool Remove(T item)
        {
			return RemoveFirstEnter(item);
		}
    }
}