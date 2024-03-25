using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public int health;
    public bool _isAlive; 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ReactToHit(int damage)
    {
        this.health -= damage; 
    }
}
