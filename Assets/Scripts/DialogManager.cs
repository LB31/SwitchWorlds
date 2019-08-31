using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject[] AllDialoges;
    public string[] AllTexts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        StartCoroutine(AssignDialoges());
    }

    private IEnumerator AssignDialoges() {
        WaitForSeconds wait = new WaitForSeconds(4f);
        int i = 0;
        foreach (GameObject dialog in AllDialoges) {
            dialog.GetComponentInChildren<TextMeshProUGUI>().text = AllTexts[i];
            i++;
            yield return wait;
        }
    }
    
}
