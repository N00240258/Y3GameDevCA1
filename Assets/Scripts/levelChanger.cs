using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class levelChanger : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI diamondCountText;

    [Header("Celebration")] 
    [Tooltip("Confetti prefab spawned in front of the camera when the level is cleared.")] 
    [SerializeField] GameObject confettiEffect; 

    [Tooltip("How far in front of the camera the confetti appears. Keep it further than the Level Complete canvas Plane Distance, and closer than the player.")] 
    [SerializeField] float confettiDistance = 1.2f; 

    private ThirdPersonController playerController;

    void Start()
    {
        if(canvas && canvas.enabled) {
            canvas.enabled = false;
        }
        if (player && player.GetComponentInChildren<ThirdPersonController>()) playerController = player.GetComponentInChildren<ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Inventory.crownCollected)
        {
            if(Inventory.diamondsCollected >= 6)
            {
                diamondCountText.text = "You found all the diamonds!!";
            }
            else
            {
                diamondCountText.text = "You found " + Inventory.diamondsCollected + " out of 6 diamonds";
            }
            SpawnConfetti();
            playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            canvas.enabled = true;
            Time.timeScale = 0f;
        }
        else if (Inventory.keyCollected)
        {
            LoadLevel2();
        }
        else
        {
            canvas.enabled=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.enabled=false;
    }

    public void LoadIntroLevel() 
    { 
        Time.timeScale = 1f;
        resetValues();
        SceneManager.LoadScene("IntroScene"); 
    } 

    public void LoadLevel1() 
    { 
        Time.timeScale = 1f;
        if(player) resetValues();
        SceneManager.LoadScene("level_1"); 
    } 

    public void LoadLevel2() 
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("level_2"); 
    } 

    public void QuitGame() 
    { 
        Application.Quit(); 
        // Application.Quit does nothing in the editor, so stop Play mode instead 
        #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif 
    } 

    private void resetValues()
    {
        Inventory.keyCollected = false;
        Inventory.crownCollected = false;
        Inventory.diamondsCollected = 0;

        playerController.enabled = true;

        return;
    }

    void SpawnConfetti() 
    { 

        
        if (confettiEffect == null)
        {
            Debug.Log("no confetti"); 
            return; 
        } 

        // use the same camera the Level Complete canvas is drawn by, so the confetti lines up with it 
        Camera cam = player.GetComponentInChildren<Camera>();
        if (canvas != null && canvas.worldCamera != null)
        {
            cam = canvas.worldCamera; 
        }  
        if (cam == null){
            Debug.Log("no camera"); 
            return; 
        } 
    
        // half the height of the screen at that distance, so we can find the bottom edge 
        float halfHeight = confettiDistance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad); 
        Vector3 position = cam.transform.position
                            + cam.transform.forward * confettiDistance 
                            - cam.transform.up * halfHeight; 
    
        // a particle system fires along its local Z axis, so tip it to point up the screen 
        Quaternion rotation = cam.transform.rotation * Quaternion.Euler(-90f, 0f, 0f); 
    
        Debug.Log(position);
        Instantiate(confettiEffect, position, rotation); 
    } 
}