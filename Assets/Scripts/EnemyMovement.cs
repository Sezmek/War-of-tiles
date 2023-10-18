using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    TileSpawn menager;
    PlayerMovement player;

    private void Start()
    {
        menager = FindAnyObjectByType<TileSpawn>();
        player = FindAnyObjectByType<PlayerMovement>();
        InvokeRepeating(nameof(EnemyMove), 1f, 2f);
    }
    private void EnemyMove()
    {
        if(menager.STOP == 0)
        {
            Vector2 newEnemyPosition = CalculateDirection();
            RaycastHit2D hit = Physics2D.Raycast(newEnemyPosition, Vector2.zero);

            if (hit.collider == null || hit.collider.gameObject.CompareTag("Player"))
            {
                menager.PlayerMove = false;
                transform.position = newEnemyPosition;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!menager.PlayerMove && !collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(collision.gameObject);
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
            menager.LoadScene();
        }
    }
    Vector2 CalculateDirection()
    {
        float dx = transform.position.x - player.transform.position.x;
        float dy = transform.position.y - player.transform.position.y;
        Vector2 vector2 = new Vector2(transform.position.x, transform.position.y);
        if (dx > 0)
        {
            vector2.x -= 1;
        }
        if (dx < 0)
        {
            vector2.x += 1;
        }
        if (dy < 0)
        {
            vector2.y += 1;
        }
        if (dy > 0)
        {
            vector2.y -= 1;
        }
        return vector2;
    }
}
