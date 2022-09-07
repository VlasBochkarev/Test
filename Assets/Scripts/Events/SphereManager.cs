using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SphereManager : MonoBehaviour
{
	private void OnEnable()
	{
		Sphere.OnTouched += ShowMessage;
	}

	private void OnDisable()
	{
		Sphere.OnTouched -= ShowMessage;
	}



	private void ShowMessage()
	{
		Debug.Log("Sphere is touch floor");
	}
}
