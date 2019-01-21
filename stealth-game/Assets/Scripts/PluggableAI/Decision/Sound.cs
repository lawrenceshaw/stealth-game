using UnityEngine;

public class Sound : MonoBehaviour
{
    public float lifeTimer;

    private void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        var enemy = collision.gameObject.GetComponent<StateController>();

        if (enemy != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}