using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponDamage : MonoBehaviour
{
    public int damage;
    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber;
    private CharacterStats _stats;

    private void Start()
    {
        _stats = transform.parent.GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            int totalDamage = damage;
            if (_stats != null)
            {
                totalDamage = _stats.StrengLavels[_stats.currentLevel];
            }
            other.GetComponent<HealthManager>().DamageCharacter(totalDamage);
            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);
            var clone = (GameObject) Instantiate(damageNumber,
                                                  hitPoint.transform.position,
                                            Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }
    }
}
