﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{

    public GameObject[] portions;
    int currentIndex;
    float lastChange;
    [SerializeField] float interval = 1f;
    [SerializeField] AudioSource ConsumeAudioSource;


    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Head"))
        {
            Debug.Log("MANGIANDO");
            

            if (Time.time - lastChange > interval)
            {
                float timeLeft = Time.time - lastChange;
                Debug.Log(timeLeft);
                Consume();
                lastChange = Time.time;
            }
        }

    }


    void Start()
    {
        bool skipFirst = transform.childCount > 4;
        portions = new GameObject[skipFirst ? transform.childCount-1 : transform.childCount];
        for (int i = 0; i < portions.Length; i++)
        {
           
            portions[i] = transform.GetChild(skipFirst ? i + 1 : i).gameObject;
            if (portions[i].activeInHierarchy)
                currentIndex = i;
        }
    }

    void Update()
    {
       /* if (Time.time - lastChange > interval)
        {
            Consume();
            lastChange = Time.time;
        }*/
    }

    void Consume()
    {
        if (currentIndex < portions.Length)
            portions[currentIndex].SetActive(false);
        
        currentIndex++;

        MainManager.Instance.ManagerAudio.playEffectOnce(ConsumeAudioSource);

        if (currentIndex > portions.Length)
        {
            currentIndex = 0;
           // Destroy(gameObject);
        }
            
        else if (currentIndex == portions.Length)
            return;
        portions[currentIndex].SetActive(true);
    }

}
