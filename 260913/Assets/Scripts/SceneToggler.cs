
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToggler : MonoBehaviour
{
    private const string SCENE_A = "StaticPracticeA";
    private const string SCENE_B = "StaticPracticeB";

    private void Update()
    {
        ReadSceneKey();
    }

    private void ReadSceneKey()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MoveToOtherScene();
        }
    }

    private void MoveToOtherScene()
    {
        string currentName = SceneManager.GetActiveScene().name;
        string nextName = currentName == SCENE_A ? SCENE_B : SCENE_A;
        
        SceneManager.LoadScene(nextName);
    }
}
