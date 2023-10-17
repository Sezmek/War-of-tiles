using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;
    public bool PlayerMove;
    public int STOP;
    private void Start()
    {
        PlayerSpawn();
        EnemySpawn();
        EnemySpawn();
    }
    public void EnemySpawn()
    {
        int positonx = Random.Range(-4, 6);
        Vector2 position = new Vector2(positonx, 10);
        while(Physics2D.OverlapBox(position, new Vector2(1,1), 0))
        {
            positonx = Random.Range(-4, 6);
            position = new Vector2(positonx, 10);
        }
        Instantiate(Enemy, position, Quaternion.identity);
    }
    public void PlayerSpawn()
    {
        int positonx = Random.Range(-4, 6);
        Vector2 position = new Vector2(positonx, -9);
        Instantiate(Player, position, Quaternion.identity);
    }
}
