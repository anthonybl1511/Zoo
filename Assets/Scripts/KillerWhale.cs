using UnityEngine;

public class KillerWhale : Animal
{
    new void Start()
    {
        base.Start();

        animalName = "T-Rex";
        age = 100;
        hunger = 0;
        thirst = 0;
        tiredness = 0;
        happiness = 1;
        moveSpeed = 0.00005f;

        thirstRate = 0.05f;
        hungerRate = 0.4f;
        tirednessRate = 0.5f;
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
                    happiness -= 0.4f;
                }
            }
        }
        
        if(Input.GetMouseButtonDown(1) && !isSleeping)
        {
            Drink();
        }
    }
}
