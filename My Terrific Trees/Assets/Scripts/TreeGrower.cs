using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    public GameObject smallTreePrefab;
    public GameObject bigTreePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GrowTree");
    }

    IEnumerator GrowTree()
    {
        yield return new WaitForSeconds(10);

        if (gameObject.CompareTag("Sapling"))
        {
            Instantiate(smallTreePrefab, transform.position, transform.rotation);
        }
        else if (gameObject.CompareTag("Small Tree"))
        {
            Instantiate(bigTreePrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

}
