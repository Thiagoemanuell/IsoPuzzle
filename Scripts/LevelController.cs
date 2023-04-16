using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    public int lvIndex;
    public GameObject artefatoDesbloqueado;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public int height;
    public int width;
    public Material gridCell;
    public Material gridCellSelectable;
    public Piece[] piecesOnGrid;
    public Obstaculo[] obstaculos;
    public ButtonsObstaculos[] bttOstaculos;
    public Destino[] destinos;
    public Node[] nodes;
    public Barreira[] barreiras;
    public int count = 0;
    public GameObject gameOver;
    public GameObject optionsMenu;
    public ButtonsController bttController;
    public int movimentosCount = 0;
    public int movimentosMin;
    public TextMeshProUGUI movimentoTxt;
    public bool isCompleted = false;

    private void Awake()
    {
        piecesOnGrid = FindObjectsOfType<Piece>();
        obstaculos = FindObjectsOfType<Obstaculo>();
        destinos = FindObjectsOfType<Destino>();
        bttOstaculos = FindObjectsOfType<ButtonsObstaculos>();
        barreiras = FindObjectsOfType<Barreira>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movimentoTxt.text = "LV. " + lvIndex + "\n" + movimentosCount.ToString();

        if (!isCompleted)
        {
            foreach (var piece in piecesOnGrid)
            {
                if (piece.destino.transform.localPosition.x == piece.transform.localPosition.x && piece.destino.transform.localPosition.z == piece.transform.localPosition.z && piece.realRotation == piece.destino.realRotation && piece.faceParaCima == piece.destino.faceParaCima)
                {
                    count++;
                }
            }
            if (count == piecesOnGrid.Length)
            {      
                bttController.UnableButtons();

                foreach (var piece in piecesOnGrid)
                {
                    piece.gameObject.SetActive(false);
                }

                foreach (var destino in destinos)
                {
                    destino.gameObject.SetActive(false);
                }

                foreach (var obstaculo in obstaculos)
                {
                    obstaculo.gameObject.SetActive(false);
                }

                foreach (var node in nodes)
                {
                    node.gameObject.SetActive(false);
                }

                foreach (var btt in bttOstaculos)
                {
                    btt.gameObject.SetActive(false);
                }

                foreach (var barreira in barreiras)
                {
                    barreira.gameObject.SetActive(false);
                }

                gameOver.SetActive(true);

                if(movimentosCount <= movimentosMin)
                {
                    star2.SetActive(true);
                    star3.SetActive(true);
                    star1.SetActive(true);

                    if (3 > PlayerPrefs.GetInt("Lv" + lvIndex))
                    {
                        PlayerPrefs.SetInt("Lv" + lvIndex, 3);

                        if (PlayerPrefs.GetInt("ArtLv" + lvIndex) < 1)
                        {
                            PlayerPrefs.SetInt("ArtLv" + lvIndex, 1);
                            artefatoDesbloqueado.SetActive(true);
                        }

                    }
                }
                else if(movimentosCount <= movimentosMin + 5)
                {
                    star2.SetActive(true);
                    star3.SetActive(true);

                    if (2 > PlayerPrefs.GetInt("Lv" + lvIndex))
                    {
                        PlayerPrefs.SetInt("Lv" + lvIndex, 2);
                    }
                }
                else
                {
                    star1.SetActive(true);

                    if (1 > PlayerPrefs.GetInt("Lv" + lvIndex))
                    {
                        PlayerPrefs.SetInt("Lv" + lvIndex, 1);
                    }
                }

                if(PlayerPrefs.GetInt("LastLv") < lvIndex)
                {
                    PlayerPrefs.SetInt("LastLv", lvIndex);
                }

                isCompleted = true;
            }
            else
            {
                count = 0;
            }
        }
    }

    public int GetRealCellIndex(int x, int z)
    {
        foreach(Node node in nodes)
        {
            if(node.transform.localPosition.x == x && node.transform.localPosition.z == z)
            {
                return (this.width * z) + x;
            }
        } 
        return -1;
    }

    public void EnablePieces()
    { 
        foreach (Piece piece in piecesOnGrid)
        {
            piece.GetComponent<BoxCollider>().enabled = true;
        }
        foreach (Node cell in nodes)
        {
            cell.GetComponent<BoxCollider>().enabled = false;
        }
        foreach (Obstaculo obs in obstaculos)
        {
            obs.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void EnableCells(List<Node> enableCells)
    {
        foreach (Piece piece in piecesOnGrid)
        {
            piece.GetComponent<BoxCollider>().enabled = false;
        }
        foreach (Node cell in enableCells)
        {
            cell.GetComponent<BoxCollider>().enabled = true;
        }
        foreach(Obstaculo obs in obstaculos)
        {
            obs.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ProximaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FaseAnterior()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Options()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
}
