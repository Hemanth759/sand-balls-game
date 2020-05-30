using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public varaibles
    public Balls[] startBalls;
    public Transform[] holesTomake;
    public float radius;
    public TouchController cam;
    public List<Balls> activeBalls;
    public GameObject endScreen;
    public Animator animator;

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

    public void showGameOver()
    {
        animator.SetTrigger("GameEnded");
    }

    internal void startGame()
    {
        animator.SetTrigger("StartGame");
    }

    internal void showNextButton()
    {
        animator.SetTrigger("ShowNext");
    }

    internal void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void endGame()
    {
        throw new NotImplementedException();
    }
}
