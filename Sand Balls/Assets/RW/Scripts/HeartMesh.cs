/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartMesh : MonoBehaviour
{
    Mesh originalMesh;
    Mesh clonedMesh;
    MeshFilter meshFilter;

    [HideInInspector]
    public int targetIndex;

    [HideInInspector]
    public Vector3 targetVertex;

    [HideInInspector]
    public Vector3[] originalVertices;

    [HideInInspector]
    public Vector3[] modifiedVertices;

    [HideInInspector]
    public Vector3[] normals;

    [HideInInspector]
    public bool isMeshReady = false;
    public bool isEditMode = true;
    public bool showTransformHandle = true;
    public List<int> selectedIndices = new List<int>();
    public float pickSize = 0.01f;



    void Start()
    {
        Init();
    }

    public void Init()
    {
        meshFilter = GetComponent<MeshFilter>();
        isMeshReady = false;

        if (isEditMode)
        {
            originalMesh = meshFilter.sharedMesh;
            clonedMesh = new Mesh();
            clonedMesh.name = "clone";
            clonedMesh.vertices = originalMesh.vertices;
            clonedMesh.triangles = originalMesh.triangles;
            clonedMesh.normals = originalMesh.normals;
            meshFilter.mesh = clonedMesh;

            originalVertices = clonedMesh.vertices;
            normals = clonedMesh.normals;
            Debug.Log("Init & Cloned");
        }
        else
        {
            originalMesh = meshFilter.mesh;
            originalVertices = originalMesh.vertices;
            normals = originalMesh.normals;
            modifiedVertices = new Vector3[originalVertices.Length];
            for (int i = 0; i < originalVertices.Length; i++)
            {
                modifiedVertices[i] = originalVertices[i];
            }
        }

    }

    public void StartDisplacement()
    {
    }


    void DisplaceVertices(Vector3 targetVertexPos, float force, float radius)
    {
    }

    public void ClearAllData()
    {
    }

    public Mesh SaveMesh()
    {
        Mesh nMesh = new Mesh();

        return nMesh;
    }

    #region HELPER FUNCTIONS

    static float LinearFalloff(float dist, float inRadius)
    {
        return Mathf.Clamp01(0.5f + (dist / inRadius) * 0.5f);
    }

    static float GaussFalloff(float dist, float inRadius)
    {
        return Mathf.Clamp01(Mathf.Pow(360, -Mathf.Pow(dist / inRadius, 2.5f) - 0.01f));
    }

    static float NeedleFalloff(float dist, float inRadius)
    {
        return -(dist * dist) / (inRadius * inRadius) + 1.0f;
    }

    #endregion
}
