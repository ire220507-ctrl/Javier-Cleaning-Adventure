using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI contadorTexto;

    private int contador = 0;

    void Start()
    {
        ActualizarTexto();
    }

    public void SumarPunto()
    {
        contador++;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        contadorTexto.text = "Monedas: " + contador;
    }
}
