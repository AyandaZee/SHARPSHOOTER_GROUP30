using UnityEngine;
using UnityEngine.UI;

public class PlayButtonAudio : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnPlayClicked);
        }
    }

    private void OnPlayClicked()
    {
        if (GameAudioManager.instance != null)
        {
            GameAudioManager.instance.StartMatchAudio();
        }
    }
}