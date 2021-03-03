using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
  /*  public float timeToRevivePlayer;
    private float timeRevivalCounter;
    private bool playerReviving;

    private GameObject theplayer;*/

    public int damage;
    public GameObject damageNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
   /* void Update()
    {
        if (playerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if (timeRevivalCounter < 0)
            {
                playerReviving = false;
                theplayer.SetActive(true);
            }
        }
    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CharacterStats stats = other.gameObject.GetComponent<CharacterStats>();
            int totalDamage = damage - stats.DefeseLevels[stats.currentLevel];

            if (totalDamage <= 0)
            {
                totalDamage = 1;
            }
            
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);
            // para mostrar el canvas con el numero de puntos quitados al personaje 
            var clone = (GameObject) Instantiate(damageNumber,
                                                other.gameObject.transform.position,
                                        Quaternion.Euler(Vector3.zero));
            clone.transform.GetChild(0).GetComponent<Text>().color = new Color32(255,0,0,255);
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
            
        }
    }
}
