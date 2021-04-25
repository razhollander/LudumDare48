using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_dictionary : MonoBehaviour
{
    private Dictionary<int, ISelectable> selectedTable = new Dictionary<int, ISelectable>();

    public void addSelected(GameObject go)
    {
        int id = go.GetInstanceID();
        var selectable = go.GetComponent<ISelectable>();

        if (!selectedTable.ContainsKey(id) && selectable != null)
        {
            selectedTable.Add(id, selectable);
            selectable.Select();
            Debug.Log("Added " + id + " to selected dict");
        }
    }

    public void DoTask(Vector2 point)
    {
        foreach (var selectable in selectedTable)
        {
            selectable.Value.DoSelectedTask(point);
        }
    }

    public void deselect(int id)
    {
        if (selectedTable.ContainsKey(id))
        {
            var selectable = selectedTable[id];

            if (selectable != null)
            {
                selectable.Deselect();
            }

            selectedTable.Remove(id);
        }
    }

    public void deselectAll()
    {
        foreach(KeyValuePair<int,ISelectable> pair in selectedTable)
        {
            if(pair.Value != null)
            {
                var selectable = pair.Value;

                if (selectable != null)
                {
                    selectable.Deselect();
                }
            }
        }

        selectedTable.Clear();
    }
}
