using UnityEngine;

public class DuckingState : HeroineState
{
    private int chargeTime = 0;

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Ducking");
        heroine.transform.localScale = new Vector3(1, 0.5f, 1);
    }

    public override HeroineState HandleInput(Heroine heroine)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            return new StandingState();
        }
        return null;
    }

    public override void Update(Heroine heroine)
    {
        chargeTime++;
        if (chargeTime > float.MaxValue /* MAX_VALUE */)
        {
            // TODO: Superbomb
            // Heroine.Superbomb();
        }
    }
}
