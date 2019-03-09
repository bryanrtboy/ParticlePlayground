using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DelayTextureChanger : MonoBehaviour
{
    public Texture m_newTexture;
    public float m_delay;

    Renderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = this.GetComponent<Renderer>();
        Invoke("Swap", m_delay);
    }

    void Swap()
    {
        Destroy(this.gameObject);
    }
}
