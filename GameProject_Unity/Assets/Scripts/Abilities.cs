using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] Unit unit;

    private void Start()
    {
        unit = FindObjectOfType<Unit>();
    }
    public void Heal() 
    {
        unit.health += 20;
    }
}
