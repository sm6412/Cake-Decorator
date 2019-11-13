using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeBehavior : MonoBehaviour {
    // ref to game manager
    public GameManager gameManager;
    // ref to cake object
    public GameObject cake;
    
    // pink cake prefab
    public GameObject PinkCake;
    // orange cake prefab
    public GameObject OrangeCake;
    // blue cake prefab
    public GameObject BlueCake;
    // green cake prefab
    public GameObject GreenCake;


    private void Start()
    {
        // set cake
        ResetCake();
        
    }

    // Update is called once per frame
    void Update () {
        // move the cake according to the conveyer belt speed
        cake.transform.position += new Vector3(gameManager.beltSpeed, 0, 0);
        
        // if the cake has the correct toppings and has reached the end of the
        // belt reset a new cake
        if (cake.transform.position.x >= -9.97f && (gameManager.result.text == "Good Job!"))
        {
            gameManager.resetResult();
        }


        if (cake.transform.position.x >= 9.81)
        {
            Destroy(cake);
            ResetCake();
            // see if order is correct
            gameManager.checkCake();
            // remove toppings
            gameManager.resetToppings();
            // reset menu
            gameManager.setMenu();
        }

    }



    void ResetCake()
    {
        // generate random number to decide
        // which color cake to use for round
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            cake = Instantiate(PinkCake);
        }
        else if (random == 2)
        {
            cake = Instantiate(BlueCake);
        }
        else if (random == 3)
        {
            cake = Instantiate(GreenCake);
        }
        else
        {
            cake = Instantiate(OrangeCake);
        }
        // set cake's starting pos
        cake.transform.position = new Vector3(-11.46f, -1.78f, 0f);

    }


}
