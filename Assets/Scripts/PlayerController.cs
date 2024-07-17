using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    [SerializeField] float torqueAmount = 1f;
    SurfaceEffector2D surfaceEffector;
    float boostSpeed = 40f;
    float normalSpeed = 20f;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove) {
            RotatePlayer();
            Boost();
        }
    }

    public void DisableControls(){
        canMove = false;
    }

    private void Boost()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            surfaceEffector.speed = boostSpeed;
        }
        else{
            surfaceEffector.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody2D.AddTorque(-torqueAmount);
        }
    }
}
