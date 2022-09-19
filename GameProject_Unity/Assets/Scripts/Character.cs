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

    public float characterHealth;
    public float charcterDamage;

    public CharatcerAttribute characterAttribute;

   
   
}

public enum CharatcerAttribute 
{
    Water,
    Fire, 
    Wind, 
    Hearth,
    Lightning,
    Dark
}
