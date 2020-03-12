using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MyActionScript : MonoBehaviour
{
    //A reference to the action
    public SteamVR_Action_Boolean SphereOnOff;

    //A reference to the hadn
    public SteamVR_Input_Sources handType;

    //reference to the sphere
    public GameObject Sphere;

    void Start()
    {
        SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
        SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger is up");
        Sphere.GetComponent<MeshRenderer>().enabled = false;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger is down");
        Sphere.GetComponent<MeshRenderer>().enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
