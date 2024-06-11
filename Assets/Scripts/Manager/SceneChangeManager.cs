using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public int SceneIndex = 1;
    public string[] GameScenes;
    Scene scene;

    public static SceneChangeManager Instance { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        SceneManager.LoadScene(GameScenes[1], LoadSceneMode.Additive);
    }
    private void Update()
    {
        if (SceneIndex >= 2)
        {
            DeactiveScene(SceneIndex - 1);
        }
    }

    public void DeactiveScene(int sceneIndex)
    {
        scene = SceneManager.GetSceneByName(GameScenes[sceneIndex]);
        foreach (GameObject go in scene.GetRootGameObjects())
        {
            go.SetActive(false);
        }
    }

    public void ActiveScene(string sceneName)
    {
        SceneIndex = CheckScene(sceneName);
        scene = SceneManager.GetSceneByName(GameScenes[SceneIndex + 2]);
        if (scene.IsValid())
        {
        }
        else
        {
            SceneManager.LoadScene(GameScenes[SceneIndex + 2], LoadSceneMode.Additive);
        }

    }

    int CheckScene(string sceneName)
    {
        for (int i = 0; i < GameScenes.Length; i++)
        {
            if (sceneName == GameScenes[i])
            {
                return i;
            }
        }
        return -1;
    }
}
