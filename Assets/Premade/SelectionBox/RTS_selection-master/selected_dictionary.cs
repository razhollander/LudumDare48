using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_dictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();

    public void addSelected(GameObject go)
    {
        int id = go.GetInstanceID();
        var selectable = go.GetComponent<ISelectable>();

        if (!selectedTable.ContainsKey(id) && selectable != null)
        {
            selectedTable.Add(id, go);
            selectable.Select();
            Debug.Log("Added " + id + " to selected dict");
        }
    }

    public void deselect(int id)
    {
        if (selectedTable.ContainsKey(id))
        {
            var selectable = selectedTable[id].GetComponent<ISelectable>();

            if (selectable != null)
            {
                selectable.Deselect();
            }

            selectedTable.Remove(id);
        }
    }

    public void deselectAll()
    {
        foreach(KeyValuePair<int,GameObject> pair in selectedTable)
        {
            if(pair.Value != null)
            {
                var selectable = pair.Value.GetComponent<ISelectable>();

                if (selectable != null)
                {
                    selectable.Deselect();
                }
            }
        }

        selectedTable.Clear();
    }
}
