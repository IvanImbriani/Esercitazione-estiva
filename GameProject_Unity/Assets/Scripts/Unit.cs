using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;

    public int health;
    public int maxHealth;

    public GameObject healthBar;

    public Character character;
    public Element element;


    public void TakeDamage(int dmg) 
    {
        health -= dmg;

        if (health <= 0) 
        {
            Die();
        }
    }
 

    private void Start()
    {
      
        ShowCharacter();
    }
    public void ShowCharacter()
    {
        unitName = character.characterName;
        damage = character.charcterDamage;
        health = character.characterHealth;
        maxHealth = character.characterMaxHealth;
        element = character.element;
    }

    public void Die() 
    
    {
        Destroy(gameObject);    
    }
}
