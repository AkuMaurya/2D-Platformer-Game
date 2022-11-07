using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
     public GameObject levelController;
    // LobbyController LB;
    // LB.GetComponent<PlayerController>;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.GetComponent<PlayerController>() != null){
            Debug.Log("Level Finished By player");
            // LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            LevelManager.Instance.MarkCurrentLevelComplete();
            Debug.Log("Level Finished By player");
           
            levelController.SetActive(true);
            // LB.Play
            // LobbyController.PlayGame();
            

        }
    }
    
}
