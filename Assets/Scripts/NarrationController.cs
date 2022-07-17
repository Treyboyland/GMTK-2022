using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationController : MonoBehaviour
{
    [SerializeField]
    PlayerShip ship;

    [SerializeField]
    NarrationButton buttonPrefab;

    [SerializeField]
    Transform buttonPanel;

    [SerializeField]
    List<NarrationSO> texts;

    [SerializeField]
    int orbitsPerFind;

    List<NarrationSO> findOrder = new List<NarrationSO>();

    int findIndex = 0;

    Dictionary<NarrationSO, NarrationButton> buttonDictionary = new Dictionary<NarrationSO, NarrationButton>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var text in texts)
        {
            NarrationButton button = Instantiate(buttonPrefab, buttonPanel);
            button.Narration = text;
            button.gameObject.SetActive(true);
            button.UpdateText();
            findOrder.Add(text);
            buttonDictionary.Add(text, button);
        }
        findOrder.Shuffle();
    }

    void FindNarration()
    {
        var currentFind = findOrder[findIndex];
        findIndex = (findIndex + 1) % findOrder.Count;
        buttonDictionary[currentFind].Found = true;
        buttonDictionary[currentFind].UpdateText();
    }

    public void CheckFind()
    {
        if (ship.OrbitCount % orbitsPerFind == 0)
        {
            FindNarration();
        }
    }
}
