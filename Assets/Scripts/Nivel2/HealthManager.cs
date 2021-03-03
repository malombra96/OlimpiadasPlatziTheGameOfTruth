using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    public int expWhenDefeated;

    private SpriteRenderer charaterRendere;

    public string enemyName;
    private QuestManager _manager;
    private SFXManager _sfxManager;
    void Start()
    {
        currentHealth = maxHealth;
        charaterRendere = GetComponent<SpriteRenderer>();
        _manager = FindObjectOfType<QuestManager>();
        _sfxManager = FindObjectOfType<SFXManager>();
    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.tag.Equals("Enemy"))
            {
                _manager.Enemykilled = enemyName;
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);
                
            }
            gameObject.SetActive(false);
            if (gameObject.tag.Equals("Payer"))
            {
                _sfxManager.playerDead.Play();
            }
        }

        if (flashActive)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter > flashLength * 0.66f)
            {
                ToogleColor(false);
            }else if (flashCounter > flashLength * 0.33f)
            {
                ToogleColor(true);
            }else if (flashCounter > flashLength * 0.0f)
            {
                ToogleColor(false);
            }
            else
            {
                ToogleColor(true);
                flashActive = false;
            }
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (flashLength > 0)
        {
            flashActive = true;
            flashCounter = flashLength;
            
        }
    }

    public void updateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

    private void ToogleColor(bool visible)
    {
        charaterRendere.color = new Color(charaterRendere.color.r,
                                        charaterRendere.color.g,
                                        charaterRendere.color.b,
                                        (visible ? 1.0f: 0.0f));
    }
}
