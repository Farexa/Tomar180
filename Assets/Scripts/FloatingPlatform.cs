using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;


public class FloatingPlatform : MonoBehaviour
{
    public float deactivateTime = 3f; // Time before the platform turns off (modifiable in Inspector)
    private Collider platformCollider;
    private MeshRenderer platformRenderer;

    void Start()
    {
        // Get references to the platform's components
        platformCollider = GetComponent<Collider>();
        platformRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()) // Check if the player landed on the platform
        {
            StartCoroutine(HandlePlatform());
        }
    }

    private IEnumerator HandlePlatform()
    {
        // Wait for the specified time before turning off
        yield return new WaitForSeconds(deactivateTime);

        // Turn off the platform
        platformCollider.enabled = false;
        platformRenderer.enabled = false;

        // Wait 5 seconds before turning the platform back on
        yield return new WaitForSeconds(5);

        // Turn the platform back on
        platformCollider.enabled = true;
        platformRenderer.enabled = true;
    }
}






