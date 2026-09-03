using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTuner : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private void Update()
    {
        ReadTuneKeys();
    }

    private void ReadTuneKeys()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _source.volume = 0.2f;
            Debug.Log($"AudioTuner: 볼륨을 {_source.volume}으로 바꿨습니다.");
        }
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            _source.pitch = 0.5f;
            Debug.Log($"AudioTuner: 피치를 {_source.pitch}로 바꿨습니다.");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _source.Stop();
            Debug.Log("AudioTuner: 배경음을 정지합니다.");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _source.Play();
            Debug.Log("AudioTuner: 배경음을 재생합니다.");
        }
    }
}
