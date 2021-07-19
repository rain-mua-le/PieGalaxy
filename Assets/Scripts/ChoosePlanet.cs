using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosePlanet : MonoBehaviour
{
    public List<Button> buttons; 
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button b in buttons) {
            string txt = b.GetComponentInChildren<Text>().text;
            string sceneName = txt.Substring(0, txt.IndexOf('-'));
            b.onClick.AddListener(() => ChangeScene(sceneName));
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}
