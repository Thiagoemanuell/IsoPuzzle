using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTwo : MonoBehaviour
{
    public InstrucoesTwo instrucoes;

    public void Continuar()
    {
        instrucoes.continuarKey = true;
    }
}
