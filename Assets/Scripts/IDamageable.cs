/*
 * Author: Ty Barnea Chotam
 * Last Modified: 4/21/2025
 * Description: Handles objects that are damageable
*/
public interface IDamageable
{
	public void OnStomp(PlayerController player);

	public void OnAttack(PlayerController player);
}