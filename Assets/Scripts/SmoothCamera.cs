using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField] Transform camTarget;
    [SerializeField]
    [Range(0f, 100f)] float lerpSpeed; 

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, lerpSpeed * Time.deltaTime);
        //recompile pretty pleaase
    }
}