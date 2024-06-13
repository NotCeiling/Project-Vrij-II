using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionPlayer : MonoBehaviour
{
    public enum Suspect
    {
        Zack,
        Tim,
        Dean,
        Friday,
        Alison
    }
    
    [Header("References")]
    [SerializeField] private TMP_Text _secondsText;
    [SerializeField] private Image _suspicionBar;
    [SerializeField] private GameObject _highlight;
    
    [Header("Settings")]
    [SerializeField] private Suspect _suspect;
    [SerializeField] private string _secondsFormat = "{0} seconds";
    [Range(0, 1)]
    [SerializeField] private float minimumSuspicion = 0.01f;

    // Uncomment to test
    // static SuspicionPlayer()
    // {
    //     var random = new System.Random();
    //     SuspicionTracker.zackTimer = random.Next(0, 100);
    //     SuspicionTracker.timTimer = random.Next(0, 100);
    //     SuspicionTracker.deanTimer = random.Next(0, 100);
    //     SuspicionTracker.fridayTimer = random.Next(0, 100);
    //     SuspicionTracker.alisonTimer = random.Next(0, 100);
    // }
    
    private void Start()
    {
        _highlight.SetActive(false);
        SetSlider();
    }

    private void SetSlider()
    {
        var maxValue = Mathf.Max(SuspicionTracker.zackTimer, SuspicionTracker.timTimer, SuspicionTracker.deanTimer,
            SuspicionTracker.fridayTimer, SuspicionTracker.alisonTimer);
        maxValue = Mathf.Max(maxValue, 0.01f);

        // switch to set value
        var value = _suspect switch
        {
            Suspect.Zack => SuspicionTracker.zackTimer,
            Suspect.Tim => SuspicionTracker.timTimer,
            Suspect.Dean => SuspicionTracker.deanTimer,
            Suspect.Friday => SuspicionTracker.fridayTimer,
            Suspect.Alison => SuspicionTracker.alisonTimer,
            _ => throw new ArgumentOutOfRangeException()
        };

        var zeroOneValue = value / maxValue;
        _suspicionBar.fillAmount = zeroOneValue * (1 - minimumSuspicion) + minimumSuspicion;
        _secondsText.text = string.Format(_secondsFormat, Mathf.RoundToInt(value));
        
        if (zeroOneValue >= 0.9f)
        {
            _highlight.SetActive(true);
        }
    }
}