using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyHolder candyHolder;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotaion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "candy") {
            candyHolder.AddCandy(reward);
            Destroy(other.gameObject);

            if (effectPrefab != null) {
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotaion)
                );
            }
        }
    }
}