using UnityEngine;

public class PasarNivel2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-13.86f, -70.83f, 0f);  }
    }
}