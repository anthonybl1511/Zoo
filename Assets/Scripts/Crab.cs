using UnityEngine;

public class Crab : Animal
{
    new void Start()
    {
        base.Start();

        age = 1;
        hunger = 0;
        thirst = 0;
        tiredness = 0;
        happiness = 1;
        moveSpeed = 0.0015f;

        thirstRate = 0.15f;
        hungerRate = 0.05f;
        tirednessRate = 0.05f;
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
