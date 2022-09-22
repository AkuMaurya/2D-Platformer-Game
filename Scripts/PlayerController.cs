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

        // float jump = Input.GetAxisRaw("Vertical");
        // if(jump > 0){
        //     animator.SetTrigger("Jump");
        //     // animator.SetBool("Jump", false);
        // } 
        // else if(Input.GetKey(KeyCode.LeftControl)){
        //     animator.SetBool("Crouch", true);
        // }
        // else if(jump < 0){
        //     animator.SetBool("Jump", false);
        // }

        float VerticalInput = Input.GetAxis("Vertical");		

				JumpAnimation(VerticalInput);  
   
				if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
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

    public void Crouch(bool crouch)
    {
				//First, get the offset and size values from your collider while you are standing 
				//and note them down, this is the collider you want when your player is not in 
				//crouch mode.
				//Now, play the crouch animation and resize your collider, note down the values,
				//these are your values when your player is in crouch position
				//We will use these values in the next step.
        animator.SetBool("Crouch", crouch);
    }

		
		public void JumpAnimation(float vertical)
    {    
				if (vertical > 0 )
        {
            animator.SetTrigger("Jump");            
        }
    }
}
