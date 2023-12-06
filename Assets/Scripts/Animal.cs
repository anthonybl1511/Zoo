using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    protected string animalName;
    protected int age;
    protected float moveSpeed;
    protected enum FoodTypes
    { 
        Fish,
        Meat,
        Vegetables,
        LivingAnimal
    }
    [SerializeField] protected FoodTypes favoriteFood;
    [SerializeField] protected FoodTypes secondaryFood;
    protected float hunger;
    protected float thirst;
    protected float tiredness;
    protected float happiness;
    protected float XMovingDirection;
    protected float YMovingDirection;
    protected float hungerRate;
    protected float thirstRate;
    protected float tirednessRate;
    protected bool isSleeping = false;
    private bool isMoving = true;
    private bool isChilling = false;
    private bool alive = true;
    private bool isStressed = false;
    private float MovingTime;
    private float ChillingTime;
    private float SleepingTime;

    [SerializeField] protected Slider hungerSlider;
    [SerializeField] protected Slider thirstSlider;
    [SerializeField] protected Image happinessSlider;


    public void Start()
    {
        InvokeRepeating("HungerIncrease", 0, 10);
        InvokeRepeating("ThirstIncrease", 0, 5);

        XMovingDirection = Random.Range(0, 2) * 2 - 1;
        YMovingDirection = Random.Range(0, 2) * 2 - 1;

        MovingTime = Random.Range(2, 6);
    }

    private void Update()
    {
        if (alive)
        {
            if (happiness <= 0)
            {
                if (!isSleeping)
                {
                    transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * 50) * 0.0015f, transform.position.y, transform.position.z);
                }
                isStressed = true;
            }
            else
            {
                isStressed = false;
            }

            HealthCheck();
            UpdateBars();

            if (isMoving)
            {
                MoveAround();
            }
            if (!isChilling)
            {
                MovingTime = Random.Range(2, 6);
                isChilling = true;
                Invoke(nameof(Chill), MovingTime);
            }
        }
    }

    protected void MoveAround()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * XMovingDirection, transform.position.y + moveSpeed * YMovingDirection, 0);
    }

    protected void HungerIncrease()
    {
        if(!isStressed)
        {
            hunger += hungerRate;
        }
        else
        {
            hunger += hungerRate * 2;
        }
    }
    protected void ThirstIncrease()
    {
        if (!isStressed)
        {
            thirst += thirstRate;
        }
        else
        {
            thirst += thirstRate * 2;
        }
    }

    protected void Feed(string givenFood, string favoriteFood, string secondaryFood)
    {
        if(givenFood == favoriteFood && hunger > 0)
        {
            if(hunger >= 0.1f)
            {
                hunger -= 0.1f;
            }
            else
            {
                hunger = 0;
            }
            
            if(happiness < 1)
            {
                happiness += 0.3f;
            }
        }
        else if (givenFood == secondaryFood && hunger > 0)
        {
            hunger -= 0.025f;
            if (happiness < 1)
            {
                happiness += 0.15f;
            }
        }
        else
        {
            if (happiness > 0)
            {
                happiness -= 0.2f;
            }
        }
    }

    protected void Drink()
    {
        if (thirst >= 0.1f)
        {
            thirst -= 0.1f;
        }
        else
        {
            if (happiness > 0)
            {
                happiness -= 0.2f;
            }
        }
    }

    protected void Chill()
    {
        tiredness += tirednessRate;
        isMoving = false;
        ChangeMoveDirection();
        if (tiredness <= 0.5)
        {
            ChillingTime = Random.Range(2, 10);
            Invoke(nameof(MoveAgain), ChillingTime);
        }
        else if(tiredness > 0.5f)
        {
            Sleep();
        }
    }

    protected void Sleep()
    {
        CancelInvoke("HungerIncrease");
        CancelInvoke("ThirstIncrease");

        isSleeping = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        SleepingTime = Random.Range(15, 40);
        tiredness = 0;

        InvokeRepeating("HungerIncrease", SleepingTime*2, 10);
        InvokeRepeating("ThirstIncrease", SleepingTime*2, 5);

        Invoke(nameof(MoveAgain), SleepingTime);
    }

    protected void MoveAgain()
    {
        if(alive)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            isMoving = true;
            isChilling = false;
            isSleeping = false;
        }
    }

    protected void ChangeMoveDirection()
    {
        XMovingDirection = Random.Range(0, 2) * 2 - 1;
        YMovingDirection = Random.Range(0, 2) * 2 - 1;
    }

    protected void HealthCheck()
    {
        if(hunger >= 1 || thirst >= 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            alive = false;

            CancelInvoke("HungerIncrease");
            CancelInvoke("ThirstIncrease");
        }
    }

    protected void UpdateBars()
    {
        hungerSlider.value = 1 - hunger;
        thirstSlider.value = 1 - thirst;
        happinessSlider.fillAmount = happiness;
    }


    public float GetHunger()
    {
        return hunger;
    }
    public float GetThirst()
    {
        return thirst;
    }
    public float GetHappiness()
    {
        return happiness;
    }
}
