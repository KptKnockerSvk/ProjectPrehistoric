using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int totalWood = 0;
    public Text woodNumber;

    // Update is called once per frame
    void Update()
    {
        woodNumber.text = "Wood: " + totalWood;

    }
}
