using UnityEngine;

public class Crocodile : Animal
{
    new void Start()
    {
        base.Start();

        age = 5;
        hunger = 0;
        thirst = 0;
        tiredness = 0;
        happiness = 1;
        moveSpeed = 0.0005f;

        thirstRate = 0.1f;
        hungerRate = 0.2f;
        tirednessRate = 0.3f;
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && !isSleeping)
        {
            if (hunger != 0)
            {
                Feed(Hotbar.currentTool, favoriteFood.ToString(), secondaryFood.ToString());
            }
            else
            {
                if(happiness > 0)
                {
                    happiness -= 0.2f;
                }
            }
        }
        
        if(Input.GetMouseButtonDown(1) && !isSleeping)
        {
            Drink();
        }
    }
}
