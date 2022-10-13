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
        buttonRestart.onClick.AddListener(ReloadLevel);

    }

    public void PalyerDied(){
        Debug.Log("Sajan");
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        Debug.Log("Reloading scene...");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
