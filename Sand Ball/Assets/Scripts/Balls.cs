using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    // public varaibles
    public GameManager gameManager;

    // private varaibles
    private BallBaseState currentState;

    public BallBaseState CurrentState { get => currentState; }

    public readonly BallActiveState activeState = new BallActiveState();
    public readonly BallInactiveState inactiveState = new BallInactiveState();

    private void Start() {
        gameManager = Object.FindObjectOfType<GameManager>();
        this.TransitionToState(this.inactiveState);
    }

    private void Update() {
        
    }

    public void TransitionToState(BallBaseState state) {
        this.currentState = state;
        this.currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision) {
        this.currentState.OnCollisionEnter(this, collision);
    }
}
