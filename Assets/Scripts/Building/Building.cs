using UnityEngine;
using System.Collections;

public class Building {
    public float hp;
    public string name;
    public virtual void Update()
    {
        Debug.Log("You shouldnt get here!");
    }
}
