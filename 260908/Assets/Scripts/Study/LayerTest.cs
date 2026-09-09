using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTest : MonoBehaviour
{
  public LayerMask TargetLayer;

  [SerializeField] private float _range;

  private void Start()
  {
    TargetLayer = TargetLayer.Everyting();
    
  }
  private void Update()
  {
    // 이 오브젝트의 위치에서 정면으로 발사되는 Ray 생성
    // 레이캐스트를 사용해서 감지한 게임 오브젝트와 이름을 출력한다
    // 레이캐스트의 거리는 인스펙터에서 조절할 수 있도록 한다
    
    
  }

  private void OnTriggerEnter(Collider other)
  {
    
    if(TargetLayer.Contains(other.gameObject.layer))
    {
      Debug.Log("찾음");
    }
  }


  private bool ContainsLayer(LayerMask mask, Collider layer)
  {
    return 0 != (mask.value & (1 << layer.gameObject.layer));
  }
}
