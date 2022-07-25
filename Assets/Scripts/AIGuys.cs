using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGuys : MonoBehaviour
{

    public float movSpeed = 10f;
    public float RotSpeed = 10f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isWandering == false)
        {
            //   StartCoroutine(isWandering());
            StartCoroutine("Wander");
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * RotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -RotSpeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * movSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotLorR = Random.Range(1, 3);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;

    }
}