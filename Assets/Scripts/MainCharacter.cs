using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public const float speed = 3.0f;
    public int level = 1;
    public int health = 60;
    public int attack = 5;
    public int defense = 5;
    public int mana = 30;
    public int money = 100;
    public float crit;
    public bool freeze = false;
    private Rigidbody2D rgb;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!freeze)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 pos = rgb.position;
            pos.x += speed * horizontal * Time.deltaTime;
            pos.y += speed * vertical * Time.deltaTime;
            rgb.MovePosition(pos);
        }
    }
}