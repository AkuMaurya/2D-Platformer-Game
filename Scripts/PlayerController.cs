using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Awake(){
        Debug.Log("Palyer controller awake");
    }

    // private void OnCollisionEnter2D(Collision2D collision){
    //     Debug.Log("Collision: " + collision.gameObject.name);
    // }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        float jump = Input.GetAxisRaw("Vertical");
        if(jump > 0){
            animator.SetTrigger("Jump");
            // animator.SetBool("Jump", false);
        } 
        else if(jump < 0){
            animator.SetBool("Jump", false);
        }else{
            if(Input.GetKey(KeyCode.LeftControl)){
            animator.SetBool("Crouch", true);
            }else{
                animator.SetBool("Crouch", false);
            }
        }
        
        

 

        Vector3 scale = transform.localScale;
        if(speed < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed>0){
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

   
}
