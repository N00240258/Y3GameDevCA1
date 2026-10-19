using System;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    
    [SerializeField] GameObject player;
    [SerializeField] AudioClip collectSound;
    public float volume = 1f;
    CoinCounter coinCounter;

    void Start()
    {
        coinCounter = player.GetComponent<CoinCounter>();
        if (coinCounter == null) 
        { 
            Debug.LogWarning("No coin counter/inventory found in the scene.");
            return;
        }
        coinCounter.UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        coinCounter.coinCount++;
        coinCounter.UpdateText();
        AudioSource.PlayClipAtPoint(collectSound, transform.position, volume); 

        Debug.Log("Coin Collected! " + coinCounter.coinCount);
        Destroy(transform.gameObject);
    }




}
