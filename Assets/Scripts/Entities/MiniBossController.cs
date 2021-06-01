using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossController : MonoBehaviour
{
    private GameObject _player;
    private Thruster _thruster;
    private Weapon[] _weapons;
    [SerializeField] private GameObject _projectile;

    void Start()
    {
        _player = GameObject.Find("Player");
        _thruster = GetComponent<Thruster>();
        _weapons = GetComponentsInChildren<Weapon>();
    }


    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        _thruster.Move(Vector3.left);
    }

    private void Shoot()
    {
        if (_player != null)
        {
            if (_player.transform.position.x < transform.position.x && transform.position.x < 48)
            {
                foreach (Weapon weapon in _weapons)
                {
                    weapon.Shoot(_projectile, 7);
                }
            }
        }
    }
}
