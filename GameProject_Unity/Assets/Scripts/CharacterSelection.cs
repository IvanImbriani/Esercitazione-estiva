using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class CharacterSelection : MonoBehaviour
{
    public Character[] characterModels;
    public Transform[] CharacterSlots = new Transform [5]; //slot della squadra

   

    public Transform characterPoint;

    [SerializeField] private List<GameObject> characters;
    [SerializeField] public List<GameObject> playerTeam;
    [SerializeField] public List<GameObject> enemyTeam;
    


    public int currentCharacter;
    public int currentSlot = 0;

    public GameObject PlayButton;
    public GameObject Icon;

    public Character character;
    public TMP_Text nameChar;
    public Image elementIcon;

    //[System.Serializable]
    //public struct CharacterUI
    //{

    //    public Sprite icon;
    //    public GameObject prefab;

      
    //}

    //public List<CharacterUI> charactersUI = new List<CharacterUI>();



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
        elementIcon.sprite = characterModels[currentCharacter].charElementIcon;

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
            playerTeam.Add(characterModels[currentCharacter].prefab);

        }
        if (currentSlot == 5) 

        {
            Debug.Log("prima");
            CPUSelectCharacter();
            PlayButton.SetActive(true);
        }
    }

    public void CPUSelectCharacter() 
    {
    //    Debug.Log("dentro");
       for (int i = 0; i < CharacterSlots.Length; i++) 
        {
            int randomIndex = Random.Range(0, enemyTeam.Count);

            enemyTeam.Add(characterModels[randomIndex].prefab);
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

    public void Play() 
    {
        TeamManagerSingleton.Instance.SaveTeam(playerTeam);
        SceneManager.LoadScene(1);
        
    }


}
