using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ItemType itemType;

    [SerializeField] AudioClip collectSound;
    [SerializeField] ParticleSystem particleSystem;
    public float volume = 1f;
    public bool preloadAudioData;

    private Light lightComponent;
    private MeshRenderer meshRendererComponent;


    void Awake()
    {
        collectSound.LoadAudioData();
        if (gameObject.GetComponentInChildren<MeshRenderer>()) meshRendererComponent = gameObject.GetComponentInChildren<MeshRenderer>();
        if (gameObject.GetComponentInChildren<Light>()) lightComponent = gameObject.GetComponentInChildren<Light>();
        if(itemType == ItemType.key) Inventory.keyCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(itemType == ItemType.diamond) Inventory.diamondsCollected++;
        if(itemType == ItemType.crown) Inventory.crownCollected = true;
        if(itemType == ItemType.key) Inventory.keyCollected = true;

        if(collectSound) AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
        if(particleSystem) particleSystem.Play();
        
        // disables visible components so particles can still be played
        if (meshRendererComponent) meshRendererComponent.enabled = false;
        if (lightComponent) lightComponent.enabled = false;

        // disables colliders to stop recollecting an object before destruction
        GetComponentInChildren<Collider>().enabled = false;
        Destroy(transform.gameObject, particleSystem.duration + 1);
    }
}

public enum ItemType
    {
        diamond, 
        crown,
        key
    };