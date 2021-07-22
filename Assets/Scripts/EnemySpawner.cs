using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numEnemies = 50;
    public int distance = 75;
    public int minLevel;
    public int maxLevel;
    public MainCharacter mainCharacter;
    public List<GameObject> enemies;
    public Dictionary<string, int> startingGain = new Dictionary<string, int>()
    {
        ["Rye Flour"] = 1,
        ["Regular Flour"] = 1,
        ["Salt"] = 2,
        ["Butter"] = 1
    };
    public Dictionary<string, string> units = new Dictionary<string, string>()
    {
        ["Rye Flour"] = "cup(s)",
        ["Regular Flour"] = "cup(s)",
        ["Salt"] = "tsp.",
        ["Butter"] = "stick(s)"
    };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= numEnemies; i++)
        {
            int num = Random.Range(0, enemies.Count);
            GameObject enemy = Object.Instantiate<GameObject>(enemies[num]);
            Vector2 pos = new Vector2(Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance), Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance));
            while (pos.x > mainCharacter.GetComponent<Rigidbody2D>().position.x - 15 && pos.x < mainCharacter.GetComponent<Rigidbody2D>().position.x + 15 && pos.y > mainCharacter.GetComponent<Rigidbody2D>().position.y - 15 && pos.y < mainCharacter.GetComponent<Rigidbody2D>().position.y + 15) 
            {
                pos = new Vector2(Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance), Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance));
            }
            enemy.GetComponent<Rigidbody2D>().MovePosition(pos);
            enemy.GetComponent<Enemy>().mainCharacter = mainCharacter;
            int level = Random.Range(minLevel, maxLevel + 1);
            enemy.GetComponent<Enemy>().level = level;
            enemy.GetComponent<Enemy>().health = level * 10 + 10;
            enemy.GetComponent<Enemy>().attack = level / 3 * 5;
            enemy.GetComponent<Enemy>().exp = level * 25;
            enemy.GetComponent<Enemy>().gain = level * startingGain[enemy.GetComponentInChildren<TextMesh>().text];
            enemy.GetComponent<Enemy>().unit = units[enemy.GetComponentInChildren<TextMesh>().text];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
