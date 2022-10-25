using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOver gameOverController;
    public Animator animator;
    private Rigidbody2D body;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    private bool doubleJump = true;

    public void KillPlayer()
    {
        Debug.Log("player killed by enemy");
        if(UI_Manager.health < 1){
            Debug.Log("code reached here");
            gameOverController.PalyerDied();
            this.enabled = false;
        }
    }

    public void PickUpKey(){
        Debug.Log("Player picked Up the key");
        scoreController.IncreaseScore(10);
    }

    private void Awake(){
        // Debug.Log("Palyer controller awake");
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col){
            isGrounded = true;
            if(isGrounded && !Input.GetButton("Jump")){
            doubleJump = false;
            animator.SetBool("Jump", !isGrounded);
          
        }
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Movecharacter(horizontal);
        PlayMovementAnimation(horizontal);
        JumpAnimation();
        Crouch();
        Dead();
        AttackEnemy();
    }
    
    private void OnTrigger(Collider2D collision){
        if(collision.tag == "Enemy"){
            Destroy(collision.gameObject);
        }
    }

    private void AttackEnemy(){
        if(Input.GetKeyDown(KeyCode.F)){
            animator.SetBool("Attack", true);
        }
        else
            animator.SetBool("Attack", false);
    }

    private void JumpAnimation(){
        if(Input.GetButton("Jump")){

            if(isGrounded || doubleJump){
                animator.SetBool("Jump", true);
                body.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
                isGrounded = false;
                doubleJump = !doubleJump;
            }
        }
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
            // SoundManager.Instance.Play(Sounds.PlayerMove);
        }
        else if(horizontal>0){
            scale.x=Mathf.Abs(scale.x);
            // SoundManager.Instance.Play(Sounds.PlayerMove);
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
        
        }
    }
}

    