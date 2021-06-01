using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            UIManager.Instance.UpdatePower(playerController.projectileIndex + 1);
        }   
    }

    private IEnumerator Explode()
    {
        _endState = true;
        _animator.SetTrigger("Explosion");
        AudioManager.Instance.PlaySound(9);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("DefeatScene");
        Destroy(gameObject);
        yield return null;
    }
}
