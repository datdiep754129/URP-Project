using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsMoving : MonoBehaviour
{
    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;
 
        while(obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time/Vector3.Distance(startPosition, target))*speed);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public GameObject objectsPathStart;
    public GameObject objectsPathEnd;
    public int speed;
    private Vector3 startPosition;
    private Vector3 endPosition;   
    // Start is called before the first frame update
    void Start()
    {
        startPosition = objectsPathStart.transform.position;
        endPosition = objectsPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        if(transform.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
        
    }
}
