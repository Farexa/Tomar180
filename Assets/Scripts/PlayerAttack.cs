/*
 * Author : Ty Barnea Chotam
 * Last Modified: 4/15/2025
 *	Description: Handles the player's attacking state and behavior.
*/

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] PlayerController plr;
	[SerializeField] Rigidbody rb;
	[SerializeField] Transform foot;
	
	public bool attacking => attackTimer > 0;
	float attackTimer = 0;
	float cooldownTimer = 0;

	[SerializeField] float attackLength = 1;
	[SerializeField] float cooldownLength = 1.5f;

	[SerializeField] float enemyBelowDistance;
	[SerializeField] LayerMask enemyMask;

	[SerializeField] Renderer playerRenderer;
	[SerializeField] Material attackingMaterial;
	[SerializeField] Material cooldownMaterial;
	[SerializeField] Material neutralMaterial;

	[SerializeField] GameObject bounceParticles;

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
			StartAttack();
		}

		if (rb.velocity.y < 0.02f)
		{
			if (DamageableBelow(out IDamageable foundDamagable))
			{
				foundDamagable.OnStomp(plr);
				var newParticle = Instantiate(bounceParticles);
				newParticle.transform.position = foot.position;
			}
		}	
	}
	
	bool DamageableBelow(out IDamageable foundDamageable)
	{
		float extra = 0.1f;
		Vector3 start = foot.position + (Vector3.up * extra);
		if (Physics.Raycast(start, Vector3.down, out RaycastHit hit, enemyBelowDistance + extra, enemyMask))
		{
			if (hit.transform.TryGetComponent(out IDamageable enemy))
			{
				foundDamageable = enemy;
				return true;	
			}
		}

		foundDamageable = null;
		return false;
	}
	
	void StartAttack()
	{
		attackTimer = attackLength;
		playerRenderer.material = attackingMaterial;
	}

	void EndAttack()
	{
		cooldownTimer = cooldownLength;
		playerRenderer.material = cooldownMaterial;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out IDamageable damagable))
		{
			if (attacking)
			{
				damagable.OnAttack(plr);
			}
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent(out IDamageable damagable))
		{
			if (attacking)
			{
				damagable.OnAttack(plr);
			}
		}
	}
}