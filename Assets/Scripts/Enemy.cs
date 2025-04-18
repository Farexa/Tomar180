using System;
using UnityEditor;
using UnityEngine;

/*
 * Author: Ty Barnea Chotam
 * Last Modified: 4/17/2025
 * Description: Controls the movement and patrolling of enemies.
*/


public enum PatrolType
{
	Horizontal, Longitudinal
}

public class Enemy : MonoBehaviour, IDamageable
{
	[SerializeField] PatrolType patrolType;
	
	[SerializeField] float patrolDistance;
	[SerializeField] float wallDetectDistance;
	[SerializeField] LayerMask environmentMask;
	
	[SerializeField] float speed;
	[SerializeField] bool canBeStomped = true;
	[SerializeField] bool canBeAttacked = true;
	
	public Vector3 startPoint;
	int dir = 1;
	
	void Update()
	{
		CheckForWall();
		CheckDirection();

		if (patrolType == PatrolType.Horizontal)
		{
			transform.Translate(speed * dir * Time.deltaTime, 0, 0);
		}
		else
		{
			transform.Translate(0, 0, speed * dir * Time.deltaTime);
		}
	}
	
	public void OnStomp(PlayerController1 player)
	{
		if (canBeStomped)
		{
			Die();
		}
		else
		{
			player.LoseLife();
		}
	}
	
	public void OnAttack(PlayerController1 player)
	{
		if (canBeAttacked)
		{
			Die();
		}
		else
		{
			player.LoseLife();
		}
	}
	
	void Die()
	{
		Destroy(gameObject);
	}
	
	void CheckForWall()
	{
		Vector3 direction = patrolType == PatrolType.Horizontal ? Vector3.right : Vector3.forward;
		
		if (Physics.Raycast(transform.position, direction * dir, wallDetectDistance, environmentMask))
		{
			dir *= -1;
		}
	}
	
	void CheckDirection()
	{
		if (patrolType == PatrolType.Horizontal)
		{
			if (transform.position.x - startPoint.x < startPoint.x - (patrolDistance / 2))
			{
				dir = 1;
			}
			
			if (transform.position.x - startPoint.x > startPoint.x + (patrolDistance / 2))
			{
				dir = -1;
			}
		}
		else // patrolType == PatrolType.Longitudinal
		{
			if (transform.position.z - startPoint.z < startPoint.z - (patrolDistance / 2))
			{
				dir = 1;
			}

			if (transform.position.z - startPoint.z > startPoint.z + (patrolDistance / 2))
			{
				dir = -1;
			}
		}
	}
}

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		if (GUILayout.Button("Set Start Position"))
		{
			var enemy = (Enemy)target;
			enemy.startPoint = enemy.transform.position;
		}
	}
}