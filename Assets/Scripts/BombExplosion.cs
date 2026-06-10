using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [Header("Explosion Settings")]
    public float explosionRadius = 5f;
    public float explosionForce = 20f;

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void Explode()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearby in nearbyObjects)
        {
            if (nearby.CompareTag("Player"))
            {
                PlayerMovement player = nearby.GetComponentInParent<PlayerMovement>();

                if (player != null)
                {
                    player.AddBlastForce(transform.position, explosionForce);
                }
            }
        }

        // TODO:
        // Spawn explosion particles here
        // Play explosion sound here

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            transform.position,
            explosionRadius
        );
    }
}