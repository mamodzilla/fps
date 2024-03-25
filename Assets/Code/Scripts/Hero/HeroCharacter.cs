using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HeroCharacter : MonoBehaviour
{
    private int health = 100;
    private bool _gameOver;

    private void Start()
    {
        health = 100;
        _gameOver = false;
    }

    void Update()
    {

        if (_gameOver)
        {
            SceneManager.LoadScene("SampleScene"); 
        }
    }

    public void Hurt(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            _gameOver = true;
        }
    }
}
