using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Node casaAtual, casaAnterior;
    public Destino destino;
    public ButtonsController buttonsController;
    public LevelController levelController;
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public Vector3 realRotation;
    public Vector3 startPositionTransladar;
    public Vector3 startRotation;
    public bool podeMover = false;
    public string movimento;
    public string sentidoRotacao;
    public float speed;
    public float speedRotation;
    public bool emMovimento = false;
    public bool faceParaCima;
    public bool colidiu = false;
    public SpriteRenderer sr;
    public GameObject trueParent;
    public GameObject fakeParent;
    public GameObject prefabPivot;

    void Start()
    {
        SpriteRenderer srDestino = destino.GetComponent<SpriteRenderer>();        
        sr = GetComponent<SpriteRenderer>();
        srDestino.sprite = sr.sprite;
        realRotation = transform.rotation.eulerAngles;
        faceParaCima = true;
        trueParent = transform.parent.gameObject;
        speed = 4;
        speedRotation = 4;
        casaAtual = levelController.nodes[levelController.GetRealCellIndex((int)transform.localPosition.x, (int)transform.localPosition.z)];
        casaAnterior = levelController.nodes[levelController.GetRealCellIndex((int)transform.localPosition.x, (int)transform.localPosition.z)];
        transform.localPosition = new Vector3((int)transform.localPosition.x, 0, (int)transform.localPosition.z);
        targetPosition = transform.localPosition;
    }
    
    void Update()
    {
        if (podeMover)
        {
            if (movimento == "transladar")
            {
                emMovimento = true;

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
                    casaAnterior = casaAtual;
                    casaAtual = levelController.nodes[levelController.GetRealCellIndex((int)targetPosition.x, (int)targetPosition.z)];
                    casaAtual.isPlaceable = false;

                    levelController.movimentosCount++;

                    podeMover = false;
                    emMovimento = false;
                }
            }
            else if (movimento == "rotacionar")
            {
                emMovimento = true;
                
                fakeParent.transform.rotation = Quaternion.Lerp(fakeParent.transform.rotation, Quaternion.Euler(targetRotation), speedRotation * Time.deltaTime);

                if (colidiu)
                {
                    targetPosition = casaAtual.transform.localPosition;
                    targetPosition.y = 0;

                    targetRotation = startRotation;
                }

                if (Quaternion.Angle(fakeParent.transform.rotation, Quaternion.Euler(targetRotation)) < 1F)
                {
                    fakeParent.transform.rotation = Quaternion.Euler(targetRotation);

                    GetComponent<Transform>().parent = trueParent.transform;
                    Destroy(fakeParent);
                                        
                    transform.localPosition = targetPosition;
                    realRotation = targetRotation;

                    casaAtual.isPlaceable = true;
                    casaAnterior = casaAtual;
                    casaAtual = levelController.nodes[levelController.GetRealCellIndex((int)targetPosition.x, (int)targetPosition.z)];
                    casaAtual.isPlaceable = false;

                    levelController.movimentosCount++;

                    emMovimento = false;
                    podeMover = false;
                }
            }
        }
    }

    public void SetarTranslado(Transform casaTransform)
    {
        startPositionTransladar = transform.localPosition;

        targetPosition = casaTransform.localPosition;
        targetPosition.y = 0;

        podeMover = true;
    }

    public void SetarPivot(Transform casaTransform)
    {
        startRotation = realRotation;

        var posX = (int)(casaTransform.localPosition.x + 0.01F);
        var posZ = (int)(casaTransform.localPosition.z + 0.01F);

        if (sentidoRotacao == "horario")
        {
            if((int)(transform.localPosition.x + 0.01F) == posX - 1)  //Peça está a esquerda do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.z += 1;
            }
            else if ((int)(transform.localPosition.x + 0.01F) == posX + 1)  //Peça está a direita do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.z -= 1;
            }
            else if ((int)(transform.localPosition.z + 0.01F) == posZ - 1)  //Peça está em baixo do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.x -= 1;
            }
            else if ((int)(transform.localPosition.z + 0.01F) == posZ + 1)  //Peça está em cima do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.x += 1;
            }
            else  //Peça e o pivot estão na mesma casa
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
            }
        }
        else if(sentidoRotacao == "antihorario")
        {
            if ((int)(transform.localPosition.x + 0.01F) == posX - 1)  //Peça está a esquerda do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.z -= 1;
            }
            else if ((int)(transform.localPosition.x + 0.01F) == posX + 1)  //Peça está a direita do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.z += 1;
            }
            else if ((int)(transform.localPosition.z + 0.01F) == posZ - 1)  //Peça está em baixo do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.x += 1;
            }
            else if ((int)(transform.localPosition.z + 0.01F) == posZ + 1)  //Peça está em cima do pivot
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
                targetPosition.x -= 1;
            }
            else  //Peça e o pivot estão na mesma casa
            {
                targetPosition.x = posX;
                targetPosition.z = posZ;
            }
        }

        targetPosition.y = 0;

        var pivotPosition = casaTransform.localPosition;
        pivotPosition.y = 0;

        fakeParent = Instantiate(prefabPivot, pivotPosition, Quaternion.Euler(realRotation));
        fakeParent.GetComponent<Transform>().parent = trueParent.transform;
        fakeParent.transform.localPosition = pivotPosition;
        GetComponent<Transform>().parent = fakeParent.transform;

        podeMover = true;
    }

    private void OnMouseDown()
    {
        if (buttonsController.selectedPiece == null)
        {
            buttonsController.EnableButtons(this);
        }
        else
        {
            buttonsController.UnableButtons();
        }
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
