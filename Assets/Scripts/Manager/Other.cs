using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public void OnChangeScene()
    {
        SceneManager.LoadScene("StartMap");
    }
}
