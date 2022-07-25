using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class DingHole : MonoBehaviour
{

    public Transform hole, player; 
    Collider holeCube; 
    public AudioSource source; 
    public AudioClip clip; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "XR Origin"){
            holeCube = hole.GetComponent<Collider>(); 

            holeCube.enabled = !holeCube.enabled;
            source.PlayOneShot(clip);

        }
    }
}
