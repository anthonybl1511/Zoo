using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public AnimalsInfo animalsInfo;

    void Start()
    {
        instance = this;
        Load();
    }

    public void Load()
    {

    }

    public void Save()
    {
        Animal[] animals = FindObjectsOfType(typeof(Animal)) as Animal[];


        string json = JsonUtility.ToJson(animals);
        Debug.Log(json);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }
}
