using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleQueue<T>
{
   private T[] _items;
   private int _head;
   private int _count;
   
   public int Count => _count;

   public SimpleQueue(int capacity)
   {
      _items = new T[capacity];
   }

   public void Enqueue(T item)
   {
      if (_count >= _items.Length)
      {
         Debug.Log("SimpleQueue: 더 담을 수 없습니다.");
         return;
      }
     
      int tail = (_head + _count) % _items.Length;
      
      _items[tail] = item;
      _count++;
   }

   public T Dequeue()
   {
      T item = _items[_head];

      _head = (_head + 1) % _items.Length;
      _count--;
      
      return item;
   }

   public T Peek()
   {
      return _items[_head];
   }
}
