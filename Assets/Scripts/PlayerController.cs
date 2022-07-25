using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;


    private CapsuleCollider _collider;
    private Rigidbody _body;

   private bool IsGrounded => Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 2.0f), Vector3.down, 2.0f);
    
    void Start()
    {
        // _xrRig = GetComponent<XROrigin>();
        _collider = GetComponent<CapsuleCollider>();
        _body = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        jumpActionReference.action.performed += OnJump;
        // var center = _xrRig.cameraInRigSpacePos;
        // _collider.center = new Vector3(center.x, _collider.center.y, center.z);
        // _collider.height = _xrRig.cameraInRigSpaceHeight;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        //if (!IsGrounded) return;
        _body.AddForce(Vector3.up * jumpForce);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
