using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private Vector3 posIn = new Vector3(3, 4, 1);
    private float scale = 1.3f;
    private Color green = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    private float rotX;
    
    
    void Start()
    {
        
        parametrosInicializacao(green, scale, posIn);
    }
    
    void Update()
    {
        rotX = 10f * Time.deltaTime;
        transform.Rotate(rotX, 0.0f, 0.0f);
    }

    private void parametrosInicializacao(Color c, float scl, Vector3 pos)
    {
        transform.position = pos;
        transform.localScale = Vector3.one * scl;

        Material material = Renderer.material;

        material.color = c;
    }

}
