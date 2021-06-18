using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Variables/Variables/Int Variable")]
public class IntVariable : ScriptableObject
{
    [SerializeField]
    protected int intValue;

    public virtual int Value
    {
        get
        {
            return intValue;
        }

        set
        {
            intValue = value;
        }
    }
}
