using UnityEngine;
using UnityEngine.SceneManagement; 

public class levelChanger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Canvas canvas;

    private Inventory inventory;

    void Start()
    {
        inventory = player.GetComponentInChildren<Inventory>();
        if(canvas.enabled) canvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inventory.keyCollected)
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
        SceneManager.LoadScene("IntroLevel"); 
    } 

    public void LoadLevel1() 
    { 
        SceneManager.LoadScene("level_1"); 
    } 

    public void LoadLevel2() 
    { 
        SceneManager.LoadScene("level_2"); 
    } 
}