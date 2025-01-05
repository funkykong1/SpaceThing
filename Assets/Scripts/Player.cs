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

    public float rotateSpeed;

    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        RotateToMouse();
    }

    void RotateToMouse()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 targetDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

 


    }
}
