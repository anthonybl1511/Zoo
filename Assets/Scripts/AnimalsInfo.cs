using System;
using System.Collections.Generic;

[Serializable]
public class AnimalsInfo
{
    public List<AnimalStats> animalsInfo = new List<AnimalStats>();
}

[Serializable]
public struct AnimalStats
{
    public float hunger;
    public float thirst;
    public float happiness;
    public float tiredness;
}