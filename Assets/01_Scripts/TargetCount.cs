using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TargetCount : MonoBehaviour
{
    [SerializeField]
    public int targetCount;

    public int maxTargetCount;

    [SerializeField]
    private TargetIdleCheck targetIdleCheck;

    private TargetScript targetScript;

    // Start is called before the first frame update
    void Start()
    {
        targetIdleCheck = FindObjectOfType<TargetIdleCheck>();

        maxTargetCount = transform.childCount;
    }

    // Update is called once per frame

    private void Update()
    {
    }

    void FixedUpdate()
    {
        if (transform.childCount < maxTargetCount)
        {
            AddCount();
            maxTargetCount = transform.childCount;
        }
    }

    public void AddCount()
    {
        targetCount++;
    }
}
