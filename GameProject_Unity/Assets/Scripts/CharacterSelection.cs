using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public Character[] characterModels;

    public Transform characterPoint;

    private List<GameObject> characters;

    public int currentCharacter;

    void Start()
    {
        characters = new List<GameObject>();

        foreach (var chracter in characterModels) 
        {
            GameObject go = Instantiate(chracter.characterModel, characterPoint.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(characterPoint);
            characters.Add(go);
        }
        ShowCharacterFromList();
    }

    public void ShowCharacterFromList()
    {
        characters[currentCharacter].SetActive(true);
    }

    public void OnClickNext()
    {
        characters[currentCharacter].SetActive(false);

        if (currentCharacter < characters.Count - 1)
        {
            currentCharacter++;
        }
        else
        {
            currentCharacter = 0;
        }
        ShowCharacterFromList();
    }
    public void OnClickBack()
    {
        characters[currentCharacter].SetActive(false);

        if (currentCharacter == 0)
        {
            currentCharacter = characters.Count - 1;
        }
        else
        {
            currentCharacter--;
        }
        ShowCharacterFromList();
    }

}
