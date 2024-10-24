using UnityEngine;

public class DoorController : MonoBehaviour
{

    // The Animator component manages the door opening and closing animations.
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // These functions just return the current state of the animation.
    // The animator component uses a state machine to keep track of the door being 
    // open/closed or currently opening/closing. 
    bool inOpenState() {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("open");
    }
    bool inClosedState() {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("closed");
    }
    bool inOpeningState() {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("opening");
    }
    bool inClosingState() {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("closing");
    }

    // Opens the door if it is currently closed or closes the door if it is currently open.
    // This function does nothing if called during an animation. 
    [ContextMenu("toggle door")]
    public void toggleDoor() {
        bool closed = animator.GetBool("isClosed");
        if(inClosedState() && closed || inOpenState() && !closed) {
            animator.SetBool("isClosed", !closed);
        }
    }

    // Opens door only if it is closed. 
    [ContextMenu("open door")]
    public void openDoor() {
        if(inClosedState()) animator.SetBool("isClosed", false);
    }
}