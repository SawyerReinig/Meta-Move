using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TreeMaker : MonoBehaviour
{
    public GameObject tree;
    public Transform growCast; 
    public LayerMask Growable;
    public int numberOfStuffs; 

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfStuffs; i++){
        int x = Random.Range(100,295);
        int z = Random.Range(-57,140);
        int y = 100;

        growCast.position =  new Vector3(x, y, z); 
        // GameObject currentTree = Instantiate(tree, growCast.position, Quaternion.identity);
        RaycastHit hit;
            if (Physics.Raycast(growCast.position, -growCast.up, out hit, 1000, Growable)) {

                GameObject currentTree = Instantiate(tree, hit.point, Quaternion.identity);
            }
           

        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
