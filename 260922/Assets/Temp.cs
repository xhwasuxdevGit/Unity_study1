using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    private Dictionary<GameObject, int> dict = new();

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _turret;

    private void Start()
    {
        
       dict[_player] = 5;
       // dict.Add(_player, 10); 에러: 키값은 중복으로 사용할 수 없다
       dict.Add(_turret, 99);

       Debug.Log(dict[_player]);

       if (dict.ContainsKey(_player))
       {
          Debug.Log(dict[_player]);
       }

       int result;
       Debug.Log(dict.TryGetValue(_player, out result));
       Debug.Log(result);
       
      
        // 키를 조회해서 추가하기
        if (!dict.ContainsKey(_player))
        {
           dict[_player] = 10; // dict.Add()로도 사용 가능
        }

        else
        {
           Debug.Log("키 중복");
        }
        

        // TryAdd()를 통해 추가하는 방법
         if (dict.TryAdd(_player, 10))
        {
           Debug.Log("10 추가 성공");
        }

        else
        {
           Debug.Log("10 추가 실패");
        }

        Debug.Log(dict[_player]);
       
    }
    
    
}

/*
private Dictionary<string, GameObject> _dict = new ();

private void Start()
{
    // _dict.Add("aaa", new GameObject());
    _dict.Add("bbb", new GameObject());
    _dict.Add("ccc", new GameObject());
    _dict.Add("ddd", new GameObject());

    Debug.Log(_dict.Count);

    _dict.Remove("aaa"); // 만약에 이미 없는 요소를 삭제하려고해도 컴파일 에러는 안뜸

    // 삭제시에는 `ContainsKey`를 통해서 한번더 확인하는 로그를 띄워보자
    if (!_dict.ContainsKey("aaa"))
    {
        Debug.Log("aaa 없어짐");
    }

    Debug.Log(_dict.Count);

}
*/
