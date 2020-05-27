using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TouchController : MonoBehaviour
{
    // public references

    // private references
    private Ray ray;
    private RaycastHit hit;
    private Camera cam;
    int temp;
    
    // Start is called before the first frame update
    void Start()
    {
        temp = 0;
        cam = this.transform.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("deforming " + temp);
            temp++;
            // doformMesh();
        }
    }

    private void doformMesh()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            PlaneDeformer sandPlane;
            if (hit.transform.TryGetComponent<PlaneDeformer>(out sandPlane))
                sandPlane.deformThePlane(hit.point);
        }
    }
}
