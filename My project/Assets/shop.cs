using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] productNameTexts;
    [SerializeField] private TextMeshProUGUI[] priceTexts;
    [SerializeField] private TextMeshProUGUI totalPriceText;

    private float[] currentPrices;
    private float totalPrice = 0f;

    void Start()
    {
        string[] productNames = { "Ноутбук", "Мышка", "Клавиатура", "Монитор", "Наушники" };
        float[] prices = { 50000f, 1500f, 3000f, 15000f, 5000f };

        DisplayCart(productNames, prices);
    }

    public void DisplayCart(string[] productNames, float[] prices)
    {
        currentPrices = new float[prices.Length];
        totalPrice = 0f;

        for (int i = 0; i < productNames.Length; i++)
        {
            productNameTexts[i].text = productNames[i];
            priceTexts[i].text = prices[i].ToString();

            currentPrices[i] = prices[i];
            totalPrice += prices[i];

            Debug.Log($"Товар: {productNames[i]} - Цена: {prices[i]}изумрудов");
        }

        UpdateTotal();
    }

    public void NextDay()
    {
        for (int i = 0; i < currentPrices.Length; i++)
        {
            currentPrices[i] *= 2f;
            priceTexts[i].text = currentPrices[i].ToString();
        }

        totalPrice = 0f;
        for (int i = 0; i < currentPrices.Length; i++)
        {
            totalPrice += currentPrices[i];
        }

        Debug.Log($"===== ИТОГО: {totalPrice} изумрудов =====");
        UpdateTotal();
    }

    private void UpdateTotal()
    {
        totalPriceText.text = $"Итого: {totalPrice} изумрудов";
    }
}
