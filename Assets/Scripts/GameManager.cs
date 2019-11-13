using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// import UI engine
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // prefabs used as toppings
    public GameObject pineapple;
    public GameObject jellybean;
    public GameObject strawberry;
    public GameObject candy;
    public GameObject chocolate;
    public GameObject cookie;

    // var that stores whether the user
    // is holding a topping or not
    GameObject ingredient = null;

    // the speed at which the conveyer belt
    // and cake move
    public float beltSpeed = 0.02f;

    // list to keep track of toppings on cake
    public List<GameObject> toppings = new List<GameObject>();

    // list to keep track of topping names
    List<string> toppingNames = new List<string>();

    // toppings that appear on menu
    GameObject menuTopping1;
    GameObject menuTopping2;
    GameObject menuToppings3;

    // sound that plays after correct toppings
    // are placed
    public AudioClip correctCakeSound;
   
    // ref to audio source
    private AudioSource source;

    // target toppings and their numbers 
    List<int> intTargets = new List<int>();
    List<string> toppingTargets = new List<string>();


    // menu text
    public Text num1;
    public Text num2;
    public Text num3;
    public Text topping1;
    public Text topping2;
    public Text topping3;

    // displays when the user finishes a correct cake
    public Text result;

    private void Start()
    {
        // add toppings to topping names
        toppingNames.Add("Pineapple");
        toppingNames.Add("Jellybean");
        toppingNames.Add("Strawberry");
        toppingNames.Add("Candy");
        toppingNames.Add("Chocolate");
        toppingNames.Add("Cookie");

        // set the menu for the round
        setMenu();
    }

    void Awake()
    {
        // get audio source
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        // move toppings at the same speed as the cake
        for(int x = 0; x < toppings.Count; x++)
        {
            toppings[x].transform.position += new Vector3(beltSpeed, 0, 0); 
        }
        
        // places toppings where the mouse was clicked on the cake
        if (ingredient != null){
            ingredient.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f)); 
          
        }
        

    }

    public void checkCake(){
        // create empty list to hold number of each toppings for round
        List<int> result = new List<int>();
        for(int x = 0; x < 3; x++)
        {
            result.Add(0);
        }

        // increments number of particular topping in list
        // depending on whether it was placed on the cake or not
        for (int x = 0; x < toppings.Count; x++)
        {
            string name = toppings[x].name;
            if (toppingTargets.Contains(name))
            {
                int pos = toppingTargets.IndexOf(name);
                result[pos] = result[pos] + 1;
            }
        }

        // determines whether correct toppings were placed on cake
        bool correct = true;
        for(int x = 0; x < 3; x++)
        {
            if (intTargets[x] != result[x])
            {
                correct = false;
                break;
            }
        }

        // if correct toppings placed continue game
        if (correct == true)
        {
            // display to user that they did a good
            // job and play the cash register sound
            this.result.color = Color.green;
            source.PlayOneShot(correctCakeSound);
            this.result.text = "Good Job!";
        }

        // if incorrect toppings placed or not enough
        // toppings place switch to the end scene
        else if(correct == false)
        {
            SceneManager.LoadScene("End");

        }
        
        // after checking whether the cake was 
        // correct or not increase belt speed
        beltSpeed += 0.005f;
    }

    // reset result text
    public void resetResult()
    {
        this.result.text = "";
    }

    // resets toppings after successful round
    public void resetToppings()
    {
        for(int x = 0; x < toppings.Count; x++)
        {
            Destroy(toppings[x]);
        }
        toppings.Clear();
    }

    // sets the menu
    public void setMenu(){
        // clear previous menu
        intTargets.Clear();
        toppingTargets.Clear();
        Destroy(menuTopping1);
        Destroy(menuTopping2);
        Destroy(menuToppings3);

        // display number of toppings to menu
        int random1 = (Random.Range(1, 4));
        int random2 = (Random.Range(1, 4));
        int random3 = (Random.Range(1, 4));
        num1.text = (random1).ToString();
        num2.text = (random2).ToString();
        num3.text = (random3).ToString();
        
        // add target amounts
        intTargets.Add(random1);
        intTargets.Add(random2);
        intTargets.Add(random3);

        // display needed toppings to menu
        List<string> menuItems = addTopping();
        topping1.text = menuItems[0];
        topping2.text = menuItems[1];
        topping3.text = menuItems[2];

        // add topping targets for the round
        toppingTargets.Add(menuItems[0]);
        toppingTargets.Add(menuItems[1]);
        toppingTargets.Add(menuItems[2]);

        // display topping icons in correct place on the menu
        for (int x = 0; x < menuItems.Count; x++)
        {
            string menuItem = menuItems[x];
            GameObject newObj = null;
            if (menuItem == "Pineapple")
            {
                newObj = Instantiate(pineapple);
            }
            else if(menuItem == "Candy") {
                newObj = Instantiate(candy);

            }
            else if(menuItem == "Chocolate"){
                newObj = Instantiate(chocolate);

            }
            else if (menuItem == "Jellybean"){
                newObj = Instantiate(jellybean);

            }
            else if(menuItem == "Cookie"){
                newObj = Instantiate(cookie);

            }
            else if(menuItem == "Strawberry"){
                newObj = Instantiate(strawberry);

            }

            // set topping icon position on menu
            float xPos = -3.0f;
            if (x == 0)
            {
                newObj.transform.position = new Vector3(xPos, 2.30f,0);
                menuTopping1 = newObj;
            }
            else if (x == 1)
            {
                newObj.transform.position = new Vector3(xPos, 1.40f, 0);
                menuTopping2 = newObj;
            }
            else
            {
                newObj.transform.position = new Vector3(xPos, 0.50f, 0);
                menuToppings3 = newObj;

            }
        }

    }



    // decides needed toppings for round
    public List<string> addTopping()
    {
        // list to hold menu items
        List<string> menuItems = new List<string>();
        
        // makes sure no duplicate toppings
        while(menuItems.Count != 3)
        {
            int random = (int)Random.Range(0, 6);
            if (!menuItems.Contains(toppingNames[random]))
            {
                // add topping to list to be displayed on menu
                menuItems.Add(toppingNames[random]);
            }
        }
        return menuItems;
    } 

    // resets ingredient used for topping
    public void resetIngredient()
    {
        Destroy(ingredient);
        this.ingredient = null;
      
    }

    // places topping where mouse is clicked
    public void placeTopping()
    {
        if (ingredient != null)
        {
            GameObject newTopping = Instantiate(this.ingredient);
            newTopping.name = this.ingredient.name;
            newTopping.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));
            toppings.Add(newTopping);
            resetIngredient();

        }

    }

    // spawns pineapple toppings
    public void SpawnPineapplePiece()
    {
        // you can only hold one ingredient at a time
        if (ingredient == null)
        {
            this.ingredient = Instantiate(pineapple);
            ingredient.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f)); 
            ingredient.name = "Pineapple";

        }
    }

    // spawns jellybean topping
    public void SpawnJellybean()
    {
        // you can only hold one ingredient at a time
        if (ingredient == null)
        {
            this.ingredient = Instantiate(jellybean);
            ingredient.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));
            ingredient.name = "Jellybean";

        }
    }

    // spawns strawberry topping
    public void SpawnStrawberry()
    {
        // you can only hold one ingredient at a time
        if (ingredient == null)
        {
            this.ingredient = Instantiate(strawberry);
            ingredient.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));
            ingredient.name = "Strawberry";

        }
    }

    // spawns candy topping
    public void SpawnCandy()
    {
        // you can only hold one ingredient at a time
        if (ingredient == null)
        {
            this.ingredient = Instantiate(candy);
            ingredient.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));
            ingredient.name = "Candy";

        }
    }

    // spawns cookie topping
    public void SpawnCookie()
    {
        // you can only hold one ingredient at a time
        if (ingredient == null)
        {
            this.ingredient = Instantiate(cookie);
            ingredient.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));
            ingredient.name = "Cookie";

        }
    }

    // spawns chocolate topping
    public void SpawnChocolate()
    {
        // you can only hold one ingredient at a time
        if (ingredient == null)
        {
            this.ingredient = Instantiate(chocolate);
            ingredient.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));
            ingredient.name = "Chocolate";

        }
    }
}
