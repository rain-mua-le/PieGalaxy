using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Down : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool over;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData data)
    {
        over = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        over = false;
    }
}
