using Assets.SimpleLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Unity.Localization;

public class Multilanguage : MonoBehaviour
{
    private void Awake()
    {
        LocalizationManager.Read();

        // LocalizationManager.Language = "English";
        
        LocalizationManager.Language = "Português";

    }
}
