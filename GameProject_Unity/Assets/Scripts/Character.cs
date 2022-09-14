using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterModel", menuName = "Character")]
public class Character :ScriptableObject

{
    public string characterName;

    public GameObject characterModel;

    public float characterHealth;

    public float charcterDamage;

    public enum charatcerAttribute { water, fire, wind, hearth, lightning }
   
}
