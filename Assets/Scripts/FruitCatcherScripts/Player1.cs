﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Transform tr;
    private main main;

    // Variabile pentru săritură
    public float jumpHeight = 3f;
    public float jumpSpeed = 5f;
    private bool isJumping = false;
    private float verticalVelocity = 0f;
    private float originalY;

    //sprite variables
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; //idle and walk
    private int spriteIndex;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        tr = GetComponent<Transform>();
        originalY = tr.position.y;
        main = GameObject.Find("scripts").GetComponent<main>(); // Obține referința la scriptul de scor
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("d") && tr.position.x < 4f)
        {
            tr.position += new Vector3(0.1f, 0, 0);
            spriteRenderer.flipX = false;
            AnimateSprite();
        }

        if (Input.GetKey("a") && tr.position.x > -4f)
        {
            tr.position += new Vector3(-0.1f, 0, 0);
            spriteRenderer.flipX = true;
            AnimateSprite();
        }

        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            isJumping = true;
            verticalVelocity = jumpSpeed;
        }

        if (isJumping)
        {
            tr.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);
            verticalVelocity -= 9.81f * Time.deltaTime;

            if (tr.position.y <= originalY)
            {
                tr.position = new Vector3(tr.position.x, originalY, tr.position.z);
                isJumping = false;
                verticalVelocity = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Apple" || collision.gameObject.name == "Ananas" || collision.gameObject.name == "Orange")
        {
            Destroy(collision.gameObject);
            
        }
        else if (collision.gameObject.name == "Bomba")
        {
            Destroy(this.gameObject);
            Destroy(GameObject.Find("redChickenFlip"));
         
        }
    }

    //Animation
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}

