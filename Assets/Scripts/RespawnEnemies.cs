using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour
{
	public Transform Player;
	public GameObject[] AllEnemies;
	private bool _isTrigger = false;

	private void Start()
	{
		AllEnemies = Resources.LoadAll<GameObject>("Enemies");


	}

	private void Update()
	{
		RangeToRespawn();
	}

	private void RangeToRespawn()
	{
		if (Player)
		{
			Vector3 BlackCube = transform.TransformDirection(Vector3.forward);
			Vector3 PlayerPos = Player.position - transform.position;
			Debug.Log("DOT RESULT : " + Vector3.Dot(BlackCube, PlayerPos));

			if (Vector3.Dot(BlackCube, PlayerPos) < 0)
			{
				Debug.Log("The Player transform is back Black Cube!");
				RespawnEnemy();
			}
		}

	}

	private void RespawnEnemy()
	{
		if (!_isTrigger)
		{
			for (int i = 0; i < AllEnemies.Length; i++)
			{
				float x = Random.Range(-10f, 10f);
				float y = 0.5f;
				float z = Random.Range(80f, 90f);
				Instantiate(AllEnemies[i], new Vector3(x, y, z), Quaternion.Euler(0f, 180f, 0f));

			}
			_isTrigger = true;
		}
	}


}
