using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    // 0 = german; 1 = english; 2 = oshiwambo
    public string BubbleMessage;
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = BubbleMessage;
    }

    public void SayStuff() {
        
    }

    private void Update() {
        transform.LookAt(Camera.main.transform);
    }

}
