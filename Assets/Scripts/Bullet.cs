using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( ShowAndHide(gameObject, 1.0f) );
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        EnemyController playerController = collision.gameObject.GetComponent<EnemyController>();
        if(collision.gameObject.GetComponent<EnemyController>() != null){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator ShowAndHide( GameObject gameObject, float delay )
    {
    gameObject.SetActive(true);
    yield return new WaitForSeconds(delay);
    }
}
