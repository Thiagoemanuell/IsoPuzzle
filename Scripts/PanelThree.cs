using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelThree : MonoBehaviour
{
    public InstrucoesThree instrucoes;

    public void Continuar()
    {
        instrucoes.continuarKey = true;
    }
}
