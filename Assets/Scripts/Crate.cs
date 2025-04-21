using UnityEngine;

public class Crate : MonoBehaviour, IDamageable
{
	[SerializeField] uint storedWumpaFruit;
	
	public void OnStomp(PlayerController plr)
	{
		Break(plr);
		plr.Bounce();
	}
	
	public void OnAttack(PlayerController plr)
	{
		Break(plr);
	}

	void Break(PlayerController player)
	{
		player.AddFruit((int)storedWumpaFruit);
		Destroy(gameObject);
	}
}