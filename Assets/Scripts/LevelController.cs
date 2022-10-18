using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // LobbyController LB;
    // LB.GetComponent<PlayerController>;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.GetComponent<PlayerController>() != null){
            Debug.Log("Level Finished By player");
            // LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            LevelManager.Instance.MarkCurrentLevelComplete();
            // LB.Play
            // LobbyController.PlayGame();
            

        }
    }
    
}
