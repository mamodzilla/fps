using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
//using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    
    private float speed = 6.0f;
    private CharacterController characterController;
    private float gravity = -9.8f;

    private float clickTime;

    private KeyCode previousKey;

    public float dashTime = 0.5f;
    public float dashDistance = 5f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        } else {
            speed = 6.0f;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            Dash(KeyCode.W, new Vector3(0, 0, dashDistance));
        } else if (Input.GetKeyDown(KeyCode.A)) {
            Dash(KeyCode.A, new Vector3(-dashDistance, 0, 0));
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Dash(KeyCode.S, new Vector3(0, 0, -dashDistance));
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            Dash(KeyCode.D, new Vector3(dashDistance, 0, 0));
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        movement.y = gravity;
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
    private void Dash(KeyCode currentKey, Vector3 movement)
    {
        if ((Time.time - clickTime) < dashTime && previousKey == currentKey)
        {
            movement.y = gravity;
            movement = transform.TransformDirection(movement);
            characterController.Move(movement); 
        }
        clickTime = Time.time;
        previousKey = currentKey;
    } 
}

