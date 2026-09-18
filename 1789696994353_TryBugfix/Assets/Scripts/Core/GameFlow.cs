using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    private const string SCENE_GAME = "Game";

    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        InitRound();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
    }

    // [BUG-09] 원인 : `ShowGameOver` 함수의 `Time.timeScale`의 값을 통해 게임의 정지를 구현하였으나,
    //                 재시작 버튼과 연결되어있는 `Restart` 함수에서 이를 수정하지 않아 그대로 정지상태
    //          수정 : `Restart` 함수에서 `Time.timeScale` 값을 `1f`로 다시 설정, 다시 재생되도록 수정
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SCENE_GAME);
    }

    private void InitRound()
    {
        GameManager.Instance.ResetScore();
        _gameOverPanel.SetActive(false);
    }
}
