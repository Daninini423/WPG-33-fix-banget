using System.Collections;
using UnityEngine;

public class playerSlashing : MonoBehaviour
{
    public Transform firePoint;        // Titik tempat peluru ditembakkan
    public GameObject bulletPrefab;    // Prefab peluru
    public float bulletLifetime = 2f;  // Lama sebelum peluru dihancurkan
    public float attackInterval = 2f;  // Serangan otomatis setiap 2 detik

    private bool isAttacking = true;   // Bisa kamu ubah ke false untuk berhenti

    void Start()
    {
        StartCoroutine(AutoAttack());
    }

    IEnumerator AutoAttack()
    {
        while (isAttacking)
        {
            Swing();
            yield return new WaitForSeconds(attackInterval); // tunggu 2 detik
        }
    }

    void Swing()
    {
        GameObject slash = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(slash, bulletLifetime);
    }
}
