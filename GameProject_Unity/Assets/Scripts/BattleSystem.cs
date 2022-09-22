using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
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
                Debug.Log(unit.health);


            }
        }

    }

   



}
