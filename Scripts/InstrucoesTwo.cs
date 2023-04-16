using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InstrucoesTwo : MonoBehaviour
{
    public LevelController levelController;
    public int etapas, etapasCount;
    public float alphaControl;
    public string[] conteudos;
    public TextMeshProUGUI info, continuar;
    public AnimationScript pedra, continuarAnim;
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

        if (etapasCount < etapas)
        {
            GetComponent<Button>().interactable = false;
            info.text = conteudos[etapasCount];
            continuar.color = new Color(255, 255, 255, 0);
            alphaControl = 0;
            continuarKey = true;

            switch (etapasCount)
            {

                case 2:
                    pedra.isAnimated = true;

                    break;
                case 3:
                    pedra.isAnimated = false;

                    pedra.gameObject.transform.localScale = pedra.startScale;

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
        pedra.isAnimated = false;

        pedra.gameObject.transform.localScale = pedra.startScale;

        foreach (Piece piece in levelController.piecesOnGrid)
        {
            piece.GetComponent<BoxCollider>().enabled = true;
        }

        this.gameObject.SetActive(false);
    }
}
