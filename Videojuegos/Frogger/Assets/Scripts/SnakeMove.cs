
// Script that defines the snake's patrol movement over the logs
// Andreina Sananez and Ana Paula Katsuda


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    [SerializeField] Vector2 initialDirection = Vector2.right; //initial direction
    [SerializeField] float speed; //movement speed
    private float distanceSum = 0; //sum of distance so far with each update
    private float limit = 4.2f; // log aprox distance

    //Sprites
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite rightSprite; // right snake sprite
    [SerializeField] Sprite leftSprite; // left snake sprite

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();     
    }

    // Update is called once per frame
    void Update()
    {
        distanceSum += speed * Time.deltaTime;

        //Check if snake is going right and distance has reached the limit
        if((distanceSum >= limit) && (initialDirection == Vector2.right))
        {
            spriteRenderer.sprite = leftSprite; //change sprite
            initialDirection = Vector2.left; // change direction to left
            distanceSum = 0; //reset distance
        }

        //Check if snake is going left and distance has reached the limit
        if((distanceSum >= limit) && (initialDirection == Vector2.left))
        {
            spriteRenderer.sprite = rightSprite; //change sprite
            initialDirection = Vector2.right; // change direction to right
            distanceSum = 0;//reset distance
        }
        
        //Move object as normal
        transform.Translate(initialDirection * speed * Time.deltaTime);
        
    }
}
