using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _canFire = true;
    private GameObject newProjectile;

    public void Shoot(GameObject projectile)
    {
        if (_canFire)
        {
            newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            _canFire = false;
            StartCoroutine(cooldownRoutine());
        }
    }

    private IEnumerator cooldownRoutine()
    {
        yield return new WaitForSeconds(newProjectile.GetComponent<Projectile>().cooldown);
        _canFire = true;
    }
}
