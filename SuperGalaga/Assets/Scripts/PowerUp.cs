using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public GameObject prefab;
    public abstract void Apply(GameObject player);
}
