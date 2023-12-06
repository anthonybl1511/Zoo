using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    void Start()
    {
        Animal[] animals = FindObjectsOfType(typeof(Animal)) as Animal[];
        foreach (Animal animal in animals)
        {
            Debug.Log(animal.gameObject.GetComponent<Animal>().GetHunger());
        }


        instance = this;
        Load();
    }

    public void Load()
    {

    }

    //public void Save()
    //{
    //    Debug.Log(Application.persistentDataPath + "/data.save");
    //    string json = JsonUtility.ToJson(player);
    //    if (!File.Exists(Application.persistentDataPath + "/data.save"))
    //    {
    //        File.Create(Application.persistentDataPath + "/data.save").Dispose();
    //    }
    //    File.WriteAllText(Application.persistentDataPath + "/data.save", json);

    //}
}
