using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsControl : MonoBehaviour
{
    public List<Transform> SpawnPositions;

    public List<GameObject> DollPrefs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TargetHuman")
        {
            if (other.GetComponent<Target>()) StartCoroutine(SpawnNewDoll(other.GetComponent<Target>().selfNumber));
            Ui.lastFall += 8.0f;

            Ui.Score += 1;
        }
    }

    private void Start()
    {
        SpawnDoll(0);
        SpawnDoll(1);
        SpawnDoll(2);
    }

    IEnumerator SpawnNewDoll(int targetNumber)
    {
        yield return new WaitForSeconds(5);

        GameObject H = Instantiate(DollPrefs[targetNumber], SpawnPositions[targetNumber].position, SpawnPositions[targetNumber].rotation);
    }

    void SpawnDoll(int targetNumber)
    {
        GameObject H = Instantiate(DollPrefs[targetNumber], SpawnPositions[targetNumber].position, SpawnPositions[targetNumber].rotation);
    }
}
