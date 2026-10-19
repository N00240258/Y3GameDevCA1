using UnityEngine;

public class SpinBounce : MonoBehaviour
{
    public float rotationSpeed;
    public float bouncingSpeed = .03f;

    void Update()
    {
        transform.Rotate(0,0,rotationSpeed);
        float itemPosition = Mathf.Sin(bouncingSpeed * Time.frameCount) * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + itemPosition, transform.position.z);
    }
}
