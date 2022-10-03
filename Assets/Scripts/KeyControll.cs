using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControll : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("HEy u");
        if(collision.gameObject.GetComponent<PlayerController>() != null){
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            Destroy(gameObject);
        }
    }
}
