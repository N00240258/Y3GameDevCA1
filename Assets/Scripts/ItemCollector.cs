using System;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ItemType itemType;

    [SerializeField] AudioClip collectSound;
    public float volume = 1f;
    public bool preloadAudioData;

    void Awake()
    {
        collectSound.LoadAudioData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(itemType == ItemType.diamond) Inventory.diamondsCollected++;
        if(itemType == ItemType.crown) Inventory.crownCollected = true;
        if(itemType == ItemType.key) Inventory.keyCollected = true;

        AudioSource.PlayClipAtPoint(collectSound, transform.position, volume); 

        Destroy(transform.gameObject);
    }
}

public enum ItemType
    {
        diamond, 
        crown,
        key
    };