using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Wseed : ScriptableObject
{
    public Sprite seedSprite;
    public string seedName;
    public int id_Wseed;
    public int dropChance;

    public Wseed(string seedName,int dropChance,int id_Wseed)
    {
        this.seedName = seedName;
        this.dropChance = dropChance;
        this.id_Wseed = id_Wseed;
    }
}
