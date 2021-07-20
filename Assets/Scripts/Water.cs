using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Water : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject mc;
    public Button yes;
    public Button no;
    public Button cont;
    public int cups = 1;

    // Start is called before the first frame update
    void Start()
    {
        yes.onClick.AddListener(() => 
        {
            canvas.SetActive(false);
            canvas2.SetActive(true);
        });
        no.onClick.AddListener(() => 
        {
            canvas.SetActive(false);
            MainCharacter main = mc.GetComponent<MainCharacter>();
            main.freeze = false;
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

    void OnMouseDown()
    {
        if (cont.gameObject.GetComponent<Down>().down)
        {
            cont.onClick.AddListener(CollectWater);
        }
    }

    void CollectWater()
    {
        canvas2.SetActive(false);
        if (!Inventory.Instance.inventory.ContainsKey("Water"))
        {
            Inventory.Instance.inventory.Add("Water", cups);
        }
        else
        {
            Inventory.Instance.inventory["Water"] += cups;
        }
        Timer.Instance.time += 5;
        MainCharacter main = mc.GetComponent<MainCharacter>();
        main.freeze = false;
    }
}
