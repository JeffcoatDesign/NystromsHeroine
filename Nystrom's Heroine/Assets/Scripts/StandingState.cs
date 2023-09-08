using UnityEngine;
public class StandingState : HeroineState {
    public override void Enter(Heroine heroine)
    {
        Debug.Log("Standing");
        heroine.transform.localScale = new Vector3(1, 1, 1);
        MeshRenderer mr = heroine.GetComponent<MeshRenderer>();
        if (mr != null)
            mr.material.color = Color.white;
        GUIManager.instance.ShowObject(KeyCode.LeftShift, true);
        GUIManager.instance.ShowObject(KeyCode.Space, true);
        GUIManager.instance.ShowObject(KeyCode.E, true);
    }
    public override void Exit(Heroine heroine)
    {
        GUIManager.instance.ShowObject(KeyCode.LeftShift, false);
        GUIManager.instance.ShowObject(KeyCode.Space, false);
        GUIManager.instance.ShowObject(KeyCode.E, false);
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (Input.GetKey(KeyCode.LeftShift))
            return new DuckingState();
        else if (Input.GetKeyDown(KeyCode.Space))
            return new JumpingState();
        else if (Input.GetKeyDown(KeyCode.E))
            return new AlteredState();
        return null;
    }
}