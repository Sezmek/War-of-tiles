using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public TileSpawn menager;

    private void Awake()
    {
        menager = FindAnyObjectByType<TileSpawn>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(EnemyMove), 0, 2f);
    }
    private void EnemyMove()
    {
        if(menager.STOP == 0)
        {
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!menager.PlayerMove) 
        {
            Destroy(collision.gameObject);
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
        }
    }
}
