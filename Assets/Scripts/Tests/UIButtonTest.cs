using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonTest : MonoBehaviour
{

    public AudioSource source; 
        public AudioClip clip1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void PlaySound(){
        source.PlayOneShot(clip1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
