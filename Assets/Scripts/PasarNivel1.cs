using UnityEngine;

public class PasarNivel1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-16.34546f, -70.7543f, 0f);
        }
    }
}