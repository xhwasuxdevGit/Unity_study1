using UnityEngine;

public class ZoneReporter : MonoBehaviour  
{  
    private void OnTriggerEnter(Collider other)  
    {  
        Debug.Log($"ZoneReporter: {other.name}이 범위에 들어왔습니다.");  
    }  
    
    private void OnTriggerExit(Collider other)  
    {  
        Debug.Log($"ZoneReporter: {other.name}이 범위를 벗어났습니다.");  
    } 
}

