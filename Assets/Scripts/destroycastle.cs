﻿using UnityEngine;
using System.Collections;

public class destroycastle : MonoBehaviour
{

    public GameObject destr;

    // Update is called once per frame
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
            Destroy(destr);
    }
}
