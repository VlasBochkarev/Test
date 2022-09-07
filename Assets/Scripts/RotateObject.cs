using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
	//public GameObject Object;

	private Vector3 _currentEulerAngles;
	private float _rotationSpeedEuler = 1;
	private float _rotateSpeedQuaternion = 1;



	void Update()
	{
		RotatePlayerWithEulerAngles();
		RotatePlayerWithQuaternion();
	}


	private void RotatePlayerWithEulerAngles()
	{
		if (Input.GetKey(KeyCode.E))
		{
			_currentEulerAngles += new Vector3(0, 360, 0) * Time.deltaTime * _rotationSpeedEuler;
			transform.eulerAngles = _currentEulerAngles;
		}
	}

	private void RotatePlayerWithQuaternion()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			float angle = _rotateSpeedQuaternion * Time.deltaTime * 360;
			transform.rotation *= Quaternion.AngleAxis(angle, Vector3.down);
		}

	}
}
