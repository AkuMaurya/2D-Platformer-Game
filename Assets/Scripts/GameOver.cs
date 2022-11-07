using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button buttonRestart;

    private void Awake(){
        // gameObject.SetActive(false);
        Debug.Log("Restarted");
        buttonRestart.onClick.AddListener(ReloadLevel);
    }

    public void PalyerDied(){
        Debug.Log("Didnt reached");
        // SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        this.gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        Debug.Log("Reloading scene...");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
