using UnityEngine;

public class PickUpAction : MonoBehaviour
{
    public static PickUp pickUp { get; set; }

    private void Start()
    {
        CharacterNavMesh.instance.isTheCharacterStop += TryGrabItem;
    }

    public void TryGrabItem()
    {
        Debug.Log("Intentando agarrar: " + Vector2.Distance(transform.position, pickUp.transform.position));
        if (Vector2.Distance(transform.position, pickUp.transform.position) < 1.5f)
        {
            Debug.Log("Hacer algo con el id: " + pickUp);
            InventoryManager.instance.SetItem(pickUp.id);
        }
        else
            Debug.Log("Esta muy lejos");

        CharacterNavMesh.instance.ThereIsAItem = false;
    }
}
