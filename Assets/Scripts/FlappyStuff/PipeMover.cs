using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Pipes;


    void Start()
    {
        int y = Random.Range(-1,35);//between 78 and 42

        //Pipes.position = new Vector3(-316, Random.Range(42,78), -80); 
        Pipes.localPosition  = new Vector3(0,Random.Range(-1,32), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
