using UnityEngine;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

    [SerializeField]
    protected string type;

    [SerializeField]
    protected string player;

    protected int rank;

    [SerializeField]
    protected int basePrice;

    protected int price;

    void Start()
    {
        rank = PlayerPrefs.GetInt(player + "_" + type);

        price = basePrice * (rank + 1) * (rank + 1);

        ButtonSpriteController buttonSpriteController = GetComponent<ButtonSpriteController>();

        buttonSpriteController.setButtonSpriteName(buttonSpriteController.getButtonSpriteName() + "_" + rank.ToString());
    }

    public bool canBuy()
    {
        return PlayerPrefs.GetInt("Score") >= price;
    }

    public string getUpgradeCommandName()
    {
        return player + "_" + type + "$" + price.ToString();
    }

    public int getRank()
    {
        return rank;
    }

}
