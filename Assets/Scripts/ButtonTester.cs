using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;


public class ButtonTester : MonoBehaviour
{

    [SerializeField] private InputActionReference jumpActionReference;


    void PrintFunction(InputAction.CallbackContext obj){
        print("hey, your button is working");
    }
    // Start is called before the first frame update
    void Start()
    {
   
        
    }

    // Update is called once per frame
    void Update()
    {
             jumpActionReference.action.performed += PrintFunction; 

             
        }
    }



