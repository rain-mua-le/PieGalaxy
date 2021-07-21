using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public MainCharacter mainCharacter;
    public int level;
    public int health;
    public int attack;
    public int exp;
    public bool state = false; //0- In area, 1- In fight
    private float time = 0.0f;
    private Rigidbody2D rgbd;
    private float rand1;
    private float rand2;
    private float rand3;
    private float rand4;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = this.gameObject.GetComponent<Rigidbody2D>();
        rand1 = Random.Range(-10f, 10f);
        rand2 = Random.Range(-2f, 2f);
        rand3 = Random.Range(-10f, 10f);
        rand4 = Random.Range(-2f, 2f);
        startPos = rgbd.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector2 pos = new Vector2(startPos.x + rand1 * Mathf.Sin(time * rand2), startPos.y + rand3 * Mathf.Sin(time * rand4));
        rgbd.MovePosition(pos);
        /*
        RaycastHit2D rch = Physics2D.Raycast(transform.position, mainCharacter.transform.position - transform.position, 10f);
        if (rch.collider != null && rch.collider.gameObject.tag == "Player")
        {
            Vector2 position = Vector2.Lerp(transform.position, mainCharacter.transform.position, 0.1f);
            rgbd.MovePosition(position);
            startPos = position;
        }
        */
    }
}
