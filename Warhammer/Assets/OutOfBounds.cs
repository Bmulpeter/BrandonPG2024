using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class OutOfBounds : MonoBehaviour
{
    TMP_Text warningText;
    // Start is called before the first frame update
    void Start()
    {
        warningText = GetComponent<TMP_Text>();
        warningText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void warning(string v)
    {
        warningText.text = v;
        warningText.enabled = true;
    }
}
