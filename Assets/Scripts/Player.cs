using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Build.Content;
using Unity.Mathematics;
using Unity.VisualScripting;


public class Player : MonoBehaviour
{
 
    private  Vector2 mousePosition;
    private Camera mainCamera;
    //private GameManager gameManager;

    float horizontalInput;
    float verticalInput;
    public float shipSpeed;
    private GameObject map;
    float xRange, yRange;

    void Awake()
    {
        mainCamera = GameObject.Find("Brain").GetComponent<Camera>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        map = GameObject.Find("Map");
        xRange = map.GetComponent<Map>().xRange;
        yRange = map.GetComponent<Map>().yRange;
    }
     
    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        RotateToMouse();
        Move();

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
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
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * shipSpeed, Space.World);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * shipSpeed, Space.World);
        
    }
}
