using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // public Sprite[] lives;
    // public Image livesImageDisplay;

    // public void UpdateLives(int currentLives)
    // {
    //     Debug.Log("Player live: " + currentLives);
    //     livesImageDisplay.sprite = lives[currentLives]; 
    // }

    public GameObject heart1, heart2, heart3, GameOver;
    public static int health;

    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        GameOver.gameObject.SetActive(false);
    }

    public void Update(){

        // if(health>3){
        //     health = 3;
        // }
        // health -= 1;

        switch(health){    
        // case 3:   
        //     heart1.gameObject.SetActive(true);
        //     heart2.gameObject.SetActive(true);
        //     heart3.gameObject.SetActive(true);    
        // break;  
        case 2:    
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
        break;
        case 1:    
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
        break;
        case 0:    
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            GameOver.gameObject.SetActive(true);
        break;   
            }
    }
}
