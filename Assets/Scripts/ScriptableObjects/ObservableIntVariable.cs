using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Variables/Variables/Observable Int Variable")]
public class ObservableIntVariable : IntVariable
{
    [SerializeField]
    private GameEvent valueChangedCallback = null;

    [SerializeField]
    private bool raiseOnlyOnNewValue = false;

    public override int Value
    {
        get { return base.Value; }
        set
        {
            if (raiseOnlyOnNewValue == false || Value != value)
            {
                base.Value = value;

                if (valueChangedCallback != null)
                {
                    valueChangedCallback.Raise();
                }
                else
                {
                    Debug.LogWarningFormat("Callback not assigned! {0}", this.name);
                }
            }
        }
    }
}