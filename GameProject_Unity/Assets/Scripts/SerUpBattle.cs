using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerUpBattle : MonoBehaviour
{
    [SerializeField] Transform[] playerPoints;
    [SerializeField] Transform[] enemyPoints;
    [SerializeField] TeamManagerSingleton teamManagerSingleton;



    // Start is called before the first frame update
    void Start()
    {
        teamManagerSingleton = FindObjectOfType<TeamManagerSingleton>();
        for (int i = 0; i < playerPoints.Length; i++)
        {
            Instantiate(teamManagerSingleton.playerTeam[i], playerPoints[i].position, playerPoints[i].rotation);
            
        }
        for (int i = 0; i < enemyPoints.Length; i++)
        {
            Instantiate(teamManagerSingleton.enemyTeam[i], enemyPoints[i].position, enemyPoints[i].rotation);
        }
    }

}
