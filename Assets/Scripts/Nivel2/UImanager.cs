using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UImanager : MonoBehaviour
{
    public Slider playerHealtBar;
    public Text playerHeltText;
    
    
    public HealthManager playerHealthManager;

    void Update()
    {
        // pos si subimos de nivel 
        playerHealtBar.maxValue = playerHealthManager.maxHealth;
        playerHealtBar.value = playerHealthManager.currentHealth;
        
        StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(playerHealthManager.currentHealth);
        sb.Append("/");
        sb.Append(playerHealthManager.maxHealth);

        playerHeltText.text = sb.ToString();
    }
}
