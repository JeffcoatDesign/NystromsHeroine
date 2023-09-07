using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlteredState : HeroineState
{
    public override void Enter (Heroine heroine)
    {
        MeshRenderer mr = heroine.GetComponent<MeshRenderer>();
        if (mr != null)
            mr.material.color = Color.yellow;
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (Input.GetKeyDown(KeyCode.E))
            return new StandingState();
        else if (Input.GetKeyDown(KeyCode.W))
            return new ForwardState();
        else if (Input.GetKeyDown(KeyCode.S))
            return new BackwardsState();
        return null;
    }
}
