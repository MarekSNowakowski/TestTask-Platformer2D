using System.Collections;
using UnityEngine;

public class HealthTest : TestClass
{
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private ObservableIntVariable healthVariable;

    private int initialValue;

    private void Start()
    {
        initialValue = healthVariable.Value;
        StartCoroutine(TestReducingHealthCoroutine(waitTime));
    }

    /// <summary>
    /// Reducing health test
    /// </summary>
    private IEnumerator TestReducingHealthCoroutine(float seconds)
    {
        for(int i = 0; i < initialValue; i++)
        {
            yield return new WaitForSeconds(seconds);
            healthVariable.Value--;
        }
    }

    private void OnDisable()
    {
        healthVariable.Value = initialValue;
    }
}
