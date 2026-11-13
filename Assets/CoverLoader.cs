using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoverLoader : MonoBehaviour
{
    public float splashDuration = 2.5f;
    public string nextSceneName = "Level 1";

    void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(splashDuration);
        SceneManager.LoadScene(nextSceneName);
    }
}