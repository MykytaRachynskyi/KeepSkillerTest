using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Heap<T> where T : IHeapItem<T>
    {
        T[] items;

        public Heap(int maxHeapSize)
        {
            items = new T[maxHeapSize];
        }

        public void Add(T item)
        {
            item.HeapIndex = Count;
            items[Count] = item;
            HeapifyUp(item);
            Count++;
        }

        public T RemoveFirstItem()
        {
            T firstItem = items[0];
            Count--;
            items[0] = items[Count];
            items[0].HeapIndex = 0;
            HeapifyDown(items[0]);

            return firstItem;
        }

        public void UpdateItem(T item)
        {
            HeapifyUp(item);
            HeapifyDown(item);
        }

        public bool Contains(T item)
        {
            return Equals(items[item.HeapIndex], item);
        }

        public int Count { get; private set; } = 0;

        void HeapifyUp(T item)
        {
            bool done = false;
            while (!done)
            {
                int parentIndex = (item.HeapIndex - 1) / 2;
                T parentItem = items[parentIndex];
                if (item.CompareTo(parentItem) > 0)
                {
                    Swap(item, parentItem);
                }
                else
                {
                    done = true;
                }
            }
        }

        void HeapifyDown(T item)
        {
            bool done = false;
            while (!done)
            {
                int childIndexLeft = item.HeapIndex * 2 + 1;
                int childIndexRight = item.HeapIndex * 2 + 2;
                int swapIndex = 0;

                if (childIndexLeft < Count)
                {
                    swapIndex = childIndexLeft;
                    if (childIndexRight < Count)
                    {
                        if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
                        {
                            swapIndex = childIndexRight;
                        }
                    }

                    if (item.CompareTo(items[swapIndex]) < 0)
                    {
                        Swap(item, items[swapIndex]);
                    }
                    else
                    {
                        done = true;
                    }
                }
                else
                {
                    done = true;
                }
            }
        }

        void Swap(T itemA, T itemB)
        {
            items[itemA.HeapIndex] = itemB;
            items[itemB.HeapIndex] = itemA;
            int temp = itemA.HeapIndex;
            itemA.HeapIndex = itemB.HeapIndex;
            itemB.HeapIndex = temp;
        }
    }
}