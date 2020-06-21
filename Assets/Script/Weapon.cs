using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float flashCdLeft;
    public float bulletCdLeft = 0f;
    public FlashIndicator flashIndicator;
    public BulletIndicator bulletIndicator;
    public int bulletCount = 3;
    private Rigidbody2D rigid;
    private float flashSpeed = 100f;
    private float flashCd = 10f;
    private float bulletCd = 3f;
    private bool flashable = true;
    private int bulletCountMax = 3;

    // Update is called once per frame
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        flashIndicator.SetCd(flashCd);
        bulletIndicator.SetBulletCount(bulletCountMax);
        bulletIndicator.SetCd(bulletCd);

    }
    void Update()
    {
        ReloadBullet();
        if (Input.GetButtonDown("Fire1") && bulletCount > 0)
        {
            bulletCount--;
            bulletIndicator.SetBulletCount(bulletCount);
            Debug.Log(bulletCount + " bullet Left");
            Shoot();
        }
        if (Input.GetButtonDown("Fire2") && flashable)
        {
            flashable = false;
            StartCoroutine("Flash");
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ReloadBullet()
    {
        if (bulletCount < bulletCountMax && bulletCdLeft == 0f)
        {
            bulletCdLeft = bulletCd;
            bulletIndicator.SetCdLeft(bulletCdLeft);
        }
        if (bulletCdLeft > 0f)
        {
            bulletCdLeft -= Time.deltaTime;
            bulletIndicator.SetCdLeft(bulletCdLeft);

            if (bulletCdLeft < 0f)
            {
                bulletCdLeft = 0f;
                bulletCount++;
                bulletIndicator.SetBulletCount(bulletCount);
            }
        }
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
        flashable = true;
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