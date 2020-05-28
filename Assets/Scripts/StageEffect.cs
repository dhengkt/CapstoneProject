﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StageEffect : MonoBehaviour
{
    [SerializeField]
    private float lifetime;
    public ParticleSystem effect;

    void Start()
    {
        Invoke("Upgrade", lifetime);
    }

    public void Upgrade()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        effect.Play();
    }
}