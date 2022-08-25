using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorArithmetic : MonoBehaviour
{

	public Transform PointBlack;
	

	private bool _isMoving;
	[SerializeField]
	private float _speedRoll = 3;



	private void Update()
	{
	
		RollController();
	}



	

	private void RollController()
	{
		if (_isMoving) return;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			RollObject(Vector3.left);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			RollObject(Vector3.right);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			RollObject(Vector3.forward);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			RollObject(Vector3.back);
		}
	}

	private void RollObject(Vector3 dir)
	{
		var anchor = transform.position + (Vector3.down + dir) * 0.5f;
		var axis = Vector3.Cross(Vector3.up, dir);
		StartCoroutine(Roll(anchor, axis));
	}

	IEnumerator Roll(Vector3 anchor, Vector3 axis)
	{
		_isMoving = true;
		for (int i = 0; i < (90 / _speedRoll); i++)
		{
			transform.RotateAround(anchor, axis, _speedRoll);
			yield return new WaitForSeconds(0.01f);
		}

		_isMoving = false;
	}




}
