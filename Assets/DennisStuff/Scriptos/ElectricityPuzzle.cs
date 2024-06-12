using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityPuzzle : MonoBehaviour
{
    public GameObject[] knobs;
    public GameObject[] numberLights;
    public Material[] numberLightColors;
    public GameObject[] sliders;

    private bool numberColorsShowing;


    public GameObject phase2Plate;

    public Material offMat, onMat, greenMat, redMat, yellowMat, blueMat;

    public string knobCode = "368712945";
    public string sliderCode = "123123123";


    public void KnobChangeMade(int newKnobValue, int oldKnobValue)
    {
        Recount(newKnobValue);
        if (oldKnobValue != newKnobValue)
            Recount(oldKnobValue);
        AnswerCheckKnobs();
    }

    public void SliderChangeMade()
    {
        AnswerCheckSliders();
    }

    private void Recount(int knobValue)
    {
        int frequency = 0;

        foreach (GameObject knob in knobs)
        {
            if (knob.GetComponent<RotatingKnob>().value == knobValue)
                frequency++;
        }

        if (knobValue != 0)
        {
            if (frequency == 0)
            {
                numberLights[knobValue - 1].GetComponent<Renderer>().material = offMat;
            }

            if (frequency == 1)
            {
                numberLights[knobValue - 1].GetComponent<Renderer>().material = onMat;
            }

            if (frequency > 1)
            {
                numberLights[knobValue - 1].GetComponent<Renderer>().material = offMat;
            }
        }
    }

    private void AnswerCheckKnobs()
    {
        string codeAttempt = "";

        foreach (GameObject knob in knobs)
        {
            codeAttempt += knob.GetComponent<RotatingKnob>().value.ToString();
        }

        if (knobCode == codeAttempt)
        {
            UnlockSliders();
        }
    }

    private void UnlockSliders()
    {
        phase2Plate.GetComponent<RotatePlate>().unlocked = 1;
    }

    private void AnswerCheckSliders()
    {
        string codeAttempt = "";

        foreach (GameObject slider in sliders)
        {
            codeAttempt += slider.GetComponent<ElectricitySlider>().value.ToString();
        }

        if (sliderCode == codeAttempt)
        {
            Debug.Log("Lights are back on!");
        }
    }

    public void ToggleNumberColors()
    {
        if (numberColorsShowing)
        {
            numberColorsShowing = false;

            foreach (GameObject light in numberLights)
            {
                light.GetComponent<Renderer>().material = onMat;
            }
        }
        else
        {
            numberColorsShowing = true;

            for (int i = 0; i <= numberLights.Length - 1; i++)
            {
                numberLights[i].GetComponent<Renderer>().material = numberLightColors[i];
            }
        }
    }


}
