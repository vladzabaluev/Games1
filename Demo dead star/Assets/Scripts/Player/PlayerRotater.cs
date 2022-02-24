using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    public float smoothTime = 0.1f;
    Vector3 dampVel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //выпускаем луч, к месту, где находитсья курсор
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) //проверяем пересекает ли лучь что-то
        {
            if (!hit.transform.CompareTag("Player"))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, targetPosition, ref dampVel, smoothTime);
                transform.LookAt(smoothedPos);
            }
        }
    }
}
