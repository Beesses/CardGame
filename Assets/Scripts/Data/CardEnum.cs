using System;
using UnityEngine;

[Serializable]
public struct CardEnum
{
    public int Health;
    public int Damage;
    public GameObject Prefab;
    public Sprite Sprite;
    public string Discription;
    public MainController MainController;
    public Transform SpawnPlace;
}
