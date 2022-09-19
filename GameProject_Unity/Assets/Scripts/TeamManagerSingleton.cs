using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManagerSingleton : MonoBehaviour
{
    public static TeamManagerSingleton Instance;
    public List<GameObject> team;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SaveTeam(List<GameObject> team)
    {
        this.team = new List<GameObject>(team);
       // this.teamEnemy = new List<GameObject>();

    }
}
