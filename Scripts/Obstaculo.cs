using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public LevelController levelController;
    public Node casaAtual;
    public bool podeMover = false;
    public bool colidiu = false;
    public float speed;
    public Vector3 targetPosition;

    void Start()
    {
        speed = 4;
        casaAtual = levelController.nodes[levelController.GetRealCellIndex((int)transform.localPosition.x, (int)transform.localPosition.z)];
        transform.localPosition = new Vector3((int)transform.localPosition.x, 0.01F, (int)transform.localPosition.z);
        targetPosition = transform.localPosition;
    }
    void Update()
    {
        if (podeMover)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);

            if (colidiu)
            {
                targetPosition = casaAtual.transform.localPosition;
                targetPosition.y = 0;
            }

            if (Vector3.Distance(transform.localPosition, targetPosition) < 0.1F)
            {
                transform.localPosition = targetPosition;

                casaAtual.isPlaceable = true;
                casaAtual = levelController.nodes[levelController.GetRealCellIndex((int)targetPosition.x, (int)targetPosition.z)];
                casaAtual.isPlaceable = false;

                podeMover = false;
            }
        }
    }

    public void Move(int direction)
    {
        if (direction == 1)              //Move pra cima
        {
            targetPosition = casaAtual.transform.localPosition;
            targetPosition.z += 1;

        }
        else if (direction == -1)      //Move pra baixo
        {
            targetPosition = casaAtual.transform.localPosition;
            targetPosition.z -= 1;

        }
        else if (direction == 2)        //Move pra direita
        {
            targetPosition = casaAtual.transform.localPosition;
            targetPosition.x += 1;
        }
        else if (direction == -2)       //Move pra esquerda
        {
            targetPosition = casaAtual.transform.localPosition;
            targetPosition.x -= 1;
        }

        targetPosition.y = 0.01F;

        podeMover = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        colidiu = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        colidiu = false;
    }
}
