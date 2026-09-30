using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchStudy : MonoBehaviour
{
    private const int _vertexCount = 9;
    private string[] _names = { "입구", "복도", "창고", "광장", "우물", "탑", "던전", "여관", "마이룸" };
    private List<int>[] _neighbors = new List<int>[_vertexCount];
    private string _order;
    private HashSet<int> _visited = new();

    private void Awake() => CreateGraph();
    
    private void Start()
    {
        Init();
        
        DfsStack(3);
        Bfs(3);
        
        DfsRecursive(3);
        Debug.Log($"DFS RECURSIVE : {_order}");
    }
    
    private void DfsRecursive(int start)
    {
        _visited.Add(start);
        _order += $" {_names[start]}";

        foreach (int neighbor in _neighbors[start])
        {
            if (!_visited.Contains(neighbor))
            {
                DfsRecursive(neighbor);
            }
        }
    }

    private void DfsStack(int start)
    {
        Stack<int> stack = new();
        HashSet<int> visited = new();
        string order = "";
        
        stack.Push(start);

        while (stack.Count > 0)  // 탐색이 시작되면 스택이 0일 상황은 없음
        {
            int current = stack.Pop();  // 지금 방문 중인 정점
            
            if (visited.Contains(current)) continue;
            
            
            visited.Add(current);
            order += $" {_names[current]}";

            foreach (int neighbor in _neighbors[current])
            {
                if (!visited.Contains(neighbor))
                {
                    stack.Push(neighbor);
                }
            }
        }
        
        Debug.Log($"DFS STACK: {order}");
    }


    
    private void Bfs(int start)
    {
        Queue<int> queue = new();
        HashSet<int> visited = new();
        string order = "";
        
        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)  
        {
            int current = queue.Dequeue();  
            
            order += $" {_names[current]}";

            foreach (int neighbor in _neighbors[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        Debug.Log($"BFS: {order}");
    }

    private void Init()
    {
        _visited.Clear();
        _order = "";
    }

    private void CreateGraph()
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
        AddEdge(0, 6);
        AddEdge(5, 7);
        AddEdge(7, 8);
    }
    
    private void AddEdge(int a, int b)
    {
        // 인접 리스트
        _neighbors[a].Add(b);
        _neighbors[b].Add(a);
    }
    
}
