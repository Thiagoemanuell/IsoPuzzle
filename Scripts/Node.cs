using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool isPlaceable, haveButton = false;
    public ButtonsController buttonsController;

    private void OnMouseDown()
    {
        buttonsController.levelController.EnablePieces();

        if (buttonsController.selectedPiece.movimento == "transladar")
        {
            buttonsController.selectedPiece.SetarTranslado(transform);
        }
        else if(buttonsController.selectedPiece.movimento == "rotacionar")
        {
            buttonsController.selectedPiece.SetarPivot(transform);
        }
        
        buttonsController.Descolorir();
        buttonsController.UnableButtons();
    }
}
