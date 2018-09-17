using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{

    public GameObject theBox;
    private PlatformGeneration thePlatformGeneration;
    private bool hasSpawn;
    public GameObject theQuestionHolder;


    // Use this for initialization
    void Start()
    {
        thePlatformGeneration = FindObjectOfType<PlatformGeneration>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newBoxPosition = new Vector3(transform.position.x + 12, 1, 0);
        //Spawns the box everytime after 5 platforms are beinggenerated
        if ((thePlatformGeneration.platformCount % 5) == 0)
        {
            if (hasSpawn)
            {
                Instantiate(theBox, newBoxPosition, transform.rotation);
                hasSpawn = false;
            }
        }
        else
        {
            hasSpawn = true;
        }
    }

    public void DisableQuestionHolder()//to make the questions disappear 
    {
        theQuestionHolder.SetActive(false);

    }
    public void EnableQuestionHolder()//Make the question holders appear
    {
        theQuestionHolder.SetActive(true);
    }


}