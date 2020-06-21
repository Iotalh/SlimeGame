using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float flashCdLeft;
    public FlashIndicator flashIndicator;
    private Rigidbody2D rigid;
    private float flashSpeed = 100f;
    private float flashCd = 10f;
    private bool isInFlash = false;

    // Update is called once per frame
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        flashIndicator.SetCd(flashCd);

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2") && !isInFlash)
        {
            isInFlash = true;
            StartCoroutine("Flash");
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    IEnumerator Flash()
    {
        CanPenetrateEnemy(true);
        for (int i = 0; i < 10; i++)
        {
            rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * flashSpeed, 0);
            yield return null;
        }
        rigid.velocity = Vector2.zero;
        CanPenetrateEnemy(false);
        flashCdLeft = flashCd;
        while (flashCdLeft > 0f)
        {
            flashCdLeft -= Time.deltaTime;
            flashIndicator.SetCdLeft(flashCdLeft);
            yield return null;
        }
        flashIndicator.SetCdLeft(flashCdLeft);
        isInFlash = false;
    }

    void CanPenetrateEnemy(bool isStart)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<CircleCollider2D>().enabled = !isStart;
        }
    }
}