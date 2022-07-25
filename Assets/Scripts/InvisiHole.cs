using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public class InvisiHole : MonoBehaviour
{
    public Transform wall_1, wall_2, wall_3, wall_4; 
    MeshRenderer mesh1, mesh2, mesh3, mesh4; 

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Math.Abs(value) < deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()         
    {
        _isPressed = true;
        onPressed.Invoke();
        mesh1 = wall_1.GetComponent<MeshRenderer>(); 
        mesh2 = wall_2.GetComponent<MeshRenderer>(); 
        mesh3 = wall_3.GetComponent<MeshRenderer>(); 
        mesh4 = wall_4.GetComponent<MeshRenderer>(); 

        mesh1.enabled = !mesh1.enabled; 
        mesh2.enabled = !mesh2.enabled; 
        mesh3.enabled = !mesh3.enabled; 
        mesh4.enabled = !mesh4.enabled; 

    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
    }
    
}
