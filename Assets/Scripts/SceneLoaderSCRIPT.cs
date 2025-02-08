using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderSCRIPT : MonoBehaviour
{
    public static SceneLoaderSCRIPT Instance;

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}