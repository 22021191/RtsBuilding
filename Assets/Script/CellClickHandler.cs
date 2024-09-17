using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellClickHandler : MonoBehaviour
{
    public GameObject childObjectPrefab;

    private void OnMouseDown()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Khong co Object con");
            /*GameObject childObject = Instantiate(childObjectPrefab, transform);
            childObject.transform.localPosition = Vector3.zero;*/
        }
        else
        {
            Debug.Log(" object con!");
        }
    }
}
