using System;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // inventory managing
    // item types
    public ItemType itemType;

    // check if theyve been collected

    [SerializeField] GameObject player;
    [SerializeField] AudioClip collectSound;
    public float volume = 1f;

    private Inventory inventory;

    void Start()
    {
        inventory = player.GetComponentInChildren<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(itemType == ItemType.diamond) inventory.diamondCollected = true;
        if(itemType == ItemType.crown) inventory.crownCollected = true;
        if(itemType == ItemType.key) inventory.keyCollected = true;

        // AudioSource.PlayClipAtPoint(collectSound, transform.position, volume); 

        Destroy(transform.gameObject);
    }
}

public enum ItemType
    {
        diamond, 
        crown,
        key
    };