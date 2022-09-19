using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManagerSingleton : MonoBehaviour
{
    public static TeamManagerSingleton Instance;
    public List<GameObject> playerTeam;
    public List<GameObject> enemyTeam;

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
        this.playerTeam = new List<GameObject>(team);
        this.enemyTeam= new List<GameObject>(team);

    }
}
