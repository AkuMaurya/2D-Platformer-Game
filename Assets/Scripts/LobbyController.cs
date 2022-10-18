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
        // _over = gameObject.GetComponent<GameOver>();
        // _over.gameObject.SetActive(false);
        buttonPlay.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        // SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
}

