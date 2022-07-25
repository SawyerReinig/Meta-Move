using System;
using UnityEngine;
using UnityEngine.Events;

public class SoccerButtonScript : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    public Transform player, SoccerRoomPoint, handright, handleft; 

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
        player.position = SoccerRoomPoint.position; 
        handright.position = SoccerRoomPoint.position;
        handleft.position = SoccerRoomPoint.position;

        player.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
    }
    
    
    
    
    
}