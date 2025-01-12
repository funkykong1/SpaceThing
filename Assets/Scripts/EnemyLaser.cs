using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Build.Content;
using Unity.Mathematics;
using Unity.VisualScripting;


public class EnemyLaser : Enemy
{

    public bool attacking, playerVisible;
    Vector2 target;
    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Attack()
    {
        attacking = true;
        //handle where the enemy is facing
        while(attacking)
        {
            //player visible, face towards player
            if(attacking && playerVisible)
            {
                target = player.transform.position;
            }
            //player out of sight, face towards a node or something
            else if(attacking && !playerVisible)
            {

            }
        }
        Vector2 targetDirection = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, targetDirection);

        yield return null;
    }
}
