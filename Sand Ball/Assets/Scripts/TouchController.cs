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

    // Start is called before the first frame update
    void Start()
    {
        cam = this.transform.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            doformMesh();
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
