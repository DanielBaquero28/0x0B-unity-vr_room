using UnityEngine;
using Valve.VR;

public class DoorManager : MonoBehaviour
{
    //public BoxCollider door;
    public Animator anim;
    public GameObject rightHand;
    public GameObject leftHand;

    public SteamVR_Input_Sources thisHand;
    public SteamVR_Action_Boolean isTriggered;

    public GameObject projector;
    public GameObject particleSys;

    int click = 0;


    void Start()
    {
        isTriggered.AddOnStateDownListener(TriggerDown, thisHand);
        isTriggered.AddOnStateUpListener(TriggerUp, thisHand);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log("Trigger is Up");
        click = 0;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log("Trigger is Down");
        click = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(click);
        if ((rightHand.transform.position.z > 5.8f && rightHand.transform.position.z < 6.2f && click == 1) || (leftHand.transform.position.z > 5.9f && leftHand.transform.position.z < 6.0f && click == 1))
        {
            //anim.SetBool("Open", true);
            //Debug.Log("Entered Position Condition");
            if (anim.GetBool("Open") == false)
            {
                //Debug.Log("anim.getbool('Open') == false");
                Open();
            }
        }

        // Testing
        if ((rightHand.transform.position.z > 6.9f && rightHand.transform.position.z < 7.14f && click == 1) || (leftHand.transform.position.z > 6.9f && leftHand.transform.position.z < 7.14f && click == 1))
        {
            if (anim.GetBool("Close") == false)
            {
                //Debug.Log("anim.getbool('Close') == false");
                Close();
            }
        }


        if (Vector3.Distance(rightHand.transform.position, projector.transform.position) <= 2.13f && Vector3.Distance(rightHand.transform.position, projector.transform.position) > 1.9f && click == 1)
        {
            particleSys.SetActive(true);
        }
        else if (Vector3.Distance(rightHand.transform.position, projector.transform.position) > 4.0f)
        {
            particleSys.SetActive(false);
        }

        //Debug.Log(Vector3.Distance(rightHand.transform.position, projector.transform.position));
        //Debug.Log("Open Bool Val: " + anim.GetBool("Open"));
        //Debug.Log(rightHand.transform.position.z);
    }

    void Open()
    {
        anim.SetBool("Open", true);
        anim.SetBool("Opened", true);
        anim.SetBool("Close", false);
        anim.SetBool("Closed", false);
    }

    void Close()
    {
        anim.SetBool("Open", false);
        anim.SetBool("Opened", false);
        anim.SetBool("Close", true);
        anim.SetBool("Closed", true);
    }
}
