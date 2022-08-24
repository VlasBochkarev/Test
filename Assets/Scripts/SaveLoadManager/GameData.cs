using System;
using UnityEngine;


[Serializable]
public class GameData
{
	public int Score;
	public Vector3 Position;
	public Quaternion Rotation;

	public GameData()
	{
		Score = 0;
		Position = Vector3.up;
		Rotation = Quaternion.identity;
	}

}



