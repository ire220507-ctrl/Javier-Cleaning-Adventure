using UnityEngine;

public class PasarNivel1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(0f, -32.97f, 0f);
            Debug.Log(collision.transform.position);
        }
    }
}