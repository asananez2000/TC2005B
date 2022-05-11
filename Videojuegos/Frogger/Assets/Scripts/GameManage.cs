// Script that defines win and death behaviours as well as UI functioning

// Andreina Sananez and Ana Paula Katsuda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    // Other classes
    private PlayerMove playerObj;
    private PlayerCollision collisionObj;
    
    public bool movementEnable; //movement enable after win or death

    // Sprites
    [SerializeField] Sprite deadSprite;
    [SerializeField] Sprite winSprite;

    //UI Elements
    [SerializeField] Text pointsText;
    [SerializeField] Text winText;
    [SerializeField] Text deathText;
    [SerializeField] Text thanksText;

    // Start is called before the first frame update
    void Start()
    {
        movementEnable = true;  
        playerObj = FindObjectOfType<PlayerMove>(); //initialize obj
        collisionObj = FindObjectOfType<PlayerCollision>(); //initialize obj  
    }

    // Update is called once per frame
    void Update()
    {
        // if player has already won or died diplay thanks text
        if(!movementEnable)
            thanksText.enabled = true;   
    }

    //Function that defines death behaviour
    public void Death()
    {
        movementEnable = false;
        playerObj.spriteRenderer.sprite = deadSprite; //change sprite
        deathText.enabled = true;
    }

    //Function that defines win behaviour
    public void Win()
    {
        movementEnable = false;
        playerObj.spriteRenderer.sprite = winSprite; //change sprite
        winText.enabled = true;
        deathText.enabled = false;//disable dead text from water collision  
    }

    // Method that rewrites the point's text element
    public void writePoints(int points)
    {
        //Make sure the final score is not -1
        if (points >= 0)
            pointsText.text = "Points: " + points;
        else
            pointsText.text = "Points: " + 0;

    }

    // //Function that restarts the game
    // private void gameRestart()
    // {
    //     playAgainText.enabled = true; // set active play again text

    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         collisionObj.points = 0; //restart points
    //         writePoints(collisionObj.points); //update points text
            
    //         //Restart active state of text elements
    //         deathText.enabled = false;
    //         winText.enabled = false;
    //         playAgainText.enabled = false;

    //         //Reset player position
    //         transform.position = new Vector3(0, -7.53f, 0);

    //         //Reset Sprite
    //         playerObj.spriteRenderer.sprite = playerObj.defaultSprite; //change sprite

    //         //Reset movementEnable
    //         movementEnable = true;
   
    //     }

    // }

    
}


