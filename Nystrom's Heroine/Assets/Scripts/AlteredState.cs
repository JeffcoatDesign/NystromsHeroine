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
        GUIManager.instance.ShowObject(KeyCode.W, true);
        GUIManager.instance.ShowObject(KeyCode.E, true);
        GUIManager.instance.ShowObject(KeyCode.S, true);
    }
    public override void Exit(Heroine heroine)
    {
        GUIManager.instance.ShowObject(KeyCode.W, false);
        GUIManager.instance.ShowObject(KeyCode.E, false);
        GUIManager.instance.ShowObject(KeyCode.S, false);
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
