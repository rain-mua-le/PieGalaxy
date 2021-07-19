using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject mc;
    public Button yes;
    public Button no;
    public Button cont;

    // Start is called before the first frame update
    void Start()
    {
        yes.onClick.AddListener(() => {
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MainCharacter")
        {
            MainCharacter main = mc.GetComponent<MainCharacter>();
            main.freeze = true;
            canvas.SetActive(true);
        }
    }
}
