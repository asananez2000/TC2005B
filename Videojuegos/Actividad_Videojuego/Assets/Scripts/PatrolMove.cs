// Script that defines a patrol movement for obstacle objects.
// This movement makes the objects to move horizontally side to side from one edge of the 
// screen to the other

// Andreina Sananez and Ana Paula Katsuda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMove : MonoBehaviour
{
    [SerializeField] Vector2 initialDirection = Vector2.right; //initial direction
    [SerializeField] float speed; //movement speed
    [SerializeField] float offset;

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
        //Check if the object passed the right edge of the screen
        if((transform.position.x + offset) > rightEdge.x)
            initialDirection = Vector3.left; // change direction to left
        
        //Check if the object passed the left edge of the screen
        else if((transform.position.x - offset) < leftEdge.x)
            initialDirection = Vector3.right; // change direction to right

        //Move object as normal
        transform.Translate(initialDirection * speed * Time.deltaTime);
        
    }
}
