using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

        public int playerpoints; 
        public Text _title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore(playerpoints); 
    }
      public int getScore(){
        return playerpoints; 
    }

    public void DisplayScore(int points){
        playerpoints = points; 

        _title.text = "High Score: " + points.ToString();
        

    }
}
