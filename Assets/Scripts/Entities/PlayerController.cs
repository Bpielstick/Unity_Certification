using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _direction;
    private float _xDirection = 0, _yDirection = 0;
    private Thruster _thruster;
    private Weapon _weapon;
    private Animator _animator;

    private PlayerHealth _health;
    [SerializeField] private GameObject _projectile1, _projectile2, _projectile3;
    [SerializeField] private GameObject _powerupPickup;
    private List<GameObject> _projectileList = new List<GameObject>();
    public int projectileIndex = 0;

    void Start()
    {
        _projectileList = new List<GameObject>() { _projectile1, _projectile2, _projectile3 };
        _thruster = GetComponent<Thruster>();
        _weapon = GetComponent<Weapon>();
        _health = GetComponent<PlayerHealth>();
        _animator = GetComponentInChildren<Animator>();
        AudioManager.Instance.PlaySound(2);
    }

    void Update()
    {
        Move();
        Shoot();
        Animate();
    }

    private void Move()
    {
        _xDirection = Input.GetAxisRaw("Horizontal");
        _yDirection = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(_xDirection, _yDirection, 0);

        if ((transform.position.x >= 57 && _direction.x > 0) || (transform.position.x <= -58 && _direction.x < 0))
            _direction.x = 0;

        if ((transform.position.y >= 34 && _direction.y > 0) || (transform.position.y <= -31 && _direction.y < 0))
            _direction.y = 0;

        _thruster.Move(_direction);
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            _weapon.Shoot(_projectileList[projectileIndex], projectileIndex + 4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Powerup")
        {
            Instantiate(_powerupPickup, other.transform.position, Quaternion.identity);
            if (projectileIndex < 2) { projectileIndex++; }
            UIManager.Instance.UpdatePower(projectileIndex + 1);
            UIManager.Instance.UpdateScore(500);
            AudioManager.Instance.PlaySound(11);
            Destroy(other.gameObject);
            _health.Health = 2;
        }
    }

    private void Animate()
    {
        if (_xDirection == 1)
            _animator.SetTrigger("Accelerate");
        if (_xDirection == -1)
            _animator.SetTrigger("Decelerate");
        if (_xDirection == 0)
            _animator.SetTrigger("Thruster");
    }
}
