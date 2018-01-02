using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour
{
    private const int DefaultCandyAmount = 30;
    private const int RecoverySeconds = 10;

    private int candy;
    private int counter;

    // Use this for initialization
    void Start()
    {
        candy = DefaultCandyAmount;
    }

    public void CosumeCandy()
    {
        if (candy > 0) {
            candy--;
        }
    }

    public int GetCandyAmount()
    {
        return candy;
    }

    public void AddCandy(int amount)
    {
        candy += amount;
    }

    private void OnGUI()
    {
        GUI.color = Color.black;
        string label = "Candy: " + candy;

        if (counter > 0) {
            label = label + "(" + counter + "s)";
        }

        GUI.Label(new Rect(0, 0, 100, 30), label);
    }

    // Update is called once per frame
    void Update()
    {
        if (candy < DefaultCandyAmount && counter <= 0) {
            StartCoroutine(RecoverCandy());
        }
    }

    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;

        while (counter > 0) {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        candy++;
    }
}