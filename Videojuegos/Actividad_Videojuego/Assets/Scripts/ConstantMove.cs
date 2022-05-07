// Script that defines a repeating movement for obstacle objects.
// This movement makes the objects to go from one side of the screen to the other
// and reappear on the opposite side if they have passed the edge of the screen

// Andreina Sananez and Ana Paula Katsuda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    [SerializeField] Vector2 direction = Vector2.right; //direction to be moved
    [SerializeField] float speed; //movement speed
    [SerializeField] int size; // objects block size 

    // Vectors containing World Coordinates from the camera's edges
    private Vector3 leftEdge; 
    private Vector3 rightEdge;

    // Start is called before the first frame update
    void Start()
    {
        // Obtain edges from the camera's viewport
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);  
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the selected direction is "right" and if the object's position is past the right edge of the screen
        if (direction.x > 0 && (transform.position.x - size) > rightEdge.x) 
        {
            //The new object x position is on the left edge
            transform.position = new Vector3(leftEdge.x - size, transform.position.y, transform.position.z);
        }
           
        
       // Check if the selected direction is "left" and if the object's position is past the left edge of the screen
        else if (direction.x < 0 && (transform.position.x + size) < leftEdge.x) 
        {
            //The new object x position is on the right edge
            transform.position = new Vector3(rightEdge.x + size, transform.position.y, transform.position.z);
        }
            
        
        // If the object is not having contact with any of the edges move as normal
        else 
            transform.Translate(direction * speed * Time.deltaTime);
        
        
    }
}
