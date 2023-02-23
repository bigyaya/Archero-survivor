using UnityEngine;
using UnityEngine.Events;

public class RewardsEffects : MonoBehaviour
{
    public GameObject bonusBulletPrefab;
    public float bonusBulletSpeed = 1f;

    public UnityEvent CreateBonusBullet;
    public UnityEvent DoubleAttack;

    private void Start()
    {
        CreateBonusBullet.AddListener(SpawnBonusBullet);
        DoubleAttack.AddListener(OnDoubleAttack);
    }

    public void SpawnBonusBullet()
    {
        Debug.Log("CreateBonusBullet invoked");
    }

    public void OnDoubleAttack()
    {
        Debug.Log("DoubleAttack invoked");
    }

    public void SpawnBonusBullet(Vector3 position)
    {
        // Générer une direction aléatoire
        Vector3 direction = Random.insideUnitCircle.normalized;

        // Instancier le projectile bonus et le lancer dans la direction aléatoire
        GameObject bonusBullet = Instantiate(bonusBulletPrefab, position, Quaternion.identity);
        bonusBullet.GetComponent<Rigidbody2D>().velocity = direction * bonusBulletSpeed;

        // Appeler l'événement CreateBonusBullet
        CreateBonusBullet.Invoke();
    }
}
