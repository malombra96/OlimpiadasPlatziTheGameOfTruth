using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textLevel;
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;
    public Text textExp;
    public int[] hpLevels, StrengLavels, DefeseLevels;
    private HealthManager _healthManager;
    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        currentLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
            textLevel.text = "Level: " + currentLevel.ToString();
            //sube la vida maxima debido al nuevo nivel 
            _healthManager.updateMaxHealth(hpLevels[currentLevel]);
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
        textExp.text = "Exp: "+currentExp.ToString();
    }
}
