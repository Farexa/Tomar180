/*
 * Author : Ty Barnea Chotam
 * Last Modified: 4/15/2025
 *	Description: Handles the player's attacking state and behavior.
*/

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public bool attacking => attackTimer > 0;
	float attackTimer = 0;
	float cooldownTimer = 0;

	[SerializeField] float attackLength = 1;
	[SerializeField] float cooldownLength = 1.5f;

	[SerializeField] Renderer playerRenderer;
	[SerializeField] Material attackingMaterial;
	[SerializeField] Material cooldownMaterial;
	[SerializeField] Material neutralMaterial;

	void Update()
	{
		// Manage attack timer behavior
		if (attackTimer > 0)
		{
			attackTimer -= Time.deltaTime;
			if (attackTimer < 0)
			{
				EndAttack();
			}
		}

		// Manage cooldown timer behavior
		if (cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer < 0)
			{
				playerRenderer.material = neutralMaterial;
			}
		}

		// Start an attack if permitted
		if (Input.GetKeyDown(KeyCode.E) && cooldownTimer <= 0 && !attacking)
		{
			Attack();
		}
	}
	
	void Attack()
	{
		attackTimer = attackLength;
		playerRenderer.material = attackingMaterial;
	}

	void EndAttack()
	{
		cooldownTimer = cooldownLength;
		playerRenderer.material = cooldownMaterial;
	}
}