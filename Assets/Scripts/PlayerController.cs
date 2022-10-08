using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    private Rigidbody2D body;
    // public Animation anime;
    // bool keyPressed;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    // public LayerMask groundLayers;
    // public BoxCollider2D col;
    private bool doubleJump;

    public void KillPlayer()
    {
        Debug.Log("player killed by enemy");
        //Destroy(gameObject);
        // animator.SetBool("Death", true);
        // if(health)
        // ReloadLevel();
    }

    // int Health = 100; 
    
    // public bool isDead(){
    //     get()
    //     {
    //         return Health == 0;
    //     }
    // }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }



    public void PickUpKey(){
        Debug.Log("Player picked Up the key");
        scoreController.IncreaseScore(10);
    }

    private void Awake(){
        // Debug.Log("Palyer controller awake");
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // body = gameObject.GetComponent<Rigidbody2D>();
        // col = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col){
        // if(col.collider){/
            isGrounded = true;
            if(isGrounded && !Input.GetButton("Jump")){
            doubleJump = false;
            animator.SetBool("Jump", !isGrounded);
        }
        // }
        // else
            // isGrounded = false;
        
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        // float jump = Input.GetAxisRaw("Jump");

        Movecharacter(horizontal);
        PlayMovementAnimation(horizontal);
        // if (Input.GetButtonDown("Jump"))
            JumpAnimation();
        Crouch();
        Dead();
        
    }

    private void JumpAnimation(){
        if(Input.GetButton("Jump")){

            if(isGrounded || doubleJump){
                // Debug.Log("Jump"+jump);
                animator.SetBool("Jump", true);

                body.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
                
                isGrounded = false;
                //animator.SetBool("Speed", true);
                //animator.SetFloat("Speed", 0);
                doubleJump = !doubleJump;
            }
            
        }
        // else{
        //     // Debug.Log("NotJump");
        //     animator.SetBool("Jump", false);
        // }
         animator.SetFloat("Yvelocity",body.velocity.y);   
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

    public void Dead(){
        if(this.transform.position.y < -8){
            animator.SetTrigger("Death");
            Application.Quit();
        }
        // animator.SetTrigger("Death");
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
    