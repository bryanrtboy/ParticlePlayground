using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class BackgroundColoring : MonoBehaviour
{
    public Camera m_cam;
    public Texture2D m_texture;
    public float m_multiplier = .01f;
    public int m_knob = 5;

    float m_speed = 0.1f;
    float m_xPosition = 0;

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

    // Update is called once per frame
    void Update()
    {
        m_xPosition += m_speed;

        int x = Mathf.RoundToInt(m_xPosition);

        if (x >= m_texture.width)
        {
            x = 0;
            m_xPosition = 0f;
        }

        Color c = m_texture.GetPixel(x, 2);
        m_cam.backgroundColor = Color.Lerp(m_cam.backgroundColor, c, Time.deltaTime);
    }
}
