using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhibitController : MonoBehaviour
{
    [SerializeField] private Renderer _baseRenderer;
    [SerializeField] private float _turnPerFranme = 0.5f;
    [SerializeField] private float _startAngle = 30f;

    private Renderer _selfRenderer;
    private Renderer _spotRenderer;
    private float _angle;

    private void Awake()
    {
        CacheComponents();
        InitAngle();
    }

    private void OnEnable()
    {
        ActivateVisual();
    }

    private void Start()
    {
        BindSpot();
    }

    private void Update()
    {
        TurnExhibit();
    }

    private void OnDisable()
    {
        DeactivateVisual();
    }

    private void OnDestroy()
    {
        ReportAngle();
        HideSpot();
    }

    private void CacheComponents()
    {
        _selfRenderer = GetComponent<Renderer>();
        Debug.Log($"ExhibitController: 가리키고있는 렌더러는 {_selfRenderer.name}입니다.");
        
    }

    private void InitAngle()
    {
        _angle = _startAngle;
        Debug.Log($"ExhibitController: 설정된 초기 각도는 {_angle}입니다.");
    }

    private void ActivateVisual()
    {
        _selfRenderer.enabled = true;
        _baseRenderer.enabled = true;
        Debug.Log("ExhibitController: 전시물과 받침을 표시합니다.");
    }

    private void BindSpot()
    {
        const string TAG_SPOT = "Spot";
        GameObject foundObject = GameObject.FindWithTag(TAG_SPOT);
        Renderer foundRenderer = foundObject.GetComponent<Renderer>();
        _spotRenderer = foundRenderer;
        Debug.Log($"ExhibitController: 태그로 찾은 구조물은 {_spotRenderer.name}입니다.");
    }

    private void TurnExhibit()
    {
        _angle += _turnPerFranme;
    }

    private void DeactivateVisual()
    {
        _selfRenderer.enabled = false;
        _baseRenderer.enabled = false;
        Debug.Log("ExhibitController: 전시물과 받침을 표시하지 않습니다.");
    }

    private void ReportAngle()
    {
        Debug.Log($"ExhibitController: 최종 설정된 각도는 {_angle}입니다.");
    }

    private void HideSpot()
    {
        Debug.Log("ExhibitController: 표식으로 지정한 구조물을 표시하지 않습니다.");
        _spotRenderer.enabled = false;
    }
}
