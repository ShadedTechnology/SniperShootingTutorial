using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class DoFManager : MonoBehaviour {
    
    public DepthOfFieldDeprecated dof;

    public void EnableDepthOfField()
    {
        dof.enabled = true;
    }

    public void DisableDepthOfField()
    {
        dof.enabled = false;
    }
}
