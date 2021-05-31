using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo")]
public class Ammo : ScriptableObject
{
    public string type;
    public bool friendly;
    public int damage;
    public float cooldown, speed;
}
