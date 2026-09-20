using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRoutineTest : MonoBehaviour
{
   [SerializeField] private float _delay;
   private WaitForSeconds _wait;
   private Coroutine _routine;

   private void Awake()
   {
      // YieldInstruction 반복적으로 사용될거하면 캐싱해두기
      _wait = new WaitForSeconds(_delay);
   }
   
   private float _time;

   private void Start()
   {
      Debug.Log("Start 시작");
      // 시작하는법: StartCoroutine() 함수 안에 매개변수로 MYRoutine() 함수를 대입
      // 매서드 자체를 라이프사이클에서 호출하는게 아님에 주의!
      // 멈출떄는 StopCoroutine(); 사용
      Debug.Log("Start 종료");
   }

   private void Update()
   {
      if(Input.GetKeyDown(KeyCode.Alpha1)) Run();
      if(Input.GetKeyDown(KeyCode.Alpha2)) Stop();
   }


   private void Run()
   {
      if(_routine != null) return;
      
      _routine = StartCoroutine(MyRoutine());
   }

   private void Stop()
   {
      if(_routine == null) return;
      
      StopCoroutine(_routine);
      _routine = null;
   }


   // 함수의 반환형은 `IEnumerator`
   private IEnumerator MyRoutine()
   {

      while (true)
      {
         // 반환할 떄는 `yield return;`
         // yield return 000: 000가 충족되는 상황까지 함수를 일시정지하고 대기할 것.
         yield return _wait;
         Debug.Log("Coroutine");
      }
      
      // 루틴을 아예 멈출 때
      // `yield break;` 사용, 일반 메서드의 `return`과 동일

   }
   

}
