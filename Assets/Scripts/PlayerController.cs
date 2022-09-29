using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D body;
    // public Animation anime;
    // bool keyPressed;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    // public LayerMask groundLayers;
    // public BoxCollider2D col;


    private void Awake(){
        Debug.Log("Palyer controller awake");
        body = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // body = gameObject.GetComponent<Rigidbody2D>();
        // col = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(){
        isGrounded = true;
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");

        Movecharacter(horizontal);
        PlayMovementAnimation(horizontal);
        JumpAnimation(jump);
        Crouch();
        Dead();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    private void JumpAnimation(float jump){
        if(jump >0 && isGrounded){
            animator.SetTrigger("Jump");
            body.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Force);
            isGrounded = false;
        }
        else 
            animator.SetBool("Jump", false);
    }

    private void Movecharacter(float horizontal){
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if(horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(horizontal>0){
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale = scale;        
    }

    private void Crouch(){
        if(Input.GetKey(KeyCode.LeftControl)){
            animator.SetBool("Crouch", true);
        }
        else{
            animator.SetBool("Crouch", false);
        }
    }

    private void Dead(){
        if(this.transform.position.y < -7){
            animator.SetBool("Death",true);
            Application.Quit();
        }
    }
}

  // private void PlayerJumpN_Crouch(){
    //     if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
    //         animator.SetBool("Jump", true);
    //         isGrounded = false;
    //     } 
    //     else if(Input.GetKey(KeyCode.LeftControl)){
    //         animator.SetBool("Crouch", true);
    //     }
    //     else {
    //         animator.SetBool("Jump", false);
    //         animator.SetBool("Crouch", false);
    //     }
    // }