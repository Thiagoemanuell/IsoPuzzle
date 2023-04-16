using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InstrucoesFive : MonoBehaviour
{
    public LevelController levelController;
    public int etapas, etapasCount;
    public float alphaControl;
    public string[] conteudos;
    public TextMeshProUGUI info, continuar;
    public AnimationScript bar1, bar2, bar3, bar4, continuarAnim;
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
                    bar1.isAnimated = true;
                    bar2.isAnimated = true;
                    bar3.isAnimated = true;
                    bar4.isAnimated = true;

                    break;
                case 3:
                    bar1.isAnimated = false;
                    bar2.isAnimated = false;
                    bar3.isAnimated = false;
                    bar4.isAnimated = false;

                    bar1.gameObject.transform.localScale = bar1.startScale;
                    bar2.gameObject.transform.localScale = bar1.startScale;
                    bar3.gameObject.transform.localScale = bar1.startScale;
                    bar4.gameObject.transform.localScale = bar1.startScale;

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
        bar1.isAnimated = false;
        bar2.isAnimated = false;
        bar3.isAnimated = false;
        bar4.isAnimated = false;

        bar1.gameObject.transform.localScale = bar1.startScale;
        bar2.gameObject.transform.localScale = bar1.startScale;
        bar3.gameObject.transform.localScale = bar1.startScale;
        bar4.gameObject.transform.localScale = bar1.startScale;

        foreach (Piece piece in levelController.piecesOnGrid)
        {
            piece.GetComponent<BoxCollider>().enabled = true;
        }

        this.gameObject.SetActive(false);
    }
}
