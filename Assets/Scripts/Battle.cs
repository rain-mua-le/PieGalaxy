using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = Object.Instantiate<GameObject>(Stats.Instance.enemyToFight);
        GameObject mc = new GameObject("MainCharacter");
        mc.AddComponent<SpriteRenderer>().sprite = Stats.Instance.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
