using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
	public GameObject Player;

	private float _speed = 50;

	private void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			Player.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			Player.transform.Translate(Vector3.back * _speed * Time.deltaTime);
		}
	}
}
