using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderSCRIPT : MonoBehaviour
{
    public static SceneLoaderSCRIPT Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}