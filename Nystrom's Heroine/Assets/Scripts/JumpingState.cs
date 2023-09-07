using UnityEngine;

public class JumpingState : HeroineState
{
    private float _jumpForce = 500;
    private bool _isGrounded = false;
    private float _jumpStartTime;
    private float _jumpWaitTime = 0.2f;

    public override void Enter(Heroine heroine)
    {
        _jumpStartTime = Time.time;
        Debug.Log("Jumping");
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
        else if (Input.GetKeyDown(KeyCode.Space))
            return new DoubleJumpState();
        return null;
    }

    public override void Update(Heroine heroine)
    {
        if (Time.time - _jumpStartTime > _jumpWaitTime)
            _isGrounded = Physics.Raycast(heroine.transform.position, -Vector3.up, 0.5f);
    }
}
