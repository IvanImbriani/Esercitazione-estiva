using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    

    [SerializeField] LayerMask characterLayer;
    [SerializeField] LayerMask enemyLayer;

    [SerializeField] Unit characterSelected;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();

       
    }

    private void Update()
    {
        if (state == BattleState.PLAYERTURN)
        {
            SelectCharacter();
        }

        if (state == BattleState.PLAYERMOVE)
        {

            PlayerMove();
        }
    }

    public void SetUpBattle()
    {
        teamManagerSingleton = FindObjectOfType<TeamManagerSingleton>();

        for (int i = 0; i < playerPoints.Length; i++)
        {
            GameObject playerTeam = Instantiate(teamManagerSingleton.playerTeam[i], playerPoints[i]);


        }
        for (int i = 0; i < enemyPoints.Length; i++)
        {
            GameObject enemyTeam = Instantiate(teamManagerSingleton.enemyTeam[i], enemyPoints[i]);
            enemyTeam.layer = LayerMask.NameToLayer("enemyLayer");

        }
        state = BattleState.PLAYERTURN;
    }

    public void SelectCharacter()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterLayer);
            if (hit.collider != null) 
            {
                var unit = hit.collider.GetComponent<Unit>();
                battlePlayerIcon.sprite = unit.character.BattleIcon;
                float normalizedHealth = (float)unit.health / unit.maxHealth;
                healthBarBackground.SetActive(true);
                healthBarPlayer.fillAmount = normalizedHealth;
                characterSelected = unit;
                state = BattleState.PLAYERMOVE;

                
               
            }
           
        }

    }

    public void PlayerMove() 
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            RaycastHit2D enemyHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);

            if (characterSelected != null && enemyHit.collider != null)
            {
                enemyHit.collider.GetComponent<Unit>().TakeDamage(characterSelected.damage);
                state = BattleState.PLAYERTURN;
            }
        }
         
    }



}
