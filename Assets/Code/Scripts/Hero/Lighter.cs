using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public KeyCode keyTrigger = KeyCode.F;
    public GameObject lighter;
    void Start()
    {
        lighter.SetActive(false);    
    }
    void Update()
    {
        if (Input.GetKeyDown(keyTrigger))
        {
            lighter.SetActive(true);
        } 
        else if (Input.GetKeyUp(keyTrigger)) 
        {
            lighter.SetActive(false);
        }        
    }
}
