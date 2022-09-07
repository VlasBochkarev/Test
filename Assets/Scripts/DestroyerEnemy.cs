using UnityEngine;
using System;

public class DestroyerEnemy : MonoBehaviour
{

	private int _currentHealth = 3;
	public static int UpdateScore;



	public void Damage(int damageAmount)
	{
		_currentHealth -= damageAmount;
		DestroyAndIncrementPointScoreEnemy();
	}

	public void DestroyAndIncrementPointScoreEnemy()
	{
		if (_currentHealth <= 0)
		{
			EventManager.OnEnemyDied();
			Destroy(gameObject);
			
			UpdateScore = UIManager.Score;
		}
	}
}
