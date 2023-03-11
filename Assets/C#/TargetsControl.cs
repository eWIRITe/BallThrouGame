using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsControl : MonoBehaviour
{
    public List<Transform> SpawnPositions;

    public List<GameObject> DollPrefs;

    public List<GameObject> Targets;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TargetHuman")
        {
            if (other.GetComponent<Target>()) StartCoroutine(SpawnNewDoll(other.GetComponent<Target>().selfNumber));

            Destroy(other.gameObject, 2);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnNewDoll(0));
        StartCoroutine(SpawnNewDoll(1));
        StartCoroutine(SpawnNewDoll(2));
    }

    IEnumerator SpawnNewDoll(int targetNumber)
    {
        yield return new WaitForSeconds(8);

        GameObject H = Instantiate(DollPrefs[targetNumber], SpawnPositions[targetNumber].position, SpawnPositions[targetNumber].rotation);
    }
}
