using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxxBall : MonoBehaviour
{
    [SerializeField] private List<Rigidbody2D> listBall;
    public string type = "red";
    public GameManager _gameManager;

    public void Attack()
    {
        foreach (var ball in listBall)
        {
            ball.transform.parent = _gameManager.trash;
            ball.gravityScale = 1;
            ball.AddForce(new Vector2(Random.Range(-2.5f,2.5f),Random.Range(-2.5f,2.5f)));
        }
        Destroy(gameObject);
    }
}
