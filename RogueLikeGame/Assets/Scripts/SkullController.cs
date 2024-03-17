using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    // Start is called before the first frame update

    public int Score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            Destroy(gameObject);

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
        }
    }

}
