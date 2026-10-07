using System;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float cameraHeight = 5.0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + cameraHeight, player.transform.position.z);
    }
}
