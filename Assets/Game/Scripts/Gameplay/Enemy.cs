using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyLife;
    void Start()
    {
        
    }

    void Update()
    {
        if(enemyLife > 0)
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetHit(float damage)
    {
        enemyLife -= damage;
    }
}
