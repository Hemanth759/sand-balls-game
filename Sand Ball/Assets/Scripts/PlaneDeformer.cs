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

    private void Awake()
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
        bool somethingDeformed = false;

        for (int i = 0; i < verts.Length; i++)
        {
            float dist = (verts[i] - positionToDeform).sqrMagnitude;

            if (dist < radiusOfDeformation)
            {
                verts[i] -= Vector3.up * powerOfDeformation;
                somethingDeformed = true;
            }

        }
        if (somethingDeformed)
        {
            mesh.vertices = verts;
            col.sharedMesh = mesh;
            // Instantiate(cylinderPrefab, new Vector3(hitpoint.x, hitpoint.y, hitpoint.z + 0.11f), Quaternion.Euler(-90f, 0f, 0f));
        }
    }

    public void puthole(Vector3 positionToDeform, float radius)
    {
        Vector3 hitpoint = positionToDeform;
        positionToDeform = this.transform.InverseTransformPoint(positionToDeform);
        bool somethingDeformed = false;

        for (int i = 0; i < verts.Length; i++)
        {
            float dist = (verts[i] - positionToDeform).sqrMagnitude;

            if (dist < radius)
            {
                verts[i] -= Vector3.up * powerOfDeformation;
                somethingDeformed = true;
            }

        }
        if (somethingDeformed)
        {
            mesh.vertices = verts;
            col.sharedMesh = mesh;
            // Instantiate(cylinderPrefab, new Vector3(hitpoint.x, hitpoint.y, hitpoint.z + 0.11f), Quaternion.Euler(-90f, 0f, 0f));
        }
    }
}
