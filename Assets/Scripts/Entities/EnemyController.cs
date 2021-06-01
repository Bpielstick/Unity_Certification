using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject _player;
    private Thruster _thruster;
    private Weapon _weapon;
    [SerializeField] private GameObject _projectile;

    void Start()
    {
        _player = GameObject.Find("Player");
        _thruster = GetComponent<Thruster>();
        _weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        if (_player != null)
        {
            if (_player.transform.position.y < transform.position.y)
            {
                _thruster.Move(Vector3.down * 0.25f);
            }

            else if (_player.transform.position.y > transform.position.y)
            {
                _thruster.Move(Vector3.up * 0.25f);
            }
        }

        _thruster.Move(Vector3.left);
    }

    private void Shoot()
    {
        if (_player != null)
        {
            if (_player.transform.position.x < transform.position.x && transform.position.x < 43)
            {
                _weapon.Shoot(_projectile, 7);
            }
        }
    }
}
