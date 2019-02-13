using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPUThingGenerator : MonoBehaviour
{
    public int m_rate = 10;
    public int m_generatePerLoop = 1;
    public int m_maxCount = 1000;
    public GameObject m_thing;
    public Text m_ui;

    int m_count = 0;
    List<GameObject> m_objects;

    // Start is called before the first frame update
    void Start()
    {
        m_objects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        m_count++;

        if (m_count >= m_rate)
        {
            for (int i = 0; i < m_generatePerLoop; i++)
            {
                if (m_objects.Count < m_maxCount)
                    m_objects.Add(Instantiate(m_thing, Random.insideUnitSphere * 10, Quaternion.identity));
            }

            m_count = 0;
        }

        if (m_objects.Count >= m_maxCount)
        {
            GameObject g = m_objects[m_objects.Count - 1];
            m_objects.RemoveAt(m_objects.Count - 1);
            Destroy(g);
        }

        m_ui.text = "Number of objects is: " + m_objects.Count.ToString();
    }
}
