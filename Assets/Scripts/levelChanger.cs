using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class levelChanger : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI diamondCountText;

    void Start()
    {
        if(canvas.enabled) {
            canvas.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Inventory.keyCollected)
        {
            Inventory.keyCollected = false;
            LoadLevel2();
        }
        else if (Inventory.crownCollected)
        {
            diamondCountText.text = "You found " + Inventory.diamondsCollected + " out of 5 diamonds";
            canvas.enabled = true;
            Time.timeScale = 0f;
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
        SceneManager.LoadScene("IntroLevel"); 
    } 

    public void LoadLevel1() 
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("level_1"); 
    } 

    public void LoadLevel2() 
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("level_2"); 
    } 
}