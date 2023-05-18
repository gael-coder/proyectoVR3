using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class simpleAttach : MonoBehaviour
{
    private Interactable Interactable;
        void Start()
    {
        Interactable= GetComponent<Interactable>(); 
    }

    private void OnHandHoverBegin( Hand hand)
    {
        hand.ShowGrabHint();
    }
    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    private void OnHandHoverUpdate(Hand hand)
    {
        GrabTypes grabTypes = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if(Interactable.attachedToHand == null && grabTypes != GrabTypes.None )
        {
            hand.AttachObject(gameObject,grabTypes);
            hand.HoverLock(Interactable);
            hand.HideGrabHint();
        }
        else if (isGrabEnding) {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(Interactable);

        }
    }
}
