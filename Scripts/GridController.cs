using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Node gridCellBranca;
    public Node gridCellPreta;
    public Node gridCellSelectable;
    Node obj;
    public int height;
    public int width;
    public Node[,] nodes;
    public LayerMask gridLayer;

    // Update is called once per frame
    void Update()
    {
       /* Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(screenRay, out hit, Mathf.Infinity, gridLayer))
            {
                foreach (var node in nodes)
                {
                    if(node.obj.transform.position == hit.transform.position)
                    {
                        Debug.Log(node.isPlaceable);
                    }
                }
            }
        }*/
    }

    public void SelectableCells(List<Node> casasVizinhas)
    {
        foreach(Node casa in casasVizinhas)
        {         
            casa.GetComponent<Renderer>().materials[0] = this.GetComponent<Renderer>().materials[1];
        }
    }
}
