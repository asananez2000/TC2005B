
// Script that defines the player's movement and win death function calls

// Andreina Sananez and Ana Paula Katsuda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private GameManage managerObj;

    public Sprite defaultSprite;
    [SerializeField] Sprite leapSprite;

    //Saved haven't had a collision with water
    //private bool obstacleCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        managerObj = FindObjectOfType<GameManage>(); //initialize obj 
    }

    // Update is called once per frame
    void Update()
    {
        //Only move is movement is enable (player is alive or hasn't finished the game)
        if(managerObj.movementEnable)
        {
                // Change corresponding rotation and movement if up arrow pressed
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); // change rotation according to direction
                Move(Vector3.up);
            }

            // Change corresponding rotation and movement if left arrow pressed
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                Move(Vector3.left);
            }

            // Change corresponding rotation and movement if right arrow pressed
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                Move(Vector3.right);
            }

            // Change corresponding rotation and movement if down arrow pressed
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                Move(Vector3.down);
            }
        }
    }

    // Method that changes the player transform position according to a given vector
    private void Move(Vector3 direction)
    {
        //Determine destination or player's next step
        Vector3 destination = transform.position + direction;

        // Check for collision at the destination
        Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D water = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Water"));
        Collider2D platform = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));

        // if the variable barrier captured a "barrier layer" 
        if (barrier != null) {
            return; // avoid movement by returning function and preventing coroutine from happening
        }

        // If there is a collision with water and player is not on a platform
        if (water != null && platform == null)
        {
            managerObj.Death(); //player dies
            transform.position = destination; // make sprite appear in destination not before
        }

        //Call Leap Animation when player is not dead or has not won
        if(managerObj.movementEnable)
            StartCoroutine(Leap(destination));
    }

    // Coroutine fucntion -> IEnumerator type lets you stop the process at a specific moment
    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;

        // Define time variables
        float elapsedTime = 0f;
        float duration = 0.125f;

        // Set leap sprite 
        spriteRenderer.sprite = leapSprite;
        
        //Loop that lasts as long as the duration
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // calculate the percentage of time elapsed compared to the set duration
            transform.position = Vector3.Lerp(startPosition, destination, t); // change the position according to the percentage of the duration elapsed
            elapsedTime += Time.deltaTime; //update the time elapsed
            yield return null;
        }

        // After duration has passed, set position and sprite to their end state
        transform.position = destination;

        //Change sprite
        spriteRenderer.sprite = defaultSprite;
    }

    

}
