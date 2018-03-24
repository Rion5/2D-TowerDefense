using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //SerializeField - Allows Inspector to get access to private fields.
    //If we want to get access to this from another class, we'll just need to make public getters
    [SerializeField]
    private Transform exitPoint;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private float navigationUpdate;

    private int target = 0;
    private Transform enemy;
    private float navigationTime = 0;


	// Use this for initialization
	void Start () {
        enemy = GetComponent<Transform>();
        GameManager.Instance.RegisterEnemy(this);
	}
	
	// Update is called once per frame
	void Update () {
		if (wayPoints != null)
        {
            //Lets use change how fast the update occurs
            navigationTime += Time.deltaTime;
            if(navigationTime > navigationUpdate)
            {
                //If enemy is not at the last wayPoint, keep moving towards the wayPoint
                //otherwise move to the exitPoint
                if(target < wayPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
	}

    //If we trigger the collider2D.tag for checkpoints for finish. 
    //If it hits the checkpoints, increase the index and move to the next checkpoint
    //otherwise enemy is at the finish line and should be destroyed.
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "checkpoint")
            target += 1;
        else if (collider2D.tag == "Finish")
        {
            GameManager.Instance.UnregisterEnemy(this);
        }
    }
}
