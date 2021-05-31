using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Thruster : MonoBehaviour
{
    [SerializeField] private float _speed;
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
