using UnityEngine;

/*
 * Author: Ty Barnea Chotam
 * Last Modified: 4/21/2025
 * Description: Allows the camera to follow Crash along a track smoothly.
*/

public class SmoothCamera : MonoBehaviour
{
	Transform camTarget;
	Transform lookAt;
	[SerializeField][Range(0f, 100f)] float moveLerpSpeed;
	[SerializeField][Range(0f, 100f)] float rotateLerpSpeed;

	void Start()
	{
		Transform plr = GameObject.FindWithTag("Player").transform;
		camTarget = plr.GetChild(0);
		lookAt = plr.GetChild(1);
	}

	// Use both updates to prevent jittering.
	void Update() { UpdateCam(); }
	void FixedUpdate() { UpdateCam(); }
	
	void UpdateCam()
	{
		Vector3 targetPos = new Vector3(0, camTarget.position.y, camTarget.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPos, moveLerpSpeed * Time.fixedDeltaTime);
		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			Quaternion.LookRotation(lookAt.position - transform.position, Vector3.up),
			rotateLerpSpeed * Time.fixedDeltaTime);
	}
}