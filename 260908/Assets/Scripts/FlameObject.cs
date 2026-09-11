using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameObject : MonoBehaviour
{
    // 설정한 딜레이 후 이펙트 사라짐
    [SerializeField] private float _effectDelay;
    [SerializeField] private bool _playInstant;
    [SerializeField] private bool _isDestory;
    
    private float _elapsedTime;
    private void Awake()
    {
        SetElapseDefault();
    }

    private void Start()
    {
        gameObject.SetActive(_playInstant);
    }

    private void Update()
    {
        Updateelapsed();
        UnPlay();
    }
    
    private void SetElapseDefault()
    {
        _elapsedTime = 0;
    }

    private void Updateelapsed()
    {
        _elapsedTime += Time.deltaTime;
    }
    
    public void Play()
    {
      SetElapseDefault();
      // 딜레이 초기화 > 계속해서 이펙트 재생됨
    }

    private void UnPlay()
    {
        if (_elapsedTime < _effectDelay) return;
        
        if(_isDestory) Destroy(gameObject);
        else gameObject.SetActive(false);
    }
}
