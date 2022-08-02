using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    public int Size;

    public Queue<Bullet> BulletQueue;
    public static BulletPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        BulletQueue = new Queue<Bullet>();

        for (int i = 0; i < Size; i++)
        {
            Bullet obj = Instantiate(bullet);
            obj.gameObject.SetActive(false);
            BulletQueue.Enqueue(obj);
        }
    }

    //public Bullet SpawnFromPool(Vector3 spawnPosition, Vector3 targetPostion)
    //{
    //    Bullet bulletToSpawn = PoolQueue.Dequeue();
    //    bulletToSpawn.gameObject.SetActive(true);
    //    bulletToSpawn.gameObject.transform.position = spawnPosition;

    //    bulletToSpawn.Shot(targetPostion);
    //    PoolQueue.Enqueue(bulletToSpawn);
    //    return bulletToSpawn;
    //}

    public Bullet Spawn(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Bullet bulletToSpawn = BulletQueue.Dequeue();
        bulletToSpawn.gameObject.SetActive(true);
        bulletToSpawn.gameObject.transform.position = spawnPosition;
        bulletToSpawn.gameObject.transform.rotation = spawnRotation;

        BulletQueue.Enqueue(bulletToSpawn);
        return bulletToSpawn;
    }

    public void BackToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}