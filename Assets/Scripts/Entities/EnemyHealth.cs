using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    private Animator _animator;
    public int Health { get; set; }
    private bool _isDying = false;

    void Start()
    {
        Health = _health;
        _animator = GetComponentInChildren<Animator>();
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;

        //fx

        if (Health <= 0 && !_isDying)
        {
            _isDying = true;

            DropItem dropItem = GetComponent<DropItem>();

            if (dropItem != null)
                dropItem.Drop();

            SpawnManager.Instance.SpawnCount--;

            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        _animator.SetTrigger("Explosion");
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
        yield return null;
    }
}
