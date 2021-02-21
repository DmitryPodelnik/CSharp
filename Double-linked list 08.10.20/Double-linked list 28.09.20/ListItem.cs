using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_linked_list_28._09._20
{
    class ListItem<T>
    {
		public ListItem<T> next;
		public ListItem<T> prev;
		public T value;

		
		public ListItem()
        {
			next = null;
			prev = null;
			value = default(T);
        }
	    public ListItem(T value)
		{
			this.value = value;
		}
		public ListItem<T> Next
        {
			get => next;
			set => next = value;
        }
		public ListItem<T> Prev
		{
			get => next;
			set => next = value;
		}
	}
}
