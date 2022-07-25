using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

        public Transform ballpushpoint, ballgoal;
        private CapsuleCollider _collider;
        [SerializeField] Rigidbody _ball;
        [SerializeField] private float difficulty, lurchForce; 
        public float fireRate = 1f;
        private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(true){
            Vector3 ballghostDirection = ballgoal.position - ballpushpoint.position;
            _ball.AddForce(ballghostDirection.normalized * difficulty);

            if(Time.time > nextFire){
                nextFire = Time.time + fireRate;
                
                
                switch(Random.Range(0,4)){
                
                    case 0:
                    _ball.AddForce(Vector3.forward * lurchForce);
                    break; 

                    case 1:
                    _ball.AddForce(Vector3.left * lurchForce);
                    break; 

                    case 2:
                    _ball.AddForce(Vector3.back * lurchForce);
                    break;
                    
                    default:
                    _ball.AddForce(Vector3.up * lurchForce);
                    break; 
                }
            }
        }
    }
}
