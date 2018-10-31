using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpingObject : MonoBehaviour
{

    public float minJumpHeight = 0.1f;
    public float maxJumpHeight = 0.5f;
    public int jumpNumber = 100;
    Sequence mySequence;
    Vector3 startPos;
    public Transform destinationPos;
    public float moveTime = 1f;
    private void Start()
    {
        startPos = transform.position;
    }
    private void OnEnable()
    {
        mySequence = DOTween.Sequence();
        transform.DOMoveX(destinationPos.position.x, moveTime);
        transform.DOMoveZ(destinationPos.position.z, moveTime).OnComplete(disableObject);
        for (int i = 0; i < jumpNumber; i++)
        {

            mySequence
            .Append(transform.DOMoveY(transform.position.y + Random.Range(minJumpHeight, maxJumpHeight), 0.5f))
            .Append(transform.DOMoveY(transform.position.y, 0.5f));
        }

    }

    void disableObject()
    {
        Destroy(gameObject);
        
    }

}