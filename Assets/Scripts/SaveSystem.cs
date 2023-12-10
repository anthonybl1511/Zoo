using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public AnimalsInfo animalsInfo;

    void Start()
    {
        instance = this;
        Invoke("Load", 0.02f);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            animalsInfo = JsonUtility.FromJson<AnimalsInfo>(json);
            int animalIndex = 0;
            Animal[] animalsObject = FindObjectsOfType(typeof(Animal)) as Animal[];
            foreach (AnimalStats i in animalsInfo.animals)
            {
                animalsObject[animalIndex].SetName(i.animalName);
                animalsObject[animalIndex].SetHunger(i.hunger);
                animalsObject[animalIndex].SetThirst(i.thirst);
                animalsObject[animalIndex].SetHappiness(i.happiness);
                animalsObject[animalIndex].SetTiredness(i.tiredness);
                animalsObject[animalIndex].transform.position = new Vector3(i.x, i.y, i.z);
                animalIndex++;
            }
        }
    }

    public void Save()
    {
        animalsInfo.animals.Clear();
        Animal[] animalsObject = FindObjectsOfType(typeof(Animal)) as Animal[];
        foreach (Animal animal in animalsObject)
        {
            Vector3 position = animal.transform.position;
            animalsInfo.animals.Add(new AnimalStats() { animalName = animal.GetName(), hunger = animal.GetHunger(), thirst = animal.GetThirst(), happiness = animal.GetHappiness(), tiredness = animal.GetTiredness(), x = position.x, y = position.y, z = position.z });
        } 

        string json = JsonUtility.ToJson(animalsInfo);
        Debug.Log("Saved at: " + Application.persistentDataPath + "/data.save");
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }
}
