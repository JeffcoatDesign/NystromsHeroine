using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpState : HeroineState
{
    private float _jumpForce = 300;
    private bool _isGrounded = false;
    private float _jumpStartTime;
    private float _jumpWaitTime = 0.2f;

    public override void Enter(Heroine heroine)
    {
        _jumpStartTime = Time.time;
        Debug.Log("Double Jumping");
        Rigidbody rb = heroine.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(_jumpForce * Vector3.up, ForceMode.Force);
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (_isGrounded)
            return new StandingState();
        else if (Input.GetKey(KeyCode.LeftShift))
            return new DivingState();
        return null;
    }

    public override void Update(Heroine heroine)
    {
        if (Time.time - _jumpStartTime > _jumpWaitTime)
            _isGrounded = Physics.Raycast(heroine.transform.position, -Vector3.up, 0.5f);
    }
}
