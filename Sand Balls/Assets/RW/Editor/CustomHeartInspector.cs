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

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(CustomHeart))]
public class CustomHeartInspector : Editor
{
    private CustomHeart mesh;
    private Transform handleTransform;
    private Quaternion handleRotation;

    private int selectedIndex = -1;
    private int assignIndex;

    void OnSceneGUI()
    {
        mesh = target as CustomHeart;
        handleTransform = mesh.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        if (mesh.oVertices == null) 
        {
            mesh.Init();
        }

        // Add Points
        if (mesh.editType.ToString() == "AddIndices")
        {
            for (int i = 0; i < mesh.oVertices.Length; i++)
            {
                ShowHandle(i);
            }
        } // Remove Points
        else if (mesh.editType.ToString() == "RemoveIndices")
        {
            for (int i = 0; i < mesh.oVertices.Length; i++)
            {
                ShowSelected(i);
            }
        }

        // Show/ Hide Transform Tool
        if (mesh.showTransformHandle)
        {
            Tools.current = Tool.Move;
        } 
        else
        {
            Tools.current = Tool.None;
        }
    }

    void ShowHandle(int index)
    {
        Vector3 point = handleTransform.TransformPoint(mesh.oVertices[index]);
        
        // Unselected vertex
        if (!mesh.selectedIndices.Contains(index))
        {
            Handles.color = Color.blue;
            if (Handles.Button(point, handleRotation, mesh.pickSize, mesh.pickSize, Handles.DotHandleCap))
            {
                selectedIndex = index;
            }
            
            if (selectedIndex == index)
            {
                if (assignIndex != index)
                {
                    assignIndex = mesh.targetIndex = index;
                    mesh.selectedIndices.Add(index);
                }
            }
        }
    }

    void ShowSelected(int index)
    {
        Vector3 point = handleTransform.TransformPoint(mesh.oVertices[index]);

        // Unselected vertex
        if (mesh.selectedIndices.Contains(index))
        {
            Handles.color = Color.red;
            if (Handles.Button(point, handleRotation, mesh.pickSize, mesh.pickSize, Handles.DotHandleCap))
            {
                selectedIndex = index;
            }
            
            if (selectedIndex == index)
            {
                if (assignIndex != index)
                {
                    assignIndex = mesh.targetIndex = index;
                    mesh.selectedIndices.Remove(index);
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        mesh = target as CustomHeart;

        if (GUILayout.Button("Clear Selected Vertices"))
        {
            Debug.Log("Editor Reset");
            assignIndex = 0;
            selectedIndex = -1;
            mesh.ClearAllData();
        }

        if (mesh.editType.ToString() != "None" && !Application.isPlaying)
        {
            if (GUILayout.Button("Show Normals"))
            {
                mesh.ShowNormals();
            }
        }
    }
}
