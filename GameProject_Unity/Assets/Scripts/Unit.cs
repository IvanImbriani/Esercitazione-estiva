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
    public Animator animator;

   

    public void TakeDamage(int dmg, Element elementDmg) 
    {
        if (element.weakness.Contains(elementDmg)) // se la mia lista contiene l'elemento del danno, il danno x 1.5
        {
            health -= dmg * 1.5f;
        }
        else if (elementDmg.weakness.Contains(element)) //la debolezza dell'attacco è il mio elemento mi fa la metà x0.5
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

    public void Heal() 
    {
        health += 20;
    }
 

    private void Start()
    {
      
        ShowCharacter();
        animator = GetComponent<Animator>();
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
        gameObject.SetActive(false);
    }
}
