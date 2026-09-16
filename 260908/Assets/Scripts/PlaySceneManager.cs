using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;

    private void Start()
    {
        _pauseMenuUI.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.Instance.Run();
    }

    private void Update()
    {
        InputPauseKey();
    }
 
    private void InputPauseKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Pause();
            _pauseMenuUI.SetActive(true);
        }
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }
    
    public void ReturnToPlay()
    {
        GameManager.Instance.Run();
        _pauseMenuUI.SetActive(false);
    }
}
