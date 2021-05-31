using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int Health { get; set; }
    private PlayerController playerController;
    private Animator _animator;
    private bool _endState = false;

    void Start()
    {
        Health = 1;
        playerController = gameObject.GetComponent<PlayerController>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            if (_endState == false)
                StartCoroutine(Explode());
            //defeat
        }
        else
        {
            playerController.projectileIndex = 0;
        }   
    }

    private IEnumerator Explode()
    {
        _endState = true;
        _animator.SetTrigger("Explosion");
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
        yield return null;
    }
}
