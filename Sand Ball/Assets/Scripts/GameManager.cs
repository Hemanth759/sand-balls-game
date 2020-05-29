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

    // Update is called once per frame
    void Update()
    {
        
    }
}
