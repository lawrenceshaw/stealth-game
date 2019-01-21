using UnityEngine;

public class Sound : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        var enemy = collision.gameObject.GetComponent<StateController>();

        if (enemy != null)
        {
            Destroy(gameObject);
        }
    }
}