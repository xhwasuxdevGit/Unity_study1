using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class TempPlayer : MonoBehaviour
{
    // IntChange: 반환형이 없고, 매개변수로 int타입 1개를 받는 함수자료형을 선언
   
    
    private int _health;

    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            OnHealthChange?.Invoke(_health);
        }
    }
    public event Action<int> OnHealthChange;

    public ObservableProperty<float> Exp = new (0);

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) TakeDamage(5);
        if(Input.GetKeyDown(KeyCode.Alpha2)) Heal(10);
        if(Input.GetKeyDown(KeyCode.Alpha3)) Exp.Value += 20.5f;
    }

    private void OnDestroy()
    {
        
    }
    
    public void TakeDamage(int damage)
    {
        Debug.Log("데미지 받음");
        Health -= damage;
      
    }

    public void Heal(int heal)
    {
        Debug.Log("회복됨");
        Health += heal;
        
    }
}
