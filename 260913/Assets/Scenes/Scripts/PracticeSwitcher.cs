using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeSwitcher : MonoBehaviour
{
    private const string SCENE_A = "StaticPracticeA";
    private const string SCENE_B = "StaticPracticeB";
    
    private string currentScene;
    private string nextScene;

    private void Update()
    {
        ReadSceneKey();
    }

    private void ReadSceneKey()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            MoveToOtherScene();
        }
    }

    private void MoveToOtherScene()
    {
        currentScene = SceneManager.GetActiveScene().name;
        nextScene = currentScene == SCENE_A ? SCENE_B : SCENE_A;
        
        SceneManager.LoadScene(nextScene);
    }
}
