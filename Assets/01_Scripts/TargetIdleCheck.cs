using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIdleCheck : MonoBehaviour
{
    [SerializeField]
    private TargetScript TargetScript;

    private TargetCount targetCount;

    [SerializeField]
    public  bool TargetCheck;

    private void Start()
    {
        TargetScript = GetComponent<TargetScript>();
    }

    private void Update()
    {
        TargetCheck = TargetScript.isDown;

        if(TargetCheck)
        {
            targetCount.AddCount();
        }
    }
}
