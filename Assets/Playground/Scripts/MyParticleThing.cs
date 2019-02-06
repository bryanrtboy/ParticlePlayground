using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MyParticleThing : MonoBehaviour
{
    public int m_knobNumber = 9;
    public ParticleSystem m_particleSystem;
    public ParticleSystem m_otherParticleSystem;

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


        if (m_otherParticleSystem != null && s > 0f)
        {
            var main = m_otherParticleSystem.main;

            main.startSize = Mathf.Abs(Input.GetAxis("Horizontal")) * 10f;

        }


    }
}
