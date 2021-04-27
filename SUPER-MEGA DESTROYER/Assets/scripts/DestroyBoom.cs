using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyExplode), 0.2f);
    }

    // Update is called once per frame
    private void DestroyExplode()
    {
        Destroy(gameObject);
    }
}
