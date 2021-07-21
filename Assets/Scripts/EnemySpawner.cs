using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numEnemies = 50;
    public int distance = 75;
    public MainCharacter mainCharacter;
    public List<Sprite> sprites;
    public List<string> names;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= numEnemies; i++)
        {
            int num = Random.Range(0, sprites.Count);
            GameObject enemy = new GameObject("Enemy" + i);
            Vector2 pos = new Vector2(Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance), Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance));
            while (pos.x > mainCharacter.GetComponent<Rigidbody2D>().position.x - 15 && pos.x < mainCharacter.GetComponent<Rigidbody2D>().position.x + 15 && pos.y > mainCharacter.GetComponent<Rigidbody2D>().position.y - 15 && pos.y < mainCharacter.GetComponent<Rigidbody2D>().position.y + 15) 
            {
                pos = new Vector2(Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance), Random.Range(mainCharacter.GetComponent<Rigidbody2D>().position.x - distance, mainCharacter.GetComponent<Rigidbody2D>().position.x + distance));
            }
            enemy.AddComponent<Rigidbody2D>().MovePosition(pos);
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            enemy.AddComponent<Enemy>().mainCharacter = mainCharacter;
            enemy.AddComponent<SpriteRenderer>().sprite = sprites[num];
            enemy.tag = "Enemy";
            GameObject text = new GameObject("TextMesh");
            text.AddComponent<TextMesh>().text = names[num];
            text.transform.parent = enemy.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
