using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractorRange;
    


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            Debug.DrawRay(r.origin, r.direction * 100, Color.red, 10f );
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractorRange))
            {   Debug.Log(hitInfo.collider.name);
                if (hitInfo.collider.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
                else if(hitInfo.collider.transform.parent!=null && hitInfo.collider.transform.parent.TryGetComponent(out interactObj)){
                    interactObj.Interact();
                }
            }
        }
    }
}
