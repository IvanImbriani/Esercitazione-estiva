using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, PLAYERMOVE,  ENEMYTURN, ENEMYMOVE, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] Transform[] playerPoints;
    [SerializeField] Transform[] enemyPoints;
    [SerializeField] TeamManagerSingleton teamManagerSingleton;

    [SerializeField] BattleState state;
    [SerializeField] Character character;

    [SerializeField] Image battlePlayerIcon;
    [SerializeField] GameObject healthBarBackground;
    [SerializeField] Image healthBarPlayer;


    [SerializeField] Image enemyBattleIcon;
    [SerializeField] GameObject enemyHealthBarBackground;
    [SerializeField] Image healthBarEnemy;


    [SerializeField] LayerMask characterLayer;
    [SerializeField] LayerMask enemyLayer;

    [SerializeField] Unit characterSelected;
    [SerializeField] Unit enemySelected;

    [SerializeField] GameObject buttonPanel;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI selectionText;
    [SerializeField] GameObject selectionPanel;

    [SerializeField] List<GameObject> enemyList;
    [SerializeField] List<GameObject> playerList;

    [SerializeField] GameObject abilitiesPanel;

    

   



    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
        buttonPanel.SetActive(false);
        abilitiesPanel.SetActive(false);
       



    }

    private void Update()
    {
        if (state == BattleState.PLAYERTURN)
        {
            PlayerTurn();
            selectionText.text = "SELEZIONA UN MEMBRO DEL TUO TEAM";
            
        }
       

        
    }

    public void SetUpBattle()
    {
        teamManagerSingleton = FindObjectOfType<TeamManagerSingleton>();

        for (int i = 0; i < playerPoints.Length; i++)
        {
            GameObject playerTeam = Instantiate(teamManagerSingleton.playerTeam[i], playerPoints[i]);
            playerList.Add(playerTeam);

        }
        for (int i = 0; i < enemyPoints.Length; i++)
        {
            GameObject enemyTeam = Instantiate(teamManagerSingleton.enemyTeam[i], enemyPoints[i]);
            enemyTeam.layer = LayerMask.NameToLayer("enemyLayer");
            enemyList.Add(enemyTeam);

        }
        state = BattleState.PLAYERTURN;
        
    }

    public void PlayerTurn()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterLayer);
            if (hit.collider != null) 
            {
                selectionPanel.SetActive(false);
                var unit = hit.collider.GetComponent<Unit>();
                battlePlayerIcon.sprite = unit.character.BattleIcon;
                float normalizedHealth = (float)unit.health / unit.maxHealth;
                healthBarBackground.SetActive(true);
                healthBarPlayer.fillAmount = normalizedHealth;
                characterSelected = unit;
                buttonPanel.SetActive(true);
                dialogueText.text = "SCEGLI COSA FARE";
               
            }
           
        }

    }

    public void ButtonAtk() 
    {
        StartCoroutine(PlayerMove());
        //buttonPanel.SetActive(false);
    }

    IEnumerator PlayerMove() 
    {
        state = BattleState.PLAYERMOVE;
        bool isEsecuted = false;
        while (!isEsecuted) 
        {
            dialogueText.text = "SELEZIONA IL BERSAGLIO";

            if (Input.GetButtonDown("Fire1"))
            {
               
                RaycastHit2D enemyHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
     
                if (characterSelected != null && enemyHit.collider != null)
                {
                    enemyHit.collider.GetComponent<Unit>().TakeDamage(characterSelected.damage, characterSelected.element);
                    state = BattleState.PLAYERTURN;
                    isEsecuted = true;
                }
                var unit = enemyHit.collider.GetComponent<Unit>();
                enemyBattleIcon.sprite = unit.character.BattleIcon;
                float normalizedHealth = (float)unit.health / unit.maxHealth;
                enemyHealthBarBackground.SetActive(true);
                healthBarEnemy.fillAmount = normalizedHealth;
            }
           
            yield return null;
  
        }

        state = BattleState.ENEMYTURN;
        dialogueText.text = "TURNO NEMICO";
        Debug.Log("turno nemico");
        EnemyTurn();
    }

    public void EnemyTurn()
    {
        int enemyRandomIndex = Random.Range(0, enemyList.Count);
        var enemy = enemyList[enemyRandomIndex].GetComponent<Unit>();
        Debug.Log("index del nemico:  " + enemyRandomIndex);
        Debug.Log("Nome del nemico:  " + teamManagerSingleton.enemyTeam[enemyRandomIndex].name);
        enemySelected = enemy;
        

        int playerRandomIndex = Random.Range(0, teamManagerSingleton.playerTeam.Count);
        var player = playerList[playerRandomIndex].GetComponent<Unit>(); 
        Debug.Log("index del player:  " + playerList[enemyRandomIndex]);
        Debug.Log("Nome del player: " + playerList[enemyRandomIndex].name);


        Debug.Log("i danni prima del take damage" + enemySelected.damage);
        player.TakeDamage(enemySelected.damage, enemySelected.element);
        
        Debug.Log("la vita del player è " + player.health);
        Debug.Log("I danni del nemico sono " + enemy.damage);

        

        state = BattleState.PLAYERTURN;
        selectionPanel.SetActive(true);
    }

    public void openAbilitiesPanel() 
    {
        abilitiesPanel.SetActive(true);
       
    }
    public void HealCharacter() 
    {
        characterSelected.Heal();
        abilitiesPanel.SetActive(false);
        state = BattleState.ENEMYTURN;
        EnemyTurn();

    }

    public void StrongAttack() 
    {
        characterSelected.damage += 50;
        Debug.Log(characterSelected.damage);
    }
   
}
