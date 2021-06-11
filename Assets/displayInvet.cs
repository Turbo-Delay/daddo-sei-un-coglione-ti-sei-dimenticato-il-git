using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class displayInvet : MonoBehaviour
{
    public InvetoryObject invetory;
    public int X_between;
    public int Y_bwtween;
    public int n_col;
    public int x_start;
    public int y_start;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        updateDisplay();
    }
    public void CreateDisplay()
    {
        for (int i = 0; i < invetory.Container.Count; i++)
        {
            var obj = Instantiate(invetory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = invetory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(invetory.Container[i], obj);
        }
    }
    public Vector3 getPosition(int i)
    {
        return new Vector3(x_start + (X_between * (i % n_col)), y_start + (-Y_bwtween * (i / n_col)), 0f);
    }
    public void updateDisplay()
    {
        for (int i = 0; i < invetory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(invetory.Container[i]))
            {
                itemsDisplayed[invetory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = invetory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(invetory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = getPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = invetory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(invetory.Container[i], obj);
            }
        }
    }
    // https://www.youtube.com/watch?v=232EqU1k9yQ part 2;
}
