using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]

public class CloneGameObject : MonoBehaviour
{
    XRSimpleInteractable simpleInteractable;
    public GameObject prefabToClone = null;
    public Transform attachPoint = null;
    public string attachPtName;

    private GameObject clonedObject = null;

    protected void OnEnable()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
    }

    public virtual void OnFirstHoverEntered(HoverEnterEventArgs args)
    {
        CloneObject(args.interactorObject.GetAttachTransform(args.interactableObject));
    }

    public virtual void OnLastHoverExited(HoverExitEventArgs args)
    {
        CloneObject(args.interactorObject.GetAttachTransform(args.interactableObject));
    }

    public virtual void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (clonedObject)
            ReleaseAndDetroyObject();
        else
            CloneObject(args.interactorObject.GetAttachTransform(args.interactableObject));
    }

    public virtual void OnSelectExited(SelectExitEventArgs args)
    {
        //ReleaseAndDetroyObject();
    }

    private void ReleaseAndDetroyObject()
    {
        if (clonedObject)
        {
            clonedObject.transform.parent.DetachChildren();
            Destroy(clonedObject);
        }
    }

    private void CloneObject(Transform attachPt)
    {
        Debug.Log("Cloning");
        clonedObject = Instantiate(prefabToClone, Vector3.zero, Quaternion.identity) as GameObject;
        clonedObject.transform.parent = attachPt; // attachPoint;
        
        if (attachPtName.Length > 0)
        {
            foreach (Transform t in clonedObject.transform)
            {
                if (t.gameObject.name == attachPtName)
                {
                    clonedObject.transform.localPosition = t.gameObject.transform.localPosition;
                    clonedObject.transform.localRotation = t.gameObject.transform.localRotation;
                }
            }
        }
        else
        {
            clonedObject.transform.localPosition = Vector3.zero;
            clonedObject.transform.localRotation = Quaternion.identity;
        }
    }
}
