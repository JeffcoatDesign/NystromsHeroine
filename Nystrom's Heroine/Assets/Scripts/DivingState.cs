using UnityEngine;

public class DivingState : HeroineState
{
    private float _diveForce = 1000;
    private bool _isGrounded = false;

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Diving");
        Rigidbody rb = heroine.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(_diveForce * Vector3.down, ForceMode.Force);
        heroine.transform.localScale = new Vector3(1, 0.5f, 1);
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (_isGrounded)
            return new StandingState();
        return null;
    }

    public override void Update(Heroine heroine)
    {
        _isGrounded = Physics.Raycast(heroine.transform.position, -Vector3.up, 0.5f * heroine.transform.localScale.y);
    }
}
