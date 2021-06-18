using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject heartPrefab;
    [SerializeField]
    private ObservableIntVariable maxPlayerHealthVariable;
    [SerializeField]
    private ObservableIntVariable currentPlayerHealthVariable;

    private readonly string heartGone = "heart_gone";

    private Animator[] hearthAnimators;

    private void Awake()
    {
        hearthAnimators = new Animator[maxPlayerHealthVariable.Value];
        for (int i = 0; i < maxPlayerHealthVariable.Value; i++)
        {
            var heartObject = Instantiate(heartPrefab);
            heartObject.transform.SetParent(transform);
            hearthAnimators[i] = heartObject.GetComponent<Animator>();
        }
    }

    public void EmptyHeart()
    {
        if(hearthAnimators[currentPlayerHealthVariable.Value])
        {
            hearthAnimators[currentPlayerHealthVariable.Value].SetBool(heartGone, true);
        }
    }
}
