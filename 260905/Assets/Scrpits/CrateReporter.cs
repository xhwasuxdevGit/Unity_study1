using UnityEngine;

public class CrateReporter : MonoBehaviour  
{  
    private const string TAG_GROUND = "Ground";
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _hitClip;

    private void OnCollisionEnter(Collision collision)  
    {  
        if (collision.gameObject.CompareTag(TAG_GROUND))  
        {  
            Debug.Log("CrateReporter: 바닥에 닿았습니다.");
            _source.PlayOneShot( _hitClip);
            
        }  
    }  
}