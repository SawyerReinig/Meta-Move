using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Transform centerField, SoccerBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "SoccerBall"){
            SoccerBall.position = centerField.position; 
            SoccerBall.GetComponent<Rigidbody>().velocity = Vector3.zero; 
            SoccerBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
