using UnityEngine;

public class Rex : Animal
{
    new void Start()
    {
        base.Start();

        animalName = "T-Rex";
        age = 1000;
        hunger = 0;
        thirst = 0;
        tiredness = 0;
        happiness = 1;
        moveSpeed = 0.0002f;

        thirstRate = 0.1f;
        hungerRate = 0.33f;
        tirednessRate = 0.1f;
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
                    happiness -= 0.3f;
                }
            }
        }
        
        if(Input.GetMouseButtonDown(1) && !isSleeping)
        {
            Drink();
        }
    }
}
