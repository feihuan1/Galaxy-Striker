using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem DestroyedParticle;

    private void OnTriggerEnter(Collider other) {
        Instantiate(DestroyedParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
