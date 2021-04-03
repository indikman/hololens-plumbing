using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManagerPrepared : MonoBehaviour
{
    // Get the list of gameobjects
    public GameObject[] GuideSteps;
    public Transform StepHolder;

    private int currentStep = 0;

    private void Start()
    {
        ResetFlow();
    }

    public void ChangeStep(bool isNext)
    {
        if (isNext)
        {
            if(currentStep >= GuideSteps.Length-1)
            {
                Debug.Log("Reached the end of the steps");
                return;
            }

            currentStep++;

        }
        else
        {
            if(currentStep <= 0)
            {
                Debug.Log("No more steps before this");
                return;
            }

            currentStep--;
        }

        HideAllSteps();
        GuideSteps[currentStep].SetActive(true);

    }

    private void HideAllSteps()
    {
        foreach(Transform child in StepHolder)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void ResetFlow()
    {
        HideAllSteps();
        GuideSteps[0].SetActive(true);
        currentStep = 0;
    }


}
