using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TouchController : MonoBehaviour
{
    // public references
    public GameObject cylinderPrefab;
    public float planeDistance;
    public GameObject board;


    // private references
    private PlaneDeformer[] sandPlanes;
    private Vector3[] planeCenters;
    private Ray ray;
    private RaycastHit hit;
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = this.transform.GetComponent<Camera>();
        sandPlanes = board.GetComponentsInChildren<PlaneDeformer>();
        planeCenters = new Vector3[sandPlanes.Length];
        for (int i = 0; i < planeCenters.Length; i++)
        {
            planeCenters[i] = sandPlanes[i].gameObject.transform.GetComponent<Renderer>().bounds.center;
        }
    }

    private void FixedUpdate()
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
            // sandPlanes.deformThePlane(hit.point);
            // check the distance of all hit distances
            for (int i = 0; i < planeCenters.Length; i++)
            {
                if ((planeCenters[i] - hit.point).sqrMagnitude < planeDistance)
                {
                    // deform this planes area;
                    sandPlanes[i].deformThePlane(hit.point);
                }
            }
            if (hit.transform.tag == "Ring")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    public void defromToHoles(Vector3 position, float radius) {
        for (int i = 0; i < planeCenters.Length; i++)
            {
                if ((planeCenters[i] - position).sqrMagnitude < planeDistance)
                {
                    // deform this planes area;
                    sandPlanes[i].puthole(position, radius);
                }
            }
    }
}
