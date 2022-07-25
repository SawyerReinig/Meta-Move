using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : MonoBehaviour
{
     public AudioSource source; 
     public AudioClip clip1;
     public AudioClip thingBreaks;

     public GameObject itemToBeMined; 
     int itemHealth = 5; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "Hand Left" || col.gameObject.name == "Hand Right"){
            source.PlayOneShot(clip1);
            itemHealth--; 
            }
            if(itemHealth == 0){
            Destroy(itemToBeMined); 
            source.PlayOneShot(thingBreaks);
        }
        }
        
}
