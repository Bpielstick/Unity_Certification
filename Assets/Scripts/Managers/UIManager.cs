using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("UI Manager = Null");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] Text _scoreText;
    [SerializeField] Text _powerText;
    [SerializeField] GameObject _pauseMenu;
    private int _score = 0;
    private int _power = 1;
    private bool _pause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void UpdateScore(int newScore)
    {
        _score += newScore;
        _scoreText.text = "" + _score;
    }

    public void UpdatePower(int newPower)
    {
        _power = newPower;
        _powerText.text = "" + _power;
    }

    public void Pause()
    {
        if (!_pause)
        {
            _pauseMenu.SetActive(true);
            _pause = true;
            Time.timeScale = 0;
            AudioManager.Instance.StopAudio();
        }
        else if (_pause)
        {
            _pauseMenu.SetActive(false);
            _pause = false;
            Time.timeScale = 1;
            AudioManager.Instance.StartAudio();
        }
    }

}
