using UnityEngine;

/*
 * Author: Ty Barnea Chotam
 * Last Modified: 4/21/2025
 * Description: Acts as a teleport pad to teleport player between levels.
*/

public class LevelTP : MonoBehaviour
{
	[SerializeField] int sceneIndex;

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerController>())
		{
			LevelManager.LoadLevel(sceneIndex);
		}
	}
}