using UnityEngine;

public class PasarNivel2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-16.41f, -70.97f, 0f);  }
    }
}