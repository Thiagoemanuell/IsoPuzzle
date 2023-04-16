using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destino : MonoBehaviour
{
    public Vector3 realRotation;
    public SpriteRenderer sr;
    public bool faceParaCima;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        realRotation = transform.rotation.eulerAngles;
        faceParaCima = true;

        if (realRotation.y == 0)
        {
            if (!sr.flipX && sr.flipY)
            {  
                faceParaCima = false;
            }

            if (sr.flipX && !sr.flipY)
            {
                realRotation.Set(90, 180, 0);
                faceParaCima = false;
            }

            if (sr.flipX && sr.flipY)
            {
                realRotation.Set(90, 180, 0);
            }
        }
        else if (realRotation.y == 90)
        {
            if (!sr.flipX && sr.flipY)
            {
                faceParaCima = false;
            }

            if (sr.flipX && !sr.flipY)
            {
                faceParaCima = false;
                realRotation.Set(90, 270, 0);
            }

            if (sr.flipX && sr.flipY)
            {
                realRotation.Set(90, 270, 0);
            }
        }
        else if (realRotation.y == 180)
        {
            if (!sr.flipX && sr.flipY)
            {
                faceParaCima = false;
            }

            if (sr.flipX && !sr.flipY)
            {
                realRotation.Set(90, 0, 0);
                faceParaCima = false;
            }

            if (sr.flipX && sr.flipY)
            {
                realRotation.Set(90, 0, 0);
            }
        }
        else if (realRotation.y == 270)
        {
            if (!sr.flipX && sr.flipY)
            {
                faceParaCima = false;
            }

            if (sr.flipX && !sr.flipY)
            {
                faceParaCima = false;
                realRotation.Set(90, 90, 0);
            }

            if (sr.flipX && sr.flipY)
            {
                realRotation.Set(90, 90, 0);
            }
        }

        if (faceParaCima)
        {
            sr.color = Color.green;         
        }
        else
        {
            sr.color = Color.blue;
        }
    }
}
