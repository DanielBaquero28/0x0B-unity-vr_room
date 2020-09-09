using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public BoxCollider door;
    Animator anim;
    public Collider rightHand;
    public Collider leftHand;
    void Awake()
    {
        anim = GetComponent<Animator>();
        door = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rightHand.bounds.Intersects(door.bounds))
        {
            if (anim.GetBool("Open") == false)
                Open();
            else
                Close();
        }

        if (leftHand.bounds.Intersects(door.bounds))
        {
            if (anim.GetBool("Open") == false)
                Open();
            else
                Close();
        }
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
