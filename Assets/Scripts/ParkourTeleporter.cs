using UnityEngine;
using UnityEngine.UIElements;

public class ParkourTeleporter : MonoBehaviour
{
    public bool deathBox = false;
    public bool respawnPoint = false;
    
    [SerializeField] public GameObject respawnPositions;
    [SerializeField] GameObject player;
    private CharacterController playerCharacterController;


    void Start()
    {
        if (player) playerCharacterController = player.GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (deathBox)
        {   
            respawnAtLastCheckpoint();
        } 
        else if(!respawnPoint)
        {
            updateLatestCheckpoint();
            respawnPoint = true;
        }
    }

    void respawnAtLastCheckpoint()
    {
        foreach(ParkourTeleporter respawn in respawnPositions.GetComponentsInChildren<ParkourTeleporter>())
        {
            if (respawn.respawnPoint)
            {
                // character controller has to be disabled to manually change position in code for some very strange reason
                playerCharacterController.enabled = false;

                player.transform.position = respawn.transform.position;

                playerCharacterController.enabled = true;
            }
        }
    }

    void updateLatestCheckpoint()
    {
        foreach(ParkourTeleporter respawn in respawnPositions.GetComponentsInChildren<ParkourTeleporter>())
        {
            if(respawn.respawnPoint) respawn.respawnPoint = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 2.5f);
    }
}
