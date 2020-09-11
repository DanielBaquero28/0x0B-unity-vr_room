using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public BoxCollider door;
    Animator anim;
    public GameObject rightHand;
    public GameObject leftHand;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        door = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rightHand.transform.position.z > 0.5 && rightHand.transform.position.z < 0.6)
        {
            //anim.SetBool("Open", true);
            Debug.Log("Entered Position Condition");
            if (anim.GetBool("Open") == false)
            {
                Debug.Log("anim.getbool('Open') == false");
                Open();
            }
            else
            {
                Debug.Log("Else condition");
                Close();
            }

        }

        // I'm not testing this condition for now
        if (0 < 1)
        {
            if (anim.GetBool("Open") == false)
                Open();
            else
                Close();
        }
        Debug.Log("Open Bool Val: " + anim.GetBool("Open"));
        //Debug.Log(rightHand.transform.position.x);
    }

    void Open()
    {
        anim.SetBool("Open", true);
        anim.SetBool("Close", false);
    }

    void Close()
    {
        anim.SetBool("Open", false);
        anim.SetBool("Close", true);
    }
}
