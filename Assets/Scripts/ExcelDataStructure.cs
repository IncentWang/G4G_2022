using System;


[Serializable]
public struct AlcoholItem
{
    public int id;
    public string name;
    public int sweet;
    public int intensity;
    public int mellow;
}

[Serializable]
public struct Need
{
    public int id;
    public int needSweet;
    public int needIntensity;
    public int needMellow;
    public int weight;
}