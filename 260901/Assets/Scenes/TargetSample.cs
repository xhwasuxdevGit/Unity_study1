using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSample : MonoBehaviour
{
   [SerializeField] private Renderer _targetRenderer;

   private void Start()
   {
      Debug.Log($"TargetSample: 연결된 대상은 {_targetRenderer.name}입니다.");
   }
}
