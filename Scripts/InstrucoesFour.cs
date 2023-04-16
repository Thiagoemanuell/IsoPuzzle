using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InstrucoesFour : MonoBehaviour
{
    public LevelController levelController;
    public int etapas, etapasCount;
    public float alphaControl;
    public string[] conteudos;
    public TextMeshProUGUI info, continuar;
    public SpriteRenderer pedra;
    public AnimationScript button1, button2, continuarAnim;
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
                case 3:
                    pedra.enabled = false;
                    
                    button1.isAnimated = true;                    
                    button2.isAnimated = true;

                    break;
                case 5:
                    pedra.enabled = true;
                    
                    button1.isAnimated = false;
                    button2.isAnimated = false;

                    button1.gameObject.transform.localScale = button1.startScale;
                    button2.gameObject.transform.localScale = button1.startScale;

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
        pedra.enabled = true;

        button1.isAnimated = false;
        button2.isAnimated = false;

        button1.gameObject.transform.localScale = button1.startScale;
        button2.gameObject.transform.localScale = button1.startScale;

        foreach (Piece piece in levelController.piecesOnGrid)
        {
            piece.GetComponent<BoxCollider>().enabled = true;
        }

        this.gameObject.SetActive(false);
    }
}
