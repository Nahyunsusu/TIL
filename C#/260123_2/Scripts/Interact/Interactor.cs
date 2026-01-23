using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] LayerMask _targetMask;
    Ray _ray;

    Vector3 _rayPoint;

    private void Update()
    {
        _ray = new Ray(transform.position + new Vector3(0, 1.3f, 0), transform.forward);
        // 상호작용 키
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        RaycastHit hit;

        if(Physics.Raycast(_ray, out hit, 20f, _targetMask))
        {
            // 특정 객체만 반응하도록
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_ray.origin, _ray.direction * 20f);
    }
}
