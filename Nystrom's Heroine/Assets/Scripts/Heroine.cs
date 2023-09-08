using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroine : MonoBehaviour
{
    private HeroineState _state = new StandingState();

    private void Start()
    {
        _state.Enter(this);
    }

    private void Update()
    {
        HeroineState state = _state.HandleInput(this);
        if (state != null)
        {
            _state.Exit(this);
            _state = state;
            _state.Enter(this);
        }
        _state.Update(this);
    }
}
