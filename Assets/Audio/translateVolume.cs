﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateVolume : MonoBehaviour
{
    public AudioManager manager;

    public float shVolume;

    private void Update()
    {
        //print(shVolume);
        manager.masterVolume = shVolume;
    }

}
