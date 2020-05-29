using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    // public varaibles
    public GameManager gameManager;
    public float speed;

    // private varaibles
    private float lowestBallY;

    private void Start() {
        lowestBallY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float lowestActiveBall = lowestBallY;
        for (int i = 0; i < gameManager.activeBalls.Count; i++)
        {
            float y = gameManager.activeBalls[i].transform.position.y;
            if (y < lowestActiveBall)
            {
                lowestActiveBall = y;
            }
        }

        if (lowestActiveBall != lowestBallY)
        {
            lowestBallY = lowestActiveBall;
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, lowestBallY, this.transform.position.z), Time.deltaTime * speed);
            // this.transform.position = new Vector3(this.transform.position.x, lowestBallY, this.transform.position.z);
        }
    }
}
