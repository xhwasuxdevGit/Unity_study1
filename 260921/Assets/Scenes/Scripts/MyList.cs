
using System.Collections.Generic;

public class MyList<T>
{
    private T[] _items;
    private int _count;

    public int Count
    {
        get { return _count; }
    }

    public int Capacity
    {
        get { return _items.Length; }
    }

    public MyList()
    {
        // 칸이 하나도 없는 배열을 만들어 _items에 담습니다. 첫 Add에서 칸이 생깁니다. 
        _items = new T[] { };
    }

    public MyList(int capacity)
    {
        // 넘겨받은 칸 수만큼의 배열을 만들어 _items에 담습니다.
        _items = new T[capacity];
    }

    // O(1) - 인덱스를 알고 있으므로, 배열안의 요소에 한번에 바로 접근가능
    public T Get(int index)
    {
        // index 칸의 값을 돌려줍니다. 
        return _items[index];
    }
    
    // O(1) - 인덱스를 알고 있으므로, 배열안의 요소에 한번에 바로 접근가능
    public void Set(int index, T value)
    {
        // index 칸에 value를 넣습니다.  
        _items[index] = value;
    }

    public string ToText()  
    {  
        string text = "";

        for (int i = 0; i < _count; i++)  
        {  
            if (i > 0)  
            {  
                text += ", ";  
            }

            text += _items[i];  
        }

        return text;  
    } 
    
    // O(n) - n은 Count
    // 칸을 늘릴 필요가 없다면 O(1)이지만, 칸을 늘려야 되는 경우 `GrowIfFull` 메서드에 순회가 내재되어 있음
    public void Add(T value)  
    {  
        // 칸이 다 찼으면 먼저 칸을 늘립니다.  
        if (_count == _items.Length)
        {
            GrowIfFull();
        }
        
        // 개수가 가리키는 칸에 value를 넣습니다. 
        _items[_count] = value;
        
        // 개수를 하나 늘립니다.
        _count++;
    }
    
    // O(n) - n은 Count
    // 칸을 늘리는 여부와 상관없이, 배열을 뒤로 밀기 위해 순회가 필요
    public void Insert(int index, T value)  
    {  
        // 칸이 다 찼으면 먼저 칸을 늘립니다.  
        if (_count == _items.Length)
        {
            GrowIfFull();
        }
        
        // 맨 끝 요소부터 index 자리의 요소까지, 뒤에서부터 돌며 한 칸씩 뒤로 옮깁니다. 
        for (int i = _count - 1; i >= index; i--)
        {
            _items[i + 1] = _items[i];
        }
        
        // index 칸에 value를 넣습니다.
        _items[index] = value;
        
        // 개수를 하나 늘립니다.  
        _count++;
    }
    
    // O(n) - n은 Count
    // 크기를 늘린 새로운 배열을 `순회`하며 기존 배열의 요소를 대입하고 있음
    private void GrowIfFull()  
    {  
        // 개수가 칸 수보다 작으면 아무것도 하지 않고 돌아갑니다. 
        if (_count < _items.Length) return;
        
        // 새 칸 수를 정합니다. 지금 칸 수가 0이면 4, 아니면 지금 칸 수의 두 배입니다.
        int newCapacity;
        if (_items.Length == 0)
        {
            newCapacity = 4;
        }
        else
        {
            newCapacity = _items.Length * 2;
        }
        
        // 새 칸 수만큼의 배열을 새로 만듭니다. 
        T[] newList = new T[newCapacity];
        
        // 담긴 요소를 앞에서부터 새 배열의 같은 번호 칸에 옮겨 담습니다. 
        for (int i = 0; i < _items.Length; i++)
        {
            newList[i] = _items[i];
        }
        
        // _items가 새 배열을 가리키게 합니다.  
        _items = newList;
    }
    
    // O(n) - n은 Count
    // 넘어온 값을 찾기 위해 배열을 순회할 필요가 있음
    public int IndexOf(T value)  
    {  
        // 0번 칸부터 개수 직전 칸까지 앞에서부터 차례로 돕니다.
        // 그 칸의 값이 value와 같은 값이면 그 번호를 돌려줍니다.  
        for (int i = 0; i < _count; i++)
        {
            if(_items[i].Equals(value))
            {
                return i;
            }
        }
        
        // 끝까지 돌아도 같은 값이 없으면 -1을 돌려줍니다.  
        return -1;
    }
    
    // O(n) - n은 Count
    // `IndexOf` 메서드를 사용하므로 순회가 이미 내재되어 있음
    public bool Contains(T value)  
    {  
        // value가 몇 번 자리에 있는지 찾습니다.
        // 찾은 번호가 0보다 작지 않으면 들어 있는 것입니다.
        if (IndexOf(value) >= 0)
        {
            return true;
        }
        return false;    
    }
    
    // O(n) - n은 `Count - index` (= 지워야할 자리 ~ 개수의 끝자리 까지)
    // 배열을 앞쪽으로 당기기 위해 순회가 필요
    public void RemoveAt(int index)  
    {  
        // index 다음 요소부터 맨 끝 요소까지, 앞에서부터 돌며 한 칸씩 앞으로 옮깁니다. 
        for (int i = index; i < _count-1; i++)
        {
            _items[i] = _items[i+1];
        }
        
        // 개수를 하나 줄입니다.
        _count--;
        
        // 비어 버린 맨 뒷자리 칸을 기본값으로 바꿉니다. 
        _items[_count] = default(T);
    }

    // O(n) - n은 Count
    // `IndexOf` 메서드를 사용하므로 순회가 이미 내재되어 있음
    public bool Remove(T value)  
    {  
        // value가 몇 번 자리에 있는지 찾습니다.  
        // 찾지 못했으면 false를 돌려줍니다. 
        int search = IndexOf(value);
        if (search == -1)
        {
            return false;  
        }
        
        // 찾았으면 그 자리를 지우고 true를 돌려줍니다.
        RemoveAt(search);
        return true;
    }
    
    // O(n) - n은 Count
    // 배열의 시작부터 개수의 자리만큼 초기화 시켜야하므로 순회가 필요
    public void Clear()  
    {  
        // 0번 칸부터 개수 직전 칸까지 차례로 돌며 기본값으로 바꿉니다. 
        for (int i = 0; i < _count; i++)
        {
            _items[i] = default(T);
        }
        
        // 개수를 0으로 만듭니다.  
        _count = 0;
        
        // 칸 수는 건드리지 않습니다.  
    }

}

    



