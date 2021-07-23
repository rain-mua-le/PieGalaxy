using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    public bool freeze = false;
    private Rigidbody2D rgb;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        Stats.Instance.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Stats.Instance.enemySprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
            Stats.Instance.enemyLevel = other.gameObject.GetComponent<Enemy>().level;
            Stats.Instance.enemyName = other.gameObject.GetComponentInChildren<TextMesh>().text;
            SceneManager.LoadScene("Battle");
        }
    }
}
