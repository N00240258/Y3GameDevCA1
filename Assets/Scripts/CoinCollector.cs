using System;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public float rotationSpeed;
    public float bouncingSpeed = .03f;
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



    void Update()
    {
        transform.Rotate(0,0,rotationSpeed);
        float coinPosition = Mathf.Sin(bouncingSpeed * Time.frameCount) * Time.deltaTime;
        // Debug.Log(coinPosition);
        transform.position = new Vector3(transform.position.x, transform.position.y + coinPosition, transform.position.z);
    }
}
