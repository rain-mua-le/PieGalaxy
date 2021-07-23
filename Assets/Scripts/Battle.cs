using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
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
        Stats.Instance.enemyHealth = Stats.Instance.enemyLevel * 10 + 10;
        Stats.Instance.enemyAttack = Stats.Instance.enemyHealth / 3 * 5;
        Stats.Instance.enemyExp = Stats.Instance.level * 25;
        Stats.Instance.gain = Stats.Instance.enemyLevel * startingGain[Stats.Instance.enemyName];
        Stats.Instance.unit = units[Stats.Instance.enemyName];
        HUD.Instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
