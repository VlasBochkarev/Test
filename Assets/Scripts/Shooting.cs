using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	private const string ROCK = "Rock";
	[SerializeField]
	private float _shootRange = 50f;
	[SerializeField] [Range(100,1000)]
	private float _hitForce;
	private LineRenderer LaserLine;

	private void Start()
	{
		LaserLine = GetComponent<LineRenderer>();
	}

	void Update()
    {
		Shoot();
		
	}

	private void Shoot()
	{
		if (Input.GetKeyDown(KeyCode.RightShift))
		{
			StartCoroutine(ShotEffect());
			RaycastHit Hit;
			LaserLine.SetPosition(0, transform.position);
			if (Physics.Raycast(transform.position, transform.forward, out Hit, _shootRange))
			{
				LaserLine.SetPosition(1, Hit.point);

				if (Hit.transform.gameObject.CompareTag(ROCK))
				{
					if (Hit.rigidbody != null)
					{
						Hit.rigidbody.AddForce(-Hit.normal * _hitForce);

					}
					Debug.Log("HIT");
				}
				else
				{
					LaserLine.SetPosition(1, transform.position + (transform.forward * _shootRange));
				}
			}
		}
		Debug.DrawRay(transform.position, transform.forward * _shootRange, Color.green);
	}

	private IEnumerator ShotEffect()
	{

		LaserLine.enabled = true;
		yield return new WaitForSeconds(0.07f);
		LaserLine.enabled = false;
	}


}
