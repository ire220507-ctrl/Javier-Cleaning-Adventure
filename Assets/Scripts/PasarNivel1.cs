using UnityEngine;

public class PasarNivel1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-16.6f, -32.6f, 0f);
        }
    }
}