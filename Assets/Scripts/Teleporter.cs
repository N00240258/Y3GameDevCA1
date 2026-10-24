using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] GameObject TeleportDestination;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip teleportSound;
    public float volume = 1f;

    private Vector3 teleportCoords;
    private CharacterController characterController;

    static private bool isTeleporting = false;

    void Start()
    {
        teleportCoords = TeleportDestination.transform.position;
        characterController = player.GetComponentInChildren<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting)
        {
            isTeleporting = true;

            AudioSource.PlayClipAtPoint(teleportSound, teleportCoords, volume); 

            characterController.enabled = false;
            player.transform.position = teleportCoords;
            characterController.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTeleporting = false;
    }
}