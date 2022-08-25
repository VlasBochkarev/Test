using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{

	public GameObject[] AllEnemies;


	private void Start()
	{
		AllEnemies = Resources.LoadAll<GameObject>("Enemies");
	

	}


}
