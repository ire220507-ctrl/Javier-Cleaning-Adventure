using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void Jugar()
    {
        // Cuando presionemos el botón, cargará la siguiente escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        // Mensaje en la consola de Unity
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}