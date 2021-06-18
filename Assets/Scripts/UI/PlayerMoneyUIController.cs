using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyUIController : MonoBehaviour
{
    [SerializeField]
    private ObservableIntVariable currentPlayerMoney;
    [SerializeField]
    private Text coinAmountText;

    private void Awake()
    {
        currentPlayerMoney.Value = 0;   //Restart coin amount
        UpdateCoinAmount();
    }

    public void UpdateCoinAmount()
    {
        coinAmountText.text = $"x{currentPlayerMoney.Value}";
    }
}
