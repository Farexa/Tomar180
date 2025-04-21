using UnityEngine;

public class Crate : MonoBehaviour, IDamageable
{
	[SerializeField] uint storedWumpaFruit;
	
	public void OnStomp(PlayerController plr)
	{
		Break(plr);
	}
	
	public void OnAttack(PlayerController plr)
	{
		Break(plr);
	}

	void Break(PlayerController player)
	{
		player.AddFruit((int)storedWumpaFruit);
	}
}