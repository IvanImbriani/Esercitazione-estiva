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
    public int maxHetalth;

    public GameObject healthBar;

    public Character character;

 

    private void Start()
    {
      
        ShowCharacter();
    }
    public void ShowCharacter()
    {
        unitName = character.characterName;
        damage = character.charcterDamage;
        health = character.characterHealth;
        maxHetalth = character.characterMaxHealth;

    }
}
