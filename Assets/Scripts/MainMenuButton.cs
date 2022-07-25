using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MainMenuButton : MonoBehaviour
{

        [SerializeField] private InputActionReference MainMenu_Button; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         MainMenu_Button.action.performed += GoToMainMenuAsync;
    }

     public void GoToMainMenuAsync(InputAction.CallbackContext obj){
        
        StartCoroutine(GoToMainMenuRoutineAsync(1)); 
    }

    IEnumerator GoToMainMenuRoutineAsync(int sceneIndex){

        
       AsyncOperation operation =  SceneManager.LoadSceneAsync(sceneIndex); 
       operation.allowSceneActivation = false; 

       float timer = 0; 
       while(!operation.isDone){
        timer += Time.deltaTime; 
        yield return null; 
       }
       operation.allowSceneActivation = true; 
        yield return new WaitForSeconds(0.1f);
        
    }
}
