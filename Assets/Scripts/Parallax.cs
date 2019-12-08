using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material material;
    private Renderer render;
    public float speed;

    private float offSet;

    public int orderRender;

    void Start()
    {
        render = GetComponent<Renderer>();
        render.sortingOrder = orderRender;
        material = render.material;

    }

    // Update is called once per frame
    void Update()
    {
        offSet += speed * Time.deltaTime;

        material.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }
}
