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
        if (rightHand.transform.position.z > 5.9f && rightHand.transform.position.z < 6.0f)
        {
            //anim.SetBool("Open", true);
            Debug.Log("Entered Position Condition");
            if (anim.GetBool("Open") == false)
            {
                Debug.Log("anim.getbool('Open') == false");
                Open();
            }
            //else
            //{
                //Debug.Log("Else condition");
                //Close();
            //}

        }

        // I'm not testing this condition for now
        if (rightHand.transform.position.z > 12.0f)
        {
            if (anim.GetBool("Open") == false)
                Open();
            else
                Close();
        }
        Debug.Log("Open Bool Val: " + anim.GetBool("Open"));
        //Debug.Log(rightHand.transform.position.z);
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
