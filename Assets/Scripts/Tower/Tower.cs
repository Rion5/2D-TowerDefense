using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField]
    private float timeBetweenAttacks;   //AKA - Attack Speed
    [SerializeField]
    private float attackRange;          //AKA - Attack Radius
    private Projectile projectile;
    private Enemy targetEnemy = null;
    private float attackCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        attackCounter -= Time.deltaTime;
        //If our closest enemy in range and if its within our attackRange, set our target enemy to the closest enemy in range.
        if (targetEnemy == null)
        {
            Enemy closestEnemy = GetClosestEnemyInRange();
            if(closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) <= attackRange)
            {
                targetEnemy = closestEnemy;
            }
        }

        //If enemy gets out of attack range, then that enemy can no longer be targeted
        if(Vector2.Distance(transform.position, targetEnemy.transform.position) > attackRange)
        {
            targetEnemy = null;
        }
	}
    ///Get Enemies in Attack Range
    private List<Enemy> GetEnemiesInRange()
    {
        List<Enemy> enemiesInRange = new List<Enemy>();

        //Check if enemies are in range
        foreach(Enemy enemy in GameManager.Instance.EnemyList)
        {
            if(Vector2.Distance(transform.position, enemy.transform.position) <= attackRange)
            {
                enemiesInRange.Add(enemy);
            }
        }
        return enemiesInRange;
    }
    ///Get Closest Enemy - Foreach enemy in range, get the closest enemy
    private Enemy GetClosestEnemyInRange()
    {
        Enemy closestEnemy = null;
        float smallestDistance = float.PositiveInfinity; 

        foreach(Enemy enemy in GetEnemiesInRange())
        {
            if(Vector2.Distance(transform.position, enemy.transform.position) < smallestDistance)
            {
                smallestDistance = Vector2.Distance(transform.position, enemy.transform.position);
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}
