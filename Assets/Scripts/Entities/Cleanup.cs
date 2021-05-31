using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    [SerializeField] float _delay;

    void Start()
    {
        StartCoroutine(cleanup());
    }

    private IEnumerator cleanup()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
        yield return null;
    }
}
