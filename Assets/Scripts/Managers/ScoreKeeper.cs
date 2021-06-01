using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper _instance;
    public static ScoreKeeper Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Score Keeper = Null");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }


}
