using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}