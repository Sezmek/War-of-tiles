
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    TileSpawn menager;

    private void Awake()
    {
        menager = FindAnyObjectByType<TileSpawn>();
    }
    void Update()
    {
        float positiony = transform.position.y;
        float positionx = transform.position.x;
        if (positiony == 10)
        {
            menager.LoadScene();
        }
        if (Input.GetKeyDown(KeyCode.D) && positionx != 5)
        {
            if(menager.STOP != 0)menager.STOP -= 1;
            menager.PlayerMove = true;
            transform.position = new Vector3(positionx +1, positiony, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) && positionx != -4)
        {
            if (menager.STOP != 0) menager.STOP -= 1;
            menager.PlayerMove = true;
            transform.position = new Vector3(positionx -1, positiony, 0);
        }
        if (Input.GetKeyDown(KeyCode.W) && positiony != 10)
        {
            if (menager.STOP != 0) menager.STOP -= 1;
            menager.PlayerMove = true;
            transform.position = new Vector3(positionx, positiony + 1, 0);
            
        }
        if (Input.GetKeyDown(KeyCode.S) && positiony != -9)
        {
            if (menager.STOP != 0) menager.STOP -= 1;
            menager.PlayerMove = true;
            transform.position = new Vector3(positionx, positiony -1, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(menager.PlayerMove)
        {
            Destroy(collision.gameObject);
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
            menager.STOP += 2;
        }
    }
}
