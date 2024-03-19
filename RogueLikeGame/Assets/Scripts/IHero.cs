using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IHero : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer sprite;
    Animator animator;
    float inputX;
    float inputY;

    Hero hero;
    Vector3 moviment;
    Vector3 position;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        inputX = 0;
        inputY = 0;
        hero = new Hero(5, 0, 0);
        moviment = new Vector3(0, 0, 0);
        position = new Vector3(hero.getPosition()[0], hero.getPosition()[1], 0);

        //print(hero.getPosition().GetValue(0));
        transform.position = position;


    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        moviment.Set(inputX, inputY, 0);
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hero.getPosition()[0]);
            Debug.Log(hero.getPosition()[1]);
        }
    }

    private void Move()
    {
        if (inputX < 0)
        {
            animator.SetBool("isWalkingX", true);
            sprite.flipX = false;
        }
        else if (inputX > 0)
        {
            animator.SetBool("isWalkingX", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("isWalkingX", false);
        }
        if (inputY < 0)
        {
            animator.SetBool("isWalkingYDown", true);
            animator.SetBool("isWalkingYUp", false);
        }
        else if (inputY > 0)
        {
            animator.SetBool("isWalkingYUp", true);
            animator.SetBool("isWalkingYDown", false);
        }
        else
        {
            animator.SetBool("isWalkingYDown", false);
            animator.SetBool("isWalkingYUp", false);
        }

        transform.position += moviment * Time.deltaTime * hero.getSpeed();
        hero.setPositon(transform.position.x, transform.position.y);
    }
}
