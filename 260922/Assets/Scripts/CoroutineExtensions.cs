using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineExtensions
{
  private static Dictionary<float, WaitForSeconds> _waitForSeconds = new();
  private static WaitForFixedUpdate _waitFixedUpdate = new WaitForFixedUpdate();

  public static WaitForSeconds GetWaitSeconds(float second)
  {
    WaitForSeconds wait;
    if (!_waitForSeconds.TryGetValue(second, out wait))
    {
      wait = AddWaitForSeconds(second);
    }

    return wait;
  }
  
  public static void RemoveWaitSeconds(float second)
  {
    if (!_waitForSeconds.ContainsKey(second)) return;
    _waitForSeconds.Remove(second);
  }

  private static WaitForSeconds AddWaitForSeconds(float second)
  {
    Debug.Log($"WaitForSeconds 추가 : {second}");
    WaitForSeconds wait = new WaitForSeconds(second);
    _waitForSeconds[second] = wait;
    return wait;
  }
  
  
}
