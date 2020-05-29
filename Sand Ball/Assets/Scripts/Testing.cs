using UnityEngine;

public class Testing : MonoBehaviour
{
    Rigidbody rigidbod;

    // Start is called before the first frame update
    void Start()
    {
        rigidbod = this.GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        rigidbod.AddForce(Vector3.forward * 4);
    }
}
