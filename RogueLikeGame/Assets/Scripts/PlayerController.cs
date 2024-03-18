using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float input_x = 0;
    public float speed = 2.5f;
    private Rigidbody2D rig;
    private Animator anim;
    public float jumpForce = 5f;

    private bool isGrounded;
    private bool doubleJump;

    public bool inPortal ;
    // Start is called before the first frame update
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inPortal = false;

    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxis("Horizontal");
        
        
        if(inPortal && Input.GetButtonDown("Jump")){
            Debug.Log("Portal");
            SceneManager.LoadScene("Level_2");
        }
        Jump();
        Move();
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
        if(collision.gameObject.tag == "Spikes"){
            Debug.Log("Morreu");
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D collision ){
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Portal"){
            inPortal = true;
            Debug.Log("Entrou");
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Portal"){
            inPortal = false;
        }
    }
}


