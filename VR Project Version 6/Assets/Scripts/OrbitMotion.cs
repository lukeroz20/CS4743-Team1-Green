using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    public float orbitPeriod;
    public bool orbitActive = true;



    void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        SetOrbitingObjectPosition();

        //Create listeners
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressed, SteamVR_Input_Sources.Any);
        SteamVR_Actions.default_GrabPinch.AddOnStateUpListener(TriggerReleased, SteamVR_Input_Sources.Any);



    }

    private void Update()
    {
        float orbitSpeed = 1f / orbitPeriod;
        orbitProgress += Time.deltaTime * orbitSpeed;
        orbitProgress %= 1f;
        SetOrbitingObjectPosition();
    }

    //Listener methods for detecting if trigger is up or down
    private void TriggerPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger pressed!");
        orbitPeriod = orbitPeriod / 3;
    }

    private void TriggerReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger released!");
        orbitPeriod = orbitPeriod * 3;
    }
    

    void SetOrbitingObjectPosition()
    {
        Vector3 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.z);
    }
}
