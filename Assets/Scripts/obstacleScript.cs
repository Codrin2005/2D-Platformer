﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.GetComponent<GameManager>().pressed)
            transform.Rotate(0, 0, -500 * Time.deltaTime);
    }
}
