using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource whistleSource;
    public AudioSource crowdSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 2")
        {
            StopAllCoroutines();
            if (crowdSource != null && crowdSource.isPlaying)
                crowdSource.Stop();
            if (whistleSource != null && whistleSource.isPlaying)
                whistleSource.Stop();
            if (musicSource != null && !musicSource.isPlaying)
                musicSource.Play();
        }
    }

    public void StartMatchAudio()
    {
        StopAllCoroutines();
        StartCoroutine(PlayWhistleThenCrowd());
    }

    private IEnumerator PlayWhistleThenCrowd()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }

        if (crowdSource != null && crowdSource.isPlaying)
        {
            crowdSource.Stop();
        }

        if (whistleSource != null && whistleSource.clip != null)
        {
            whistleSource.Play();
            yield return new WaitForSeconds(whistleSource.clip.length);
        }

        if (crowdSource != null && crowdSource.clip != null)
        {
            crowdSource.Play();
        }
    }
}