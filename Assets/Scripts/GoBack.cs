using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public int time = 5;
    private GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton = HUD.Instance.gameObject.transform.Find("GoBack").gameObject;
        backButton.SetActive(true);
        backButton.GetComponent<Button>().onClick.AddListener(() => 
        {
            Timer.Instance.time += time;
            SceneManager.LoadScene("ChoosePlanet");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        backButton.SetActive(false);
    }
}
