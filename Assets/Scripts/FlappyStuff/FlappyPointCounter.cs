using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPointCounter : MonoBehaviour
{
    public AudioSource source; 
    public AudioClip checkpointSound;
    bool passedPoint; 

    public ScoreKeeper ScoreShower; 
    //[SerializeField] List<GameObject> checkpoints; 
    // Start is called before the first frame update
    void Start()
    {
               

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider checkpoint){
        if(!passedPoint){
            ScoreShower.DisplayScore(ScoreShower.getScore() + 1); 
            source.PlayOneShot(checkpointSound);
            passedPoint = true; 
        }
    }

    
}
