using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsObstaculos : MonoBehaviour
{
    public int direction;
    public LevelController levelController;
    public Node casaAtual;
    public bool pressed = false;

    void Start()
    {
        casaAtual = levelController.nodes[levelController.GetRealCellIndex((int)transform.localPosition.x, (int)transform.localPosition.z)];
        casaAtual.haveButton = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pressed)
        {
            foreach (Piece piece in levelController.piecesOnGrid)
            {
                if (piece.casaAtual == casaAtual)
                {                    
                    pressed = true;

                    foreach (Obstaculo obs in levelController.obstaculos)
                    {
                        Invoke(nameof(Move), 0.5F);
                    }
                }
            }
        }
        else
        {
            if (casaAtual.isPlaceable)
            {
                pressed = false;

                foreach (Obstaculo obs in levelController.obstaculos)
                {
                    obs.Move(direction * -1);
                }
            }
        }
    }

    public void Move()
    {
        foreach (Obstaculo obs in levelController.obstaculos)
        {
            obs.Move(direction);
        }
    }
}
