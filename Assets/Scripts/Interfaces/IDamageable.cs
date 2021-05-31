using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable
{
    int Health { get; set; }
    void Damage(int damageAmount);
}
