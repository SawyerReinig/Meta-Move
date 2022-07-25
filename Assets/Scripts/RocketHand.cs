using System.Collections.Generic;
using System.Collections; 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;




public class RocketHand : MonoBehaviour
{

[SerializeField] private InputActionReference BooperBoosterButton;
[SerializeField] private float RocketForce = 50.0f;

    public Transform BoosterCylinder, BoosterPoint, player, RocketBack;
    MeshRenderer RocketBackMesh;
    private CapsuleCollider _collider;
   [SerializeField] Rigidbody _body;
    private bool boosterPressed = false; 
    public AudioSource source; 
    public AudioClip clip; 
    public ActionBasedController controller; 
    int fuel = 1000; 
    public float fireRate = 1f;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        RocketBackMesh = RocketBack.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float gripValue = controller.selectAction.action.ReadValue<float>(); 
        BooperBoosterButton.action.performed += BoosterFunction;
        if(gripValue == 1 && fuel > 0 && RocketBackMesh.enabled){
            Vector3 BoosterDirection = BoosterPoint.position - BoosterCylinder.position;
            _body.AddForce(BoosterDirection.normalized * RocketForce * gripValue);
            if(Time.time > nextFire){
                nextFire = Time.time + fireRate;
                source.PlayOneShot(clip);

            }
            fuel--; 
        }
        else if(fuel < 1000){
            fuel++; 
        }
      



    }

   private void BoosterFunction(InputAction.CallbackContext obj){
       if(!boosterPressed){
            boosterPressed = true; 
       }
       else{
            boosterPressed = false; 
       } 
      
    }
}
