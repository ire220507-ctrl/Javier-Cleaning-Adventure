using UnityEngine;

public class PasarNivel2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-16.08f, -70.89f, 0f);  }
    }
}