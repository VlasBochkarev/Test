using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sphere : MonoBehaviour
{
	public static Action OnTouched;


	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Sphere is Fall");
		OnTouched?.Invoke();
	}
}
