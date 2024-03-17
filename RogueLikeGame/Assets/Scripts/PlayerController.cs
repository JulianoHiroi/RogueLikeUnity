using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float input_x = 0;
    public float speed = 2.5f;
    private Rigidbody2D rig;
    private Animator anim;
    public float jumpForce = 5f;

    private bool isGrounded;
    private bool doubleJump;
    // Start is called before the first frame update
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxis("Horizontal");
        Move();
        Jump();
    }

    void Move(){
        Vector3 movement = new Vector3(input_x, 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if(input_x > 0){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("Walk", true);
        }else if(input_x < 0){
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("Walk", true);
        }else{
            anim.SetBool("Walk", false);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && (isGrounded || doubleJump)){
            anim.SetBool("Jump", true);
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            if(isGrounded == false && doubleJump == true){
                doubleJump = false;
            } 
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        anim.SetBool("Jump", false);
        if(collision.gameObject.layer == 8){
            isGrounded = true;
            doubleJump = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision ){
        isGrounded = false;
    }
}
