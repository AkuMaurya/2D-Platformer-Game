using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] points;
    int current;
    // public Animator animator;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
            // UI_Manager ui_manager = collision.gameObject.GetComponent<UI_Manager>();
            // ui_manager.UpdateLives();
            UI_Manager.health -= 1;
            
            if(UI_Manager.health < 1){
                playerController.Dead();
            }
        }
    }

    void Update(){
        if(transform.position != points[current].position)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, points[current].position,speed*Time.deltaTime);
            // animator.SetBool( false);
            
        }
        else {
            Vector3 scale = this.transform.localScale;
            scale.x = -1f *scale.x;
            current = (current + 1) % points.Length;
            this.transform.localScale = scale;
        }
            
    }
}
