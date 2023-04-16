using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Instrucoes : MonoBehaviour
{
    public LevelController levelController;
    public int etapas, etapasCount;
    public float alphaControl;
    public string[] conteudos;
    public TextMeshProUGUI info, continuar;
    public AnimationScript peca1, peca2, dest1, dest2, continuarAnim;
    public bool continuarKey;

    void Start()
    {
        foreach (Piece piece in levelController.piecesOnGrid)
        {
            piece.GetComponent<BoxCollider>().enabled = false;
        }

        GetComponent<Button>().interactable = false;              

        info.text = conteudos[0];
        alphaControl = 0;
    }

    void Update()
    {
        if (continuarKey)
        {
            if (alphaControl < 3)
            {                
                alphaControl += 1 * Time.deltaTime;
            }
            else
            {
                continuar.color = new Color(255, 255, 255, 255);
                continuarAnim.isAnimated = true;
                GetComponent<Button>().interactable = true;
                continuarKey = false;
            }
        }
    }

    public void ProximaEtapa()
    {
        etapasCount++;

        if(etapasCount < etapas)
        {
            GetComponent<Button>().interactable = false;
            info.text = conteudos[etapasCount];
            continuar.color = new Color(255, 255, 255, 0);
            alphaControl = 0;
            continuarKey = true;

            switch (etapasCount)
            {
                
                case 2:
                    peca1.isAnimated = true;
                    peca2.isAnimated = true;

                    break;
                case 3:
                    peca1.isAnimated = false;
                    peca2.isAnimated = false;

                    foreach(Piece piece in levelController.piecesOnGrid)
                    {
                        piece.transform.localScale = peca1.startScale;
                    }

                    dest1.isAnimated = true;
                    dest2.isAnimated = true;

                    break;
                case 4:
                    dest1.isAnimated = false;
                    dest2.isAnimated = false;

                    foreach (Destino dest in levelController.destinos)
                    {
                        dest.transform.localScale = dest1.startScale;
                    }
                    break;
            }
        }
        else
        {
            Desativar();
        }
    }

    public void Desativar()
    {
        peca1.isAnimated = false;
        peca2.isAnimated = false;

        peca1.gameObject.transform.localScale = peca1.startScale;
        peca2.gameObject.transform.localScale = peca2.startScale;

        dest1.isAnimated = false;
        dest2.isAnimated = false;

        dest1.gameObject.transform.localScale = dest1.startScale;
        dest2.gameObject.transform.localScale = dest2.startScale;

        foreach (Piece piece in levelController.piecesOnGrid)
        {
            piece.GetComponent<BoxCollider>().enabled = true;
        }

        this.gameObject.SetActive(false);
    }
}
