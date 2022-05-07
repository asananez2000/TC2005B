// Script that defines the player's collisions with obstacles and other game elements

// Andreina Sananez and Ana Paula Katsuda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManage managerObj;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0; //initialize points  
        managerObj = FindObjectOfType<GameManage>(); //initialize obj
    }

    // Update is called once per frame
    void Update()
    {
        //Evaluate death by running out of points
        if(points < 0)
            managerObj.Death();   
    }

    // Detect collision with different objects
    void OnTriggerEnter2D(Collider2D col)
    {
        // On Enter, make the platform parent of player to follow movement
        if (col.tag == "Platform") 
        {
            // saved = true; // activate to overcome collision with water/background
            transform.SetParent(col.transform);
        } 

        // Obstacles that are not water
        if (col.tag == "Obstacle")
        {
            points--; //decrease points   
            managerObj.writePoints(points); //Write text element
        }  

        // If collides with coin
        if (col.tag == "Coin") 
        {
            // Store the points in a "global" variable
            points++;

            //Write text element
            managerObj.writePoints(points);

            // Destroy coin gameObject
            Destroy(col.gameObject);
        }  

        //If with goal
        if(col.tag == "Win")
            managerObj.Win();
    
    }

    
    // Detect exit collision with platform
    void OnTriggerExit2D(Collider2D col)
    {
        // // On Exit, remove parent from platform to player to stop following movement
        if (col.tag == "Platform") 
        {
            // saved = false; // deactivate saved state
            transform.SetParent(null);
        }  
    }

}


