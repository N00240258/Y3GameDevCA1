using System;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] GameObject nextLevelUI;
    public int coinCount = 0;
    public int coinGoal = 10;

    bool levelComplete;

    void Start()
    {
        if (nextLevelUI != null) 
        { 
            nextLevelUI.SetActive(false); 
        }

        UpdateText();
    }
    public void UpdateText()
    {
        coinText.text = "Coins: " + coinCount.ToString() + "/" +coinGoal.ToString();

        if(coinCount >= coinGoal){
            ShowLevelComplete();
        }
    }

    void ShowLevelComplete() 
    { 
        levelComplete = true; 
 
        if (nextLevelUI != null) 
        { 
            nextLevelUI.SetActive(true); 
        } 
 
        // pause the game so the robot stops moving behind the panel 
        Time.timeScale = 0f; 
 
        // the third person controller locks the cursor, so free it to click the button 
        StarterAssets.StarterAssetsInputs input = FindFirstObjectByType<StarterAssets.StarterAssetsInputs>(); 
        if (input != null) 
        { 
            input.cursorLocked = false; 
            input.cursorInputForLook = false; 
        } 
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    } 
}

