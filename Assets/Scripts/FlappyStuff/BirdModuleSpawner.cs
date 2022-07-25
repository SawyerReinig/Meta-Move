using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdModuleSpawner : MonoBehaviour
{

     public GameObject Module;
     public Transform nextModPoint;
     public int modCount; 
     public Vector3 spacing; 
  

    // Start is called before the first frame update
    void Start()
    {
        for(int M = 0; M < modCount; M++){
                nextModPoint.localPosition = nextModPoint.localPosition + spacing;
                GameObject CurrentModule = Instantiate(Module, nextModPoint.localPosition, Quaternion.identity);
                //CurrentModule.transform.SetParent(nextModPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
