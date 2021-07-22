using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int level = 1;
    public int exp = 0;
    public int health = 60;
    public int attack = 5;
    public int defense = 5;
    public int mana = 30;
    public int money = 100;
    public GameObject enemyToFight;

    private static Stats _instance;

    public static Stats Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }
}
