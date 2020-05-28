﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDeformer : MonoBehaviour
{
    //public references
    public float radiusOfDeformation;
    public float powerOfDeformation;
    public GameObject cylinderPrefab;


    // private references
    MeshFilter meshFilter;
    Mesh mesh;
    MeshCollider col;
    Vector3[] verts;

    private void Start()
    {
        meshFilter = this.GetComponent<MeshFilter>();
        col = this.GetComponent<MeshCollider>();
        mesh = meshFilter.mesh;
        verts = mesh.vertices;
    }

    public void deformThePlane(Vector3 positionToDeform)
    {
        Vector3 hitpoint = positionToDeform;
        positionToDeform = this.transform.InverseTransformPoint(positionToDeform);

        for (int i = 0; i < verts.Length; i++)
        {
            float dist = (verts[i] - positionToDeform).sqrMagnitude;

            if (dist < radiusOfDeformation)
            {
                verts[i] -= Vector3.up * powerOfDeformation;
            }

        }
        mesh.vertices = verts;
        col.sharedMesh = mesh;
    }
}
