using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationComponent : MonoBehaviour
{
    [Header("SETTINGS")]
    [SerializeField] private bool playPresentation;

    void Start()
    {
        if (playPresentation) PlayPresentation();
    }

    void PlayPresentation()
    {

    }
}
