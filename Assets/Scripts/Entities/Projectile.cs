using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Ammo _ammo;
    [SerializeField] private GameObject _hit;
    public float cooldown
    {
        get { return _ammo.cooldown; }
    }

    void Update()
    {
        if (_ammo.friendly)
            transform.Translate(Vector3.right * _ammo.speed * Time.deltaTime);
        else if (!_ammo.friendly)
            transform.Translate(Vector3.left * _ammo.speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if ((!_ammo.friendly && other.tag == "Player") || (_ammo.friendly && other.tag == "Enemy"))
        {   
            if (damageable != null)
                damageable.Damage(_ammo.damage);
            Instantiate(_hit, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySound(3);
            Destroy(gameObject);    
        }
    }
}
