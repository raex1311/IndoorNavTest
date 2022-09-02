using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    [SerializeField] Material arrowMat;
    [SerializeField] float speed = .1f;
    int increment = 0;
    private void Update()
    {
        if(increment < -5000)
        {
            increment = 0;
        }
        arrowMat.SetTextureOffset("_MainTex", new Vector2(increment * speed, 0));
        increment--;
    }
}
