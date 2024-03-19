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
    Hero hero = new Hero(10);

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        inputX = 0;
        inputY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        Move();
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

        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * hero.getSpeed();
    }
}
