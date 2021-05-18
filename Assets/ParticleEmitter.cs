using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Random.insideUnitSphere * 10f;
        ParticleSystem.Emit(new ParticleSystem.EmitParams { position = pos }, 1);
    }
}
