using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerUpBattle : MonoBehaviour
{
    [SerializeField] Transform[] playerPoints;
    [SerializeField] TeamManagerSingleton teamManagerSingleton;



    // Start is called before the first frame update
    void Start()
    {
        teamManagerSingleton = FindObjectOfType<TeamManagerSingleton>();
        for (int i = 0; i < playerPoints.Length; i++)
        {
            Instantiate(teamManagerSingleton.team[i], playerPoints[i].position, Quaternion.identity );
        }
    }

}
