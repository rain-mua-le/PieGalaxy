using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public Text script;
    public Text health;
    public Text mana;
    public Text enemyHealth;
    public Canvas select;
    public Canvas skillsSelect;
    public Button attack;
    public Button defend;
    public Button skill;
    public Button run;
    private Dictionary<string, int> startingGain = new Dictionary<string, int>()
    {
        ["Rye Flour"] = 1,
        ["Regular Flour"] = 1,
        ["Salt"] = 2,
        ["Butter"] = 1
    };
    private Dictionary<string, string> units = new Dictionary<string, string>()
    {
        ["Rye Flour"] = "cup(s)",
        ["Regular Flour"] = "cup(s)",
        ["Salt"] = "tsp.",
        ["Butter"] = "stick(s)"
    };

    // Start is called before the first frame update
    void Start()
    {
        GameObject mc = new GameObject("MainCharacter");
        mc.transform.position = new Vector3(-3, 0, 0);
        mc.AddComponent<SpriteRenderer>().sprite = Stats.Instance.sprite;
        GameObject enemy = new GameObject("Enemy");
        enemy.transform.position = new Vector3(3, 0, 0);
        enemy.AddComponent<SpriteRenderer>().sprite = Stats.Instance.enemySprite;
        Stats.Instance.enemyHealth = Stats.Instance.enemyLevel * 10 + 20;
        Stats.Instance.enemyAttack = Stats.Instance.enemyHealth / 3 * 5;
        Stats.Instance.enemyExp = Stats.Instance.level * 25;
        Stats.Instance.gain = Stats.Instance.enemyLevel / 4 * startingGain[Stats.Instance.enemyName];
        Stats.Instance.unit = units[Stats.Instance.enemyName];
        HUD.Instance.gameObject.SetActive(false);
        skillsSelect.gameObject.SetActive(false);
        health.text = "Health: " + Stats.Instance.health;
        mana.text = "Mana: " + Stats.Instance.mana;
        enemyHealth.text = "Enemy's Health: " + Stats.Instance.enemyHealth;
        attack.onClick.AddListener(Attack);
        defend.onClick.AddListener(Defend);
        run.onClick.AddListener(Run);
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + Stats.Instance.health;
        mana.text = "Mana: " + Stats.Instance.mana;
        enemyHealth.text = "Enemy's Health: " + Stats.Instance.enemyHealth;
    }

    void Attack()
    {
        select.gameObject.SetActive(false);
        script.text = "You dealt " + Stats.Instance.attack + " on the enemy!";
        Stats.Instance.enemyHealth -= Stats.Instance.attack;
    }

    void Defend()
    {
        select.gameObject.SetActive(false);
        script.text = "You defend against the enemies attack!";
        Stats.Instance.health -= Stats.Instance.enemyAttack - Stats.Instance.defense;
    }

    void Skills()
    {

    }

    void Run()
    {
        Stats.Instance.money -= 10;
        SceneManager.LoadScene(Stats.Instance.lastSceneAt);
    }
}
