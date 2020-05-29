using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public varaibles
    public Balls[] startBalls;
    public Transform[] holesTomake;
    public float radius;
    public TouchController cam;
    public List<Balls> activeBalls;
    public GameObject endScreen;

    // private varaibles

    // Start is called before the first frame update
    void Start()
    {
        foreach (Balls ball in startBalls)
        {
            ball.TransitionToState(ball.activeState);
        }

        foreach (Transform tf in holesTomake)
        {
            cam.defromToHoles(tf.position, radius);
        }
    }

    internal void showGameOver()
    {
        Invoke("activateEndScreen", 7f);
    }

    private void activateEndScreen()
    {
        endScreen.SetActive(true);
    }

    internal void startGame()
    {
        throw new NotImplementedException();
    }

    internal void restartGame()
    {
        throw new NotImplementedException();
    }

    public void endGame()
    {
        throw new NotImplementedException();
    }
}
