using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public GameObject weapone;
    public float speed = 5f;
    public float lifeTime = 3f;

    Vector3 direction;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        weapone = GameObject.Find("/Player/Cylinder/Weapone/FirePoint"); //находим оружие на сцене

        rb = GetComponent<Rigidbody>();
        direction = weapone.transform.forward; //определяем направление того, куда смотри оружие и движемся туда

        Invoke(nameof(DestroyBullet), lifeTime); //уничтожаем пулю спустя несколько секунд после выстрела


    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
