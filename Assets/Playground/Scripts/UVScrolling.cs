using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class UVScrolling : MonoBehaviour
{
    public Renderer m_renderer;
    public float m_multiplier = .01f;
    public int m_knob = 5;

    float m_speed = 0.1f;
    Material m_material;
    float m_yPosition = 0f;

    void Knob(MidiChannel channel, int knobNumber, float knobValue)
    {
        //Debug.Log("Knob: " + knobNumber + "," + knobValue);
        if (knobNumber == m_knob)
            m_speed = knobValue * m_multiplier;
    }

    void OnEnable()
    {
        MidiMaster.knobDelegate += Knob;
    }

    void OnDisable()
    {
        MidiMaster.knobDelegate -= Knob;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_material = m_renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        m_yPosition += m_speed;

        if (m_yPosition >= 10f)
            m_yPosition = 0f;

        if (m_material != null)
        {
            m_material.mainTextureOffset = new Vector2(1f, m_yPosition);
        }

    }
}
