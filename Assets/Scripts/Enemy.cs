using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem destroedVFX;
    [SerializeField] int hitPoint = 2;

    int score;

    ScoreBoard sb;

    private void Start()
    {
        sb = FindFirstObjectByType<ScoreBoard>();
        score = hitPoint;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoint--;

        if (hitPoint <= 0)
        {
            sb.increaseScore(score);
            Instantiate(destroedVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    } 
}
