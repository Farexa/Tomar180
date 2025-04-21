using UnityEngine;

/*
 * Author: Ty Barnea Chotam
 * Last Modified: 4/21/2025
 * Description: Allows the camera to follow Crash along a track smoothly.
*/

public class SmoothCamera : MonoBehaviour
{
	[SerializeField] Transform camTarget;
	[SerializeField][Range(0f, 100f)] float lerpSpeed;

	// Use fixed update to prevent jittering.
	void FixedUpdate()
	{
		Vector3 targetPos = new Vector3(0, camTarget.position.y, camTarget.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
	}
}