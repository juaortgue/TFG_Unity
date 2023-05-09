using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadControllerScript : MonoBehaviour
{
    public Button buttom;
    

    // Update is called once per frame
    void Update()
    {
        DataGameControllerScript script = GetComponent<DataGameControllerScript>();
        buttom.interactable=script.isFileSaved();
        Debug.Log(script.isFileSaved());
    }
}
