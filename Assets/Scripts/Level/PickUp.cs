using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PickUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int id;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(SetPickUp());
    }

    IEnumerator SetPickUp()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("Click en pickup");
        PickUpAction.pickUp = this;
        CharacterNavMesh.instance.ThereIsAItem = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
