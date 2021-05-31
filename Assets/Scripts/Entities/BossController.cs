using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Thruster _thruster;
    private Weapon[] _weapons;
    private EnemyHealth _health;
    private Animator _animator;
    [SerializeField] private GameObject _projectile;
    private bool _moveUp;
    private bool _smoke = false;

    void Start()
    {
        _thruster = GetComponent<Thruster>();
        _weapons = GetComponentsInChildren<Weapon>();
        _health = GetComponent<EnemyHealth>();
        _animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        if (_health.Health > 15)
        {
            if (transform.position.x > 40)
            { 
                _thruster.Move(Vector3.left);
                yield return null;
            }
            yield return null;
        }
        else if(_health.Health <= 15)
        {
            if (!_smoke) 
            { 
                _smoke = true; 
                _animator.SetTrigger("Smoke"); 
            }
            
            if (_moveUp)
                _thruster.Move(Vector3.up);
            else if (!_moveUp)
                _thruster.Move(Vector3.down);

            if (transform.position.y > 30)
                _moveUp = false;
            if (transform.position.y < -26)
                _moveUp = true;
            yield return null;
        }
        yield return null;
    }

    private void Shoot()
    {
        if (transform.position.x < 46)
        {
            foreach (Weapon weapon in _weapons)
            {
                weapon.Shoot(_projectile);
            }
        }
    }
}

