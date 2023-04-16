using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public List<Button> buttonsPrincipais;
    public List<Button> buttonsSecundarios;
    public Piece selectedPiece;
    public LevelController levelController;
    public List<Node> casasVizinhas;
    public int posX, posZ, limiteDireito, limiteSuperior;
    public bool colorido;

    private void Start()
    {
        foreach (Button button in buttonsPrincipais)
        {
            button.gameObject.GetComponentInChildren<Text>().color = new Color(255, 255, 255, 255);
        }

        foreach (Button button in buttonsSecundarios)
        {
            button.gameObject.GetComponentInChildren<Text>().color = new Color(255, 255, 255, 255);
        }

        limiteDireito = levelController.width - 1;
        limiteSuperior = levelController.height - 1;
    }

    public void EnableButtons(Piece piece)
    {
        selectedPiece = piece;

        posX = (int)(selectedPiece.transform.localPosition.x + 0.01F);
        posZ = (int)(selectedPiece.transform.localPosition.z + 0.01F);

        foreach (Button button in buttonsPrincipais)
        {
            button.gameObject.SetActive(true);
        }

        foreach (Button button in buttonsSecundarios)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void UnableButtons()
    {
        foreach (Button button in buttonsPrincipais)
        {
            button.gameObject.SetActive(false);
        }

        foreach (Button button in buttonsSecundarios)
        {
            button.gameObject.SetActive(false);
        }

        selectedPiece = null;
    }

    public void Transladar()
    {
        foreach (Button button in buttonsPrincipais)
        {
            if(button.gameObject.name != "Transladar")
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
        }

        if (colorido)
        {
            Descolorir();
            levelController.EnablePieces();
        }
        else
        {
            selectedPiece.movimento = "transladar";

            Colorir();

            levelController.EnableCells(casasVizinhas);
        }
    }

    public void Colorir()
    {
        CasasVizinhas();

        foreach (Node casa in casasVizinhas)
        {
            casa.GetComponent<MeshRenderer>().material = levelController.gridCellSelectable;
        }

        colorido = true;
    }

    public void Descolorir()
    {
        foreach (Node casa in casasVizinhas)
        {
            casa.GetComponent<MeshRenderer>().material = levelController.gridCell;
        }

        colorido = false;
    }

    public void Rotacionar()
    {
        foreach (Button button in buttonsPrincipais)
        {
            if (button.gameObject.name != "Rotacionar")
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
        }

        foreach (Button button in buttonsSecundarios)
        {
            if (button.gameObject.CompareTag("bttSecRot"))
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
        }

        if (colorido)
        {
            Descolorir();

            levelController.EnablePieces();
        }
    }

    public void CasasVizinhas()
    {
        casasVizinhas.Clear();

        if (selectedPiece.movimento == "transladar")
        {
            if (posX + 1 <= limiteDireito)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX + 1, posZ)]);
            }

            if (posX - 1 >= 0)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX - 1, posZ)]);
            }
            if (posZ + 1 <= limiteSuperior)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX, posZ + 1)]);
            }
            if (posZ - 1 >= 0)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX, posZ - 1)]);
            }
        }
        else if(selectedPiece.movimento == "rotacionar")
        {
            casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX, posZ)]);

            if (posX + 1 <= limiteDireito)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX + 1, posZ)]);
            }
            if (posX - 1 >= 0)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX - 1, posZ)]);
            }
            if (posZ + 1 <= limiteSuperior)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX, posZ + 1)]);
            }
            if (posZ - 1 >= 0)
            {
                casasVizinhas.Add(levelController.nodes[levelController.GetRealCellIndex(posX, posZ - 1)]);
            }
        }
    }

    public void Horario()
    {
        if (selectedPiece.emMovimento)
        {
            return;
        }

        selectedPiece.movimento = "rotacionar";
        selectedPiece.sentidoRotacao = "horario";

        if (selectedPiece.realRotation.y == 0)
        {
            selectedPiece.targetRotation.Set(90, 90, 0);
        }
        else if (selectedPiece.realRotation.y == 90)
        {
            selectedPiece.targetRotation.Set(90, 180, 0);
        }
        else if (selectedPiece.realRotation.y == 180)
        {
            selectedPiece.targetRotation.Set(90, 270, 0);
        }
        else if (selectedPiece.realRotation.y == 270)
        {
            selectedPiece.targetRotation.Set(90, 0, 0);
        }

        Colorir();

        levelController.EnableCells(casasVizinhas);
    }

    public void AntiHorario()
    {
        if (selectedPiece.emMovimento)
        {
            return;
        }

        selectedPiece.movimento = "rotacionar";
        selectedPiece.sentidoRotacao = "antihorario";

        if (selectedPiece.realRotation.y == 0)
        {
            selectedPiece.targetRotation.Set(90, 270, 0);
        }
        else if (selectedPiece.realRotation.y == 90)
        {
            selectedPiece.targetRotation.Set(90, 0, 0);
        }
        else if (selectedPiece.realRotation.y == 180)
        {
            selectedPiece.targetRotation.Set(90, 90, 0);
        }
        else if (selectedPiece.realRotation.y == 270)
        {
            selectedPiece.targetRotation.Set(90, 180, 0);
        }

        Colorir();

        levelController.EnableCells(casasVizinhas);
    }

    public void Refletir()
    {
        foreach (Button button in buttonsPrincipais)
        {
            if (button.gameObject.name != "Refletir")
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
        }

        foreach (Button button in buttonsSecundarios)
        {
            if (button.gameObject.CompareTag("bttSecRef"))
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
        }
    }

    public void EixoX()
    {
        selectedPiece.faceParaCima = !selectedPiece.faceParaCima;

        SpriteRenderer sr = selectedPiece.GetComponent<SpriteRenderer>();

        if (selectedPiece.realRotation.y == 0)
        {
            sr.flipY = !sr.flipY;
        }
        else if (selectedPiece.realRotation.y == 90)
        {
            sr.flipX = !sr.flipX;

            selectedPiece.realRotation.Set(90, 270, 0);
        }
        else if (selectedPiece.realRotation.y == 180)
        {
            sr.flipY = !sr.flipY;
        }
        else if (selectedPiece.realRotation.y == 270)
        {
            sr.flipX = !sr.flipX;

            selectedPiece.realRotation.Set(90, 90, 0);
        }

        if (selectedPiece.faceParaCima) {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.blue;
        }

        levelController.movimentosCount++;

        selectedPiece.buttonsController.UnableButtons();
    }

    public void EixoY()
    {
        selectedPiece.faceParaCima = !selectedPiece.faceParaCima;

        SpriteRenderer sr = selectedPiece.GetComponent<SpriteRenderer>();

        if (selectedPiece.realRotation.y == 0)
        {
            sr.flipX = !sr.flipX;

            selectedPiece.realRotation.Set(90, 180, 0);
        }
        else if (selectedPiece.realRotation.y == 90)
        {
            sr.flipY = !sr.flipY;
        }
        else if (selectedPiece.realRotation.y == 180)
        {
            sr.flipX = !sr.flipX;

            selectedPiece.realRotation.Set(90, 0, 0);
        }
        else if (selectedPiece.realRotation.y == 270)
        {
            sr.flipY = !sr.flipY;
        }

        if (selectedPiece.faceParaCima)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.blue;
        }

        levelController.movimentosCount++;

        selectedPiece.buttonsController.UnableButtons();
    }
}
