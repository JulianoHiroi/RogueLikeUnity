using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IEnemy : MonoBehaviour
{
    // Start is called before the first frame update   
    SpriteRenderer sprite;
    Enemy enemy;
    float[] direction;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy = GameController.getEnemy();
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
