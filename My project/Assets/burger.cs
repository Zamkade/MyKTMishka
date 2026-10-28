using UnityEngine;

public class burger : MonoBehaviour
{
    void Start()
    {
        GetBurger("сыр", "кетчуп", "котлета", "огурец", out string result1);
        Debug.Log("Результат 1: " + result1);

        GetBurger("специальный соус", "булочка с кунжутом", "две котлеты", "булочка", out string result2);
        Debug.Log("Результат 2: " + result2);

        GetBurger("помидор", "сыр", "салат", "лук", out string result3);
        Debug.Log("Результат 3: " + result3);
    }

    public void GetBurger(string ing1, string ing2, string ing3, string ing4, out string burgerType)
    {
        string[] ingredients = { ing1, ing2, ing3, ing4 };
        string[] cheeseburger = { "сыр", "кетчуп", "котлета", "огурец" };
        string[] bigMac = { "специальный соус", "булочка с кунжутом", "две котлеты" };

        if (MatchAll(ingredients, cheeseburger))
        {
            burgerType = "чизбургер";
        }
        else if (MatchPartial(ingredients, bigMac))
        {
            burgerType = "биг мак";
        }
        else
        {
            burgerType = "неизвестный бургер";
        }
    }

    private bool MatchAll(string[] input, string[] required)
    {
        if (input.Length != required.Length) return false;
        
        int matches = 0;
        foreach (string req in required)
        {
            foreach (string inp in input)
            {
                if (inp == req)
                {
                    matches++;
                    break;
                }
            }
        }
        return matches == required.Length;
    }

    private bool MatchPartial(string[] input, string[] required)
    {
        int matches = 0;
        foreach (string req in required)
        {
            foreach (string inp in input)
            {
                if (inp == req)
                {
                    matches++;
                    break;
                }
            }
        }
        return matches == required.Length;
    }
}