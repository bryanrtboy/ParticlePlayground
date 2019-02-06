using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MyParticleThing : MonoBehaviour
{
    public int m_knobNumber = 9;
    public ParticleSystem m_particleSystem;

    void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        float s = MidiMaster.GetKnob(m_knobNumber);
        Debug.Log("Value of knob " + m_knobNumber + " is " + s.ToString("#.####"));

        if (m_particleSystem != null && s > 0f)
        {
            var main = m_particleSystem.main;

            main.startSize = s * 10f;

        }
    }
}
