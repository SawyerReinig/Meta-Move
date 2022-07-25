using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAKid : MonoBehaviour
{

        public AudioSource source; 
        public AudioClip clip1;
        public AudioClip clip2;
        public AudioClip clip3;
        public AudioClip defaultSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "Bullet(Clone)"){
            Destroy(col.gameObject); 
            switch(Random.Range(0,4)){
                
                case 0:
                source.PlayOneShot(clip1);
                break; 

                case 1:
                source.PlayOneShot(clip2);
                break; 

                case 2:
                source.PlayOneShot(clip3);
                break;
                
                default:
                source.PlayOneShot(defaultSound);
                break; 
            }
        }
    }


}
