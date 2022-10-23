using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;
    // GameOver _over;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        // SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
    
}

