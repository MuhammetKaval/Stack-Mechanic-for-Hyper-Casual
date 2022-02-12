using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;

    [SerializeField] private float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        distanceBetweenObjects = prevObject.localScale.y;
    }

    public void Collect(GameObject collectedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
        {
            collectedObject.tag = tag;
        }

        collectedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += downOrUp ? distanceBetweenObjects : -distanceBetweenObjects;

        collectedObject.transform.localPosition = desPos;

        prevObject = collectedObject.transform;
    }

}
