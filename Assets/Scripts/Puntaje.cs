using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private int puntos;
    private TextMeshProUGUI textMesh;

   private void Start()
{
    textMesh = GetComponent<TextMeshProUGUI>();

    Debug.Log(textMesh);
}
public void SumarPuntos(int puntosEntrada)
{
    puntos += puntosEntrada;

    Debug.Log("Puntos: " + puntos);

    textMesh.text = puntos.ToString();
}
}