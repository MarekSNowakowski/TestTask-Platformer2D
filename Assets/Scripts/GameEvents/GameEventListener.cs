using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private List<GameEventAction> actions = new List<GameEventAction>();

    private Dictionary<GameEvent, GameEventAction> actionsDictionary = new Dictionary<GameEvent, GameEventAction>();

    private void OnEnable()
    {
        foreach (var action in actions)
        {
            action.gameEvent.RegisterListener(this);
            actionsDictionary.Add(action.gameEvent, action);
        }
    }

    private void OnDisable()
    {
        for (int i = actions.Count - 1; i >= 0; i--)
        {
            actions[i].gameEvent.UnregisterListener(this);
        }

        actionsDictionary.Clear();
    }

    public void OnEventRaised(GameEvent gameEvent)
    {
        actionsDictionary[gameEvent].response.Invoke();
    }
}
