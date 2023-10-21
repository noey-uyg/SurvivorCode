using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSet : MonoBehaviour
{
    Color speedButtoncolor;

    Image speedButton;

    private void Awake()
    {
        speedButton = GetComponent<Image>();

        speedButtoncolor = speedButton.color;
    }

    private void FixedUpdate()
    {
        X2Color();
    }

    void X2Color()
    {

        if (!GameManager.instance.isX2)
        {
            speedButtoncolor.a = 0.5f;
            speedButton.color = speedButtoncolor;
        }
        else
        {
            speedButtoncolor.a = 1f;
            speedButton.color = speedButtoncolor;
        }
    }
}
