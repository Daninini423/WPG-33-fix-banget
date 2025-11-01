using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Transform player;
    public Transform player2;// Referensi ke transform pemain
    public float moveSpeed; // Kecepatan gerakan musuh
    public Vector3 target;

    void Start()
    {

        // Mencari objek PlayerMovement di scene
        player = FindObjectOfType<playerMovement>()?.transform;
        player2 = FindObjectOfType<playerMovement2>()?.transform;
        // Memastikan player tidak null
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Cek apakah referensi masih valid
        if (player == null && player2 == null)
        {
            // Kalau dua-duanya mati, musuh tidak punya target
            return;
        }

        float distancePlayer = Mathf.Infinity;
        float distancePlayer2 = Mathf.Infinity;

        // Hitung jarak ke player 1 jika masih hidup
        if (player != null)
        {
            distancePlayer = (transform.position - player.position).sqrMagnitude;
        }

        // Hitung jarak ke player 2 jika masih hidup
        if (player2 != null)
        {
            distancePlayer2 = (transform.position - player2.position).sqrMagnitude;
        }

        // Tentukan target terdekat
        if (distancePlayer < distancePlayer2 && player != null)
        {
            target = player.position;
        }
        else if (player2 != null)
        {
            target = player2.position;
        }

        // Gerakkan musuh ke target jika masih ada player
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        spriteRenderer.flipX = target.x < transform.position.x;
    }

}
