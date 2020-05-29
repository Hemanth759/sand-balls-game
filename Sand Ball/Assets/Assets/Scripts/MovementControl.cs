using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {
	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public Transform[] tyreMeshes = new Transform[4];
	public float maxTorque = 50.0f;
	private Rigidbody m_rigidbody;
	public Transform centerOfMass;

	void start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
		m_rigidbody.centerOfMass = centerOfMass.localPosition;
	}
	
	void Update()
	{
		UpdateMeshesPositions ();
	}
	
	void FixedUpdate()
	{// 0 is front left and 1 is front right
		float steer = Input.GetAxis ("Horizontal");
		float fixedAngel = steer * 45f;
		wheelColliders [0].steerAngle = fixedAngel;
		wheelColliders [1].steerAngle = fixedAngel;
		
		float acceleration = Input.GetAxis ("Vertical");
		for (int i = 0; i < 4; i++) 
		{
			wheelColliders[i].motorTorque = acceleration * maxTorque;
		}
	}
	
	void UpdateMeshesPositions()
	{
		for(int i = 0; i < 4 ; i++)
		{
			Quaternion quat;
			Vector3 pos;
			wheelColliders[i].GetWorldPose(out pos, out quat);
			tyreMeshes[i].position = pos;
			tyreMeshes[i].rotation = quat;
		}
	}
}
