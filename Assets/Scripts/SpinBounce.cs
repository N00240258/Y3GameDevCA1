using System;
using UnityEngine;

public class SpinBounce : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    public float bouncingSpeed = .005f;
    public float bounceRange = 0.5f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        Debug.Log(transform.rotation);
    }

    void Update()
    {
        // transform.rotation = new Vector3(transform.rotation.x, transform.rotation.y+rotationSpeed, transform.rotation.z);
        transform.Rotate(0,rotationSpeed,0, Space.World);
        float bounce = Mathf.Sin(Time.frameCount*bouncingSpeed)*bounceRange;
        transform.position = new Vector3(originalPosition.x, originalPosition.y + bounce, originalPosition.z);
    }
}
