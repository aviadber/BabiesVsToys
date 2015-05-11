using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerPoint
{
    public Transform dockPoint;// this will hold an attack point Transform
    public int occupied ;
    public string name;
    public bool active = true;
}
