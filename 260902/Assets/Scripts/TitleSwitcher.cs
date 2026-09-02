using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSwitcher : MonoBehaviour
{
    private const string SCENE_PLAY = "PLAY";

    private void Update()
    {
        ReadSceneKeys();
    }

    private void ReadSceneKeys()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log($"TitleSwitcher: {SCENE_PLAY} 씬을 부릅니다.");
            SceneManager.LoadScene(SCENE_PLAY);
        }
    }
}
