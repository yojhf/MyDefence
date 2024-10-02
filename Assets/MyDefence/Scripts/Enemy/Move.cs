using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;


        StartCoroutine(MoveObject());   
    }

    IEnumerator MoveObject()
    {
        float mtime = 1f;
        float rtime = 0f;

        Vector3 dpoos = Vector3.zero;
        Vector3 dpoosy = Vector3.zero;
        Vector3 objPos = Vector3.zero;

        dpoos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f);
        dpoosy = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);

        while (rtime < mtime)
        {
            transform.position = Vector3.Lerp(transform.position, dpoos, Time.deltaTime * mtime);

            rtime += Time.deltaTime;

            yield return null;
        }

        rtime = 0f;
        transform.position = dpoos;

        while (rtime < mtime)
        {
            transform.position = Vector3.Lerp(transform.position, dpoosy, Time.deltaTime * mtime);

            rtime += Time.deltaTime;

            yield return null;
        }

        rtime = 0f;

        while (rtime < mtime)
        {
            transform.position = Vector3.Lerp(transform.position, -dpoos, Time.deltaTime * mtime);

            rtime += Time.deltaTime;

            yield return null;
        }

        rtime = 0f;

        while (rtime < mtime)
        {
            transform.position = Vector3.Lerp(transform.position, -dpoosy, Time.deltaTime * mtime);

            rtime += Time.deltaTime;

            yield return null;
        }
    }
}
