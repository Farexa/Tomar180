using UnityEngine;

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