using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// control/create particle system for plant
public class StageEffect : MonoBehaviour
{
    [SerializeField]
    private float lifetime = .3f;
    private ParticleSystem effect;

    void Start()
    {
        effect = Resources.Load<ParticleSystem>("Prefabs/StarA");
        Invoke("Upgrade", lifetime);
    }

    public void Upgrade()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        effect.Play();
    }
}
