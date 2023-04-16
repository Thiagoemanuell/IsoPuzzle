using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public Vector3 realRotation;
    public Vector3 targetRotation;
    public Vector3 startPosition;
    public bool faceParaCima;
    public bool podeMover;
    public int speedRotation;
    public GameObject trueParent;
    public GameObject fakeParent;
    public GameObject prefabPivot;

    // Start is called before the first frame update
    void Start()
    {
        realRotation = transform.rotation.eulerAngles;
        podeMover = false;
        faceParaCima = true;
        trueParent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (podeMover)
        {
            fakeParent.transform.rotation = Quaternion.Lerp(fakeParent.transform.rotation, Quaternion.Euler(targetRotation), speedRotation * Time.deltaTime);

            if (Quaternion.Angle(fakeParent.transform.rotation, Quaternion.Euler(targetRotation)) < 1f)
            {
                fakeParent.transform.rotation = Quaternion.Euler(targetRotation);

                GetComponent<Transform>().parent = trueParent.transform;
                Destroy(fakeParent);

                realRotation = targetRotation;

                podeMover = false;
            }
        }
    }

    public void Horario()
    {
        startPosition = transform.localPosition;

        fakeParent = Instantiate(prefabPivot, transform.localPosition, Quaternion.Euler(realRotation));
        fakeParent.GetComponent<Transform>().parent = trueParent.transform;
        fakeParent.transform.localPosition = startPosition;
        GetComponent<Transform>().parent = fakeParent.transform;

        if (realRotation.y == 0)
        {
            targetRotation.Set(90, 90, 0);
        }
        else if (realRotation.y == 90)
        {
            targetRotation.Set(90, 180, 0);
        }
        else if (realRotation.y == 180)
        {
            targetRotation.Set(90, 270, 0);
        }
        else if (realRotation.y == 270)
        {
            targetRotation.Set(90, 0, 0);
        }

        podeMover = true;
    }

    public void AntiHorario()
    {
        startPosition = transform.localPosition;

        fakeParent = Instantiate(prefabPivot, transform.localPosition, Quaternion.Euler(realRotation));
        fakeParent.GetComponent<Transform>().parent = trueParent.transform;
        fakeParent.transform.localPosition = startPosition;
        GetComponent<Transform>().parent = fakeParent.transform;

        if (realRotation.y == 0)
        {
            targetRotation.Set(90, 270, 0);
        }
        else if (realRotation.y == 90)
        {
            targetRotation.Set(90, 0, 0);
        }
        else if (realRotation.y == 180)
        {
            targetRotation.Set(90, 90, 0);
        }
        else if (realRotation.y == 270)
        {
            targetRotation.Set(90, 180, 0);
        }

        podeMover = true;
    }

    public void EixoX()
    {
        faceParaCima = !faceParaCima;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (faceParaCima)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.blue;
        }

        if (realRotation.y == 0)
        {
            sr.flipY = !sr.flipY;
        }
        else if (realRotation.y == 90)
        {
            sr.flipX = !sr.flipX;

            realRotation.Set(90, 270, 0);
        }
        else if (realRotation.y == 180)
        {
            sr.flipY = !sr.flipY;            
        }
        else if (realRotation.y == 270)
        {
            sr.flipX = !sr.flipX;

            realRotation.Set(90, 90, 0);
        }
    }

    public void EixoY()
    {
        faceParaCima = !faceParaCima;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (faceParaCima)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.blue;
        }

        if (realRotation.y == 0)
        {
            sr.flipX = !sr.flipX;

            realRotation.Set(90, 180, 0);
        }
        else if (realRotation.y == 90)
        {
            sr.flipY = !sr.flipY;
        }
        else if (realRotation.y == 180)
        {
            sr.flipX = !sr.flipX;

            realRotation.Set(90, 0, 0);
        }
        else if (realRotation.y == 270)
        {
            sr.flipY = !sr.flipY;
        }
    }
}
