using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private Transform tilePar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MT());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeTile(int x)
    {
        int a = 0;
        int b = 0; 

        for(int i = 0; i < x; i++)
        {
            Instantiate(tilePar, tilePar.position, tilePar.rotation);
        }
    }

    void MakeTile02()
    {

    }

    IEnumerator MT()
    {
        yield return new WaitForSeconds(2f);
        Vector3 pos = new Vector3(5f, 0f, 8f);
        Instantiate(tile, pos, Quaternion.identity);
    }
}