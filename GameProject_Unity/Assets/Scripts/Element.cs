using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewElement", menuName = "Elements")]
public class Element : ScriptableObject
{
    public string elementName;
    public List<Element> weakness;
  

}
