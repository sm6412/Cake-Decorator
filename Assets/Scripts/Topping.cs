using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Topping : MonoBehaviour
{
    // ref to the game manager
    public GameManager gameManager;
    // determines whether you are holding a 
    // topping or not
    public bool hasIngredient = false;



    // Update is called once per frame
    void Update()
    {
        RayCasting();
    }

    void RayCasting()
    {
        // get mouse pos
        Vector3 mousePos = Input.mousePosition;
        // set z axis of mouse
        mousePos.z = 10;

        // get mouse pos with regards to camera 
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);
        // use raycasting to see if the user clicked on an object
        if (hit && Input.GetMouseButtonDown(0))
        {
            // spawn pineapple topping if crate clicked
            if (hit.collider.tag == "pineapple")
            {
                gameManager.resetIngredient();
                gameManager.SpawnPineapplePiece();
                hasIngredient = true;
            }
            // spawn jellybean topping if crate clicked
            else if (hit.collider.tag == "jellybean")
            {
                gameManager.resetIngredient();
                gameManager.SpawnJellybean();
                hasIngredient = true;
            }
            // spawn strawberry topping if crate clicked
            else if (hit.collider.tag == "strawberry")
            {
                gameManager.resetIngredient();
                gameManager.SpawnStrawberry();
                hasIngredient = true;
            }
            // spawn cookie topping if crate clicked
            else if (hit.collider.tag == "cookie")
            {
                gameManager.resetIngredient();
                gameManager.SpawnCookie();
                hasIngredient = true;
            }
            // spawn chocolate topping if crate clicked
            else if (hit.collider.tag == "chocolate")
            {
                gameManager.resetIngredient();
                gameManager.SpawnChocolate();
                hasIngredient = true;
            }
            // spawn candy topping if crate clicked
            else if (hit.collider.tag == "candy")
            {
                gameManager.resetIngredient();
                gameManager.SpawnCandy();
                hasIngredient = true;
            }
            // if the user clicks the cake, have the topping remain on
            // the cake 
            else if(hit.collider.tag == "cake" && hasIngredient == true)
            {
                gameManager.placeTopping();
                hasIngredient = false;
            }
        }
        // if the user does not click on the cake with the topping destroy it
        else if(hit==false && Input.GetMouseButtonDown(0) && hasIngredient==true)
        {
            gameManager.resetIngredient();
            hasIngredient = false;
        }

    }








}
