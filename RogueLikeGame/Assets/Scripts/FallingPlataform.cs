using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    private float fallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;
    // Start is called before the first frame update
    void Start()
    {
        fallingTime = 1f;
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();


    }

    void OnCollisionEnter2D (Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.layer == 8){
            Destroy(gameObject);
        }
    }
    void Falling(){
        target.enabled = false;
        boxColl.isTrigger = true;
    }
}
