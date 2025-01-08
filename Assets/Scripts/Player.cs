using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Build.Content;
using Unity.Mathematics;
  

public class Player : MonoBehaviour
{
 
    private  Vector2 mousePosition;
    private Camera mainCamera;
    //private GameManager gameManager;

    float horizontalInput;
    float verticalInput;
    public float shipSpeed;

    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
     
    // Update is called once per frame
    void Update()
    {
        RotateToMouse();
        Move();
    }


    void RotateToMouse()
    {
    mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    Vector2 targetDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
    transform.rotation = Quaternion.FromToRotation(Vector3.up, targetDirection);
    }
    
    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * shipSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * shipSpeed);
        
    }
}
