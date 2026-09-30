using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphStudy : MonoBehaviour
{
    // 인접행렬 구현

    private const int _vertexCount = 6;

    private string[] _names = { "입구", "복도", "창고", "광장", "우물", "타워" };
    
    // 인접 리스트
    private List<int>[] _neighbors = new List<int>[_vertexCount];
    
    // 입구 List<int> = 복도,
    // 복도 List<int> = 입구, 창고, 광장
    // 창고 List<int> = 복도, 광장
    // 광장 List<int> = 복도, 창고, 우물, 타워
    // 우물 List<int> = 광장, 탑
    // 타워 List<int> = 광장, 우물
    
    // 인접행렬
    // private bool[,] _matrix = new bool[_vertexCount, _vertexCount];
    
    //       입 복  창 광 우 타
    // 입구   0  1  0  0  0  0
    // 복도   1  0  1  1  0  0
    // 창고   0  1  0  1  0  0
    // 광장   0  1  1  0  1  1
    // 우물   0  0  0  1  0  1
    // 타워   0  0  0  1  1  0
    

    private void Start()
    {
        for (int i = 0; i < _vertexCount; i++)
        {
            _neighbors[i] = new List<int>();
        }
        
        
        
        AddEdge(0, 1);
        AddEdge(1, 2);
        AddEdge(1, 3);
        AddEdge(2, 3);
        AddEdge(3, 4);
        AddEdge(3, 5);
        AddEdge(4, 5);

        for (int i = 0; i < _vertexCount; i++)
        {
            PrintNeighbors(i);    
        }
        
        
    }
    
    private void AddEdge(int a, int b)
    {
        // 인접 리스트
        _neighbors[a].Add(b);
        _neighbors[b].Add(a);
        
        /* 인접행렬
        _matrix[a, b] = true; 
       _matrix[b, a] = true;
       */
    }

    private void PrintNeighbors(int vertex)
    {
        string print = "";
        
        // 바깥 배열의 순회가 아닌, List<int> 내부를 순회
        foreach (int neighbor in _neighbors[vertex])
        {
            print += $"{_names[neighbor]} ";
        }
        Debug.Log($"{_names[vertex]} 이웃 : {print}");
        
         
        /* 인접행렬
        for (int i = 0; i < _vertexCount; i++)
        {
            if (_matrix[vertex, i])
            {
                print += $" {_names[i]}";
            }
        }
        */
    }
  
}
