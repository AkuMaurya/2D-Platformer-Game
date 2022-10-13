using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] points;
    int current;
    // public Animator animator;
    public float speed;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            // animator.SetBool("Walk",true);
            animator.SetBool("Attack",true);
            UI_Manager.health -= 1;
            playerController.KillPlayer();
            
            Debug.Log(UI_Manager.health);
            if(UI_Manager.health < 1){
                playerController.Dead();
            }
            // animator.SetBool("Walk",false);
            animator.SetBool("Attack",false);
        }
            
    }

    void Update(){
        if(transform.position != points[current].position)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, points[current].position,speed*Time.deltaTime);
        }
        else {
            Vector3 scale = this.transform.localScale;
            scale.x = -1f *scale.x;
            current = (current + 1) % points.Length;
            this.transform.localScale = scale;
        }
            
    }
}
