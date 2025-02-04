using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Build.Content;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.AI;


public class EnemyLaser : Enemy
{

    public bool alerted, playerVisible;
    Vector2 target;
    GameObject player, parent;
    private NavMeshAgent agent;

    void Awake()
    {
        //PARENT USED TO MOVE AND ROTATE
        //parent = GetComponentInParent<GameObject>();
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Attack()
    {
        alerted = true;
        //handle where the enemy is facing
        while(alerted)
        {
            //player visible, face towards player
            if(alerted && playerVisible)
            {
                target = player.transform.position;
            }
            //player out of sight, face towards a node or something
            else if(alerted && !playerVisible)
            {

            }
        }
        Vector2 targetDirection = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, targetDirection);

        yield return null;
    }
}
