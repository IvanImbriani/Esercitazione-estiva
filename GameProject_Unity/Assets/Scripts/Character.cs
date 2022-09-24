using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterModel", menuName = "Character")]
public class Character :ScriptableObject

{
    public string characterName;

    public GameObject characterModel;
    public SpriteRenderer artworkSprite;
    public Sprite charElementIcon;
    public GameObject prefab;

    public int characterHealth;
    public int characterMaxHealth;
    public int charcterDamage;

    public Element element;
   


    //durante il combattimento
    public Sprite BattleIcon;
   
}

