using System;
using UnityEngine;

public class trigScript : MonoBehaviour
{
    public theLogic logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<theLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        //if(collision.gameObject.layer == 3){
            logic.addScore();
        //}
    }
}
