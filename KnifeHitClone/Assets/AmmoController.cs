using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoController : MonoBehaviour
{
    public TextMeshProUGUI _goal;
    public TextMeshProUGUI _knifeIconCount;
    public TextMeshProUGUI _knifeNum;

    GridLayout grid;
    int ySpacing;
    public List<GameObject> knifesIcons = new List<GameObject>();
    int knifeNum;

    public int minGoal;
    public int maxGoal;
    public int goal;
    public int actualCount;
    [Space]
    [Header("Image")]
    public GameObject knifeIcon;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _goal.text = "Goal " + goal.ToString();
        _knifeIconCount.text = "_knifeIconCount " + knifesIcons.Count.ToString();
        _knifeNum.text = "_knifeNum " + actualCount.ToString();
    }

    public void Clear()
    {
        for (int i = 0; i < goal-1; i++)
        {
            Debug.LogWarning("Destroying, i = " + i);
            GameObject k = knifesIcons[goal-1 - i];
            knifesIcons.Remove(knifesIcons[goal-1 - i]);
            Destroy(k);
        }
    }

    public void NewGoal()
    {
        goal = Random.Range(minGoal, maxGoal);
        actualCount = goal;
        Debug.Log("Create new Goal");

        for (int i = 0; i < goal; i++)
        {
            Debug.LogWarning("Creating, i = " + i);
            knifesIcons.Add(knifeIcon);
            GameObject duplicate = Instantiate(knifeIcon);
            duplicate.transform.SetParent(gameObject.transform);
            duplicate.transform.localPosition = new Vector3(0,0,0);
            duplicate.transform.localScale = new Vector3(1, 1, 1);
            knifesIcons[i] = duplicate;
        }

        Debug.Log("KnifesIcons count = " + knifesIcons.Count);
    }

    public void Throw()
    {
        actualCount--;
    }
}
