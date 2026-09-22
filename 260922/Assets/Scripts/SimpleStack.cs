using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStack<T>
{
   private T[] _items;
   private int _count;

   public int Count => _count;
   
   public SimpleStack(int capacity)
   {
      _items = new T[capacity];
   }

   public void Push(T item)
   {
      if (_count >= _items.Length)
      {
         Debug.Log("SimpleStack: 더 담을 수 없습니다.");
         return;
      }

      _items[_count] = item;
      _count++;
   }

   public T Pop()
   {
      _count--;
      return _items[_count];
   }

   public T Peek()
   {
      return _items[_count - 1];
   }
}
