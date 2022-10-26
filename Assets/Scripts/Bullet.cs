using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.GetComponent<EnemyController>() != null){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
