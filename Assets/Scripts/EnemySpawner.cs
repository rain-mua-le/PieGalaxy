using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numEnemies = 50;
    public int distance = 75;
    public MainCharacter mainCharacter;
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= numEnemies; i++)
        {
            int num = Random.Range(0, enemies.Count);
            GameObject enemy = enemies[num];
            Vector2 pos = new Vector2(Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance), Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance));
            while (pos.x > mainCharacter.GetComponent<Rigidbody2D>().position.x - 15 && pos.x < mainCharacter.GetComponent<Rigidbody2D>().position.x + 15 && pos.y > mainCharacter.GetComponent<Rigidbody2D>().position.y - 15 && pos.y < mainCharacter.GetComponent<Rigidbody2D>().position.y + 15) 
            {
                pos = new Vector2(Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance), Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance));
            }
            enemy.GetComponent<Rigidbody2D>().MovePosition(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
