using System.Collections.Generic;
using System.Collections; 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;


public class GrapplingGun : MonoBehaviour {



    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, player, spawnpoint, lefthand, righthand, visibleGunTip;
    MeshRenderer GunTipMesh;
    public Camera MainCamera; 
    public float AimAssistSize = 1; 
    private float maxDistance = 100f;
    [SerializeField] public float PullForceScale, LookPullForce;
    private SpringJoint joint;
    [SerializeField] private InputActionReference GrappleActionReference;
    [SerializeField] private InputActionReference GrappleStopActionReference;
    [SerializeField] private InputActionReference ReSpawn; 
    
    //Haptics
    public XRBaseController BuzzController; 
    public float grappleBuzzAmp = 0.5f;  
    public float grappleBuzzDuration = 1f; 
    //audio
    public AudioSource source; 
    public AudioClip clip; 


    void Awake() {
        lr = GetComponent<LineRenderer>();
        GunTipMesh = visibleGunTip.GetComponent<MeshRenderer>();
    }

    void Update() {

            GrappleActionReference.action.performed += StartGrapple;

            GrappleStopActionReference.action.performed += StopGrapple;

            ReSpawn.action.performed += Re_Spawn;

            if(!GunTipMesh.enabled){
                StopGrappleNoButton(); 
            } 
 
            
           // StopGrapple(); 
 
    }

    //Called after Update
    void LateUpdate() {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple(InputAction.CallbackContext obj) {
        RaycastHit hit;
        if (Physics.Raycast(gunTip.position, /*AimAssistSize, */gunTip.forward, out hit, maxDistance, whatIsGrappleable) && GunTipMesh.enabled) {    //this likely needs to change to be a raycast from the gun not the camera
            StopGrapple(obj); 
            source.PlayOneShot(clip); 
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;


            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
            
            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            //joint.minDistance = distanceFromPoint * 0.25f;
            joint.minDistance = distanceFromPoint * 0.05f;
            //Adjust these values to fit your game.
            // joint.spring = 4.5f;
            // joint.damper = 7f;
            // joint.massScale = 4.5f;
            joint.spring = 5f;
            joint.damper = 5f;
            joint.massScale = 5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
     void StopGrapple(InputAction.CallbackContext obj) {
        lr.positionCount = 0;
        Destroy(joint);
        joint = null; 
    }
    public void StopGrappleNoButton() {
        lr.positionCount = 0;
        Destroy(joint);
        joint = null; 
    }

    private Vector3 currentGrapplePosition;
    
    void DrawRope() {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);
        
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
        Vector3 direction = currentGrapplePosition - gunTip.position;

        Ray ray = MainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        Vector3 targetPoint = ray.GetPoint(75);
        Vector3 faceForward = player.position - targetPoint; 
        BuzzController.SendHapticImpulse(grappleBuzzAmp,grappleBuzzDuration); 
        player.GetComponent<Rigidbody>().AddForce(direction.normalized * PullForceScale /* direction.magnitude / 10*/, ForceMode.Impulse);  //add a rigid body here for the player, it probably wont work otherwise
        player.GetComponent<Rigidbody>().AddForce(faceForward.normalized * PullForceScale * LookPullForce/* direction.magnitude / 10*/, ForceMode.Impulse);  //you could also try adding a force in the direction the player is looking

    }

    public bool IsGrappling() {
        return joint != null;
    }

    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }

    void Re_Spawn(InputAction.CallbackContext obj) {
        player.position = spawnpoint.position;     
        righthand.position = spawnpoint.position;
        lefthand.position = spawnpoint.position;    
        player.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
    }
}
