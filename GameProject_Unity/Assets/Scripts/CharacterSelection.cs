using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CharacterSelection : MonoBehaviour
{
    public Character[] characterModels;
    public Transform[] CharacterSlots = new Transform [5]; //slot della squadra

   

    public Transform characterPoint;

    private List<GameObject> characters;

    public int currentCharacter;
    public int currentSlot = 0;

    public GameObject PlayButton;
    public GameObject Icon;

    public Character character;
    public TMP_Text nameChar;


 

    void Start()
    {
        PlayButton.SetActive(false);    
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

    private void Update()
    {
        CancelSelection();
    }

    public void ShowCharacterFromList()
    {
        characters[currentCharacter].SetActive(true);
        nameChar.text = characterModels[currentCharacter].characterName;

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

    public void SelectCharacter() 
    {
        if (CharacterSlots != null)
        {         
          Icon =  Instantiate(characters[currentCharacter], CharacterSlots[currentSlot].position, Quaternion.identity);
            currentSlot++;
        }
        if (currentSlot == 5) 
        {
            PlayButton.SetActive(true);
        }

    }

    public void CancelSelection()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (currentSlot < 1) 
            {
                currentSlot = 1;
            }
            currentSlot--;
            Destroy(Icon);
           
           
           

        }
    }
}
