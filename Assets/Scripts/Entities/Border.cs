using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            SpawnManager.Instance.SpawnCount--;

        Destroy(other.gameObject);
    }
}
