using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlecontroller : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void PlayEffect(){
        gameObject.SetActive(true);
    }
}
