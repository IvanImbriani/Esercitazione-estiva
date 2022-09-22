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

    [SerializeField] GameObject battlePlayerIcon;
    [SerializeField] Transform battleIconPoint;

    [SerializeField] LayerMask characterLayer;



    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
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
    }

    public void SelectCharacter()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterLayer);
            if (hit != null) 
            {
            
            }
        }

    }

    private void OnMouseEnter()
    {
        battlePlayerIcon.SetActive(true);
    }
    private void OnMouseExit()
    {
        battlePlayerIcon.SetActive(false);
    }



}
