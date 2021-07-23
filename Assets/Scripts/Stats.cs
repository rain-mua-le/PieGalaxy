using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public readonly struct Skill
    {
        readonly string name;
        readonly string description;
        readonly int healthAddition;
        readonly int attackAddition;
        readonly int manaCost;
        public Skill(string n, string d, int h, int a, int m)
        {
            this.name = n;
            this.description = d;
            this.healthAddition = h;
            this.attackAddition = a;
            this.manaCost = m;
        }
    }
    public Sprite sprite;
    public int level = 1;
    public int exp = 0;
    public int health = 60;
    public int attack = 5;
    public int defense = 5;
    public int mana = 30;
    public int money = 100;
    public List<Skill> skills = new List<Skill>()
    {
        new Skill("Heal", "Regain 10 HP. Costs 10 mana.", 10, 0, 10),
        new Skill("Pie Smack", "Deals 10 damages to enemy. Costs 10 HP.", 10, 0, 10)
    };
    public Sprite enemySprite;
    public int enemyLevel;
    public string enemyName;
    public int enemyHealth;
    public int enemyAttack;
    public int enemyExp;
    public int gain;
    public string unit;

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
