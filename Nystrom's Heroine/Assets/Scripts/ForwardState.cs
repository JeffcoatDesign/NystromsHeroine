using UnityEngine;

public class ForwardState : HeroineState
{
    private bool _isMoving = true;
    private float _forwardSpeed = 400f;
    private Rigidbody _rb;
    private float _moveStartTime;
    private float _moveWaitTime = 0.2f;

    public override void Enter(Heroine heroine)
    {
        _moveStartTime = Time.time;
        _rb = heroine.GetComponent<Rigidbody>();
        if (_rb != null)
            _rb.AddForce(_forwardSpeed * Vector3.forward);
    }

    public override HeroineState HandleInput(Heroine heroine)
    {
        if (!_isMoving && (Time.time - _moveStartTime > _moveWaitTime))
            return new AlteredState();
        return null;
    }

    public override void Update(Heroine heroine)
    {

        _isMoving = (_rb.velocity.magnitude != 0f);
    }
}
