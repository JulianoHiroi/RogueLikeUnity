using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IEnemy : MonoBehaviour
{
    // Start is called before the first frame update   
    SpriteRenderer sprite;
    string id;
    Enemy enemy;
    float[] direction;
    Guid guid = Guid.NewGuid();
    void Start()
    {
        id = guid.ToString();
        sprite = GetComponent<SpriteRenderer>();
        GameController.CreateEnemy(id);
        enemy = GameController.enemies[id];
        enemy.setTarget(GameController.getHero());
        float[] position = enemy.getPosition();
        transform.position = new Vector3(position[0], position[1], 0);
        direction = null;
        InvokeRepeating("GetDirection", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        if (direction != null)
        {
            if (direction[0] > 0)
            {
                sprite.flipX = false;
            }
            else if (direction[0] < 0)
            {
                sprite.flipX = true;
            }
            Vector3 movement = new Vector3(direction[0], direction[1], 0);
            transform.position += movement * Time.deltaTime * enemy.getSpeed();

            enemy.setPositon(transform.position.x, transform.position.y);
        }
    }

    void GetDirection()
    {
        direction = enemy.GetTargetDirection();

    }
}
