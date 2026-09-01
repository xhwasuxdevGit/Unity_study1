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
    

}
