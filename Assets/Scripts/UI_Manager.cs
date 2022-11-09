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

    public GameObject heart1, heart2, heart3;
    public static int health;
    public Animator animator;

    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }
int i = 4;
    public void Update(){
        switch(health){    
        // case 3:   
        //     heart1.gameObject.SetActive(true);
        //     heart2.gameObject.SetActive(true);
        //     heart3.gameObject.SetActive(true);    
        // break;  
        case 2:    
            // heart1.gameObject.SetActive(true);
            // heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
            if(i==4){
                animator.SetTrigger("Hurt");
            }
            i=3;
            
        break;
        case 1:    
            // heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            if(i==3){
                animator.SetTrigger("Hurt");
            }
            i=2;
            // heart3.gameObject.SetActive(false);
        break;
        }
        if(health <= 0){
            heart1.gameObject.SetActive(false);
            if(i==2){
                animator.SetTrigger("Hurt");
            }
            
            // heart2.gameObject.SetActive(false);
            // heart3.gameObject.SetActive(false);
        }       
    }
}
