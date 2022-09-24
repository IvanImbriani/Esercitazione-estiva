using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;

    public float health;
    public float maxHealth;

    public GameObject healthBar;

    public Character character;
    public Element element;


    public void TakeDamage(int dmg, Element elementDmg) 
    {
        if (elementDmg == element.weakness) // se il danno è uguale ala debolezza x 1.5
        {
            health -= dmg * 1.5f;
        }
        else if (elementDmg.weakness == element) //la debolezza dell'attacco è il mio elemento mi fa la metà x0.5
        {
            health -= dmg * 0.5f;
        }
        else 
        {
            health -= dmg;
        }

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
