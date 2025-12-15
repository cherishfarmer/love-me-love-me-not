using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseHover : MonoBehaviour
{
    bool mouse = false;
    private float max = 200;
    private float min = 150;
    private float incr = 150f;

    private void Start()
    {
        {
            transform.localScale = new Vector3(150, 150, 1);
        }
    }

    private void Update()
    {
        if (mouse)
        {
            ScaleUp();
        }
        else
        {
            ScaleDown();
        }
    }
    void OnMouseOver()
    {
        mouse = true;
    }

    void OnMouseExit()
    {
        mouse = false;
    }

    void ScaleUp()
    {
        if (transform.localScale.x < max)
        {
           transform.localScale += new Vector3(incr * Time.deltaTime, incr * Time.deltaTime, 0);
        }
    }

    void ScaleDown()
    {
        if (transform.localScale.x > min)
        {
            transform.localScale += new Vector3(-incr * Time.deltaTime, -incr * Time.deltaTime, 0);
        }
    }
}

