using System;
using System.Collections.Generic;

[Serializable]
public class AnimalsInfo
{
     public List<AnimalStats> animals = new List<AnimalStats>();
}

[Serializable]
public struct AnimalStats
{
    public string animalName;
    public float hunger;
    public float thirst;
    public float happiness;
    public float tiredness;
    public float x, y, z;
}