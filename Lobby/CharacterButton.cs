using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacter character;

    [SerializeField]
    private PlayerStat playerStat;

    public PlayerStat PlayerStat
    {
        get { return playerStat; }
    }
   
    [SerializeField]
    private Text characterName;

    [SerializeField]
    private Image characterImage;

    [SerializeField]
    private Image weponImage;

    [SerializeField]
    private string characterDetail;

    //stat 파넬 
    [SerializeField]
    private Text statText;


    //디테일 파넬
    [SerializeField]
    private Text detailName;

    [SerializeField]
    private Image detailCharacterImage;

    [SerializeField]
    private Image detailWeaponImage;

    [SerializeField]
    private Text detailIText;

    [SerializeField]
    private SelectButton selectButton;


    public void UpdateDetailPanel()
    {
        selectButton.characterButton = this;

        detailName.text = characterName.text;
        detailCharacterImage.sprite = characterImage.sprite;
        detailWeaponImage.sprite = weponImage.sprite;
        detailIText.text = characterDetail;

    }

    public void UpdateStatPanelText()
    {
        PlayerPower playerPowerData = GameSystem.Instance.GetGameData();

        //panel text 수정
        StringBuilder sb = new StringBuilder(string.Format("{0}\n", playerPowerData.MaxHealth * (playerStat.MaxHealth * 0.1) + (int)playerStat.MaxHealth));
        sb.Append(string.Format("{0:0.0}\n",playerPowerData.Recovery * 0.1 + playerStat.Recovery));
        sb.Append(string.Format("{0}\n", playerPowerData.Armor + playerStat.Armor ));
        sb.Append(string.Format("{0}\n", playerPowerData.MoveSpeed * (playerStat.MoveSpeed * 0.05f) + playerStat.MoveSpeed));
        sb.Append("\n");
        sb.Append(string.Format("{0}%\n", playerPowerData.Might * 5 + (playerStat.Might-1) * 100));
        sb.Append(string.Format("{0}%\n", playerPowerData.Area * 5 + (playerStat.Area-1) * 100));
        sb.Append(string.Format("{0}%\n", playerPowerData.Speed * 10 + (playerStat.Speed-1) * 100));
        sb.Append(string.Format("{0}%\n", playerPowerData.Duration * 15 + (playerStat.Duration-1) * 100));
        sb.Append(string.Format("{0}\n", playerPowerData.Amount + playerStat.Amount));
        sb.Append(string.Format("{0:0.0}%\n", playerPowerData.CoolDown * 2.5 + (playerStat.CoolDown-1)*100));
        sb.Append("\n");
        sb.Append(string.Format("{0}%\n", playerPowerData.Luck * 10 + (playerStat.Luck-1) * 100));
        sb.Append(string.Format("{0}%\n", playerPowerData.Growth * 3 + (playerStat.Growth-1) * 100));
        sb.Append(string.Format("{0}%\n", playerPowerData.Greed * 10 + (playerStat.Greed-1) * 100));
        sb.Append(string.Format("{0}%\n", playerPowerData.Magnet * 25 + (playerStat.Magnet-1) * 100));

        statText.text = sb.ToString();

        UpdateSystemData();
    }

    public void UpdateSystemData()
    {
        GameSystem.Instance.SetCharacter(character);

        PlayerPower playerPowerData = GameSystem.Instance.GetGameData();
        //GameSystem playerStatdata 수정
        PlayerStat newStat = new PlayerStat();

        newStat.MaxHealth = playerStat.MaxHealth + playerPowerData.MaxHealth * (playerStat.MaxHealth * 0.1f);
        newStat.Recovery = playerPowerData.Recovery * 0.1f + playerStat.Recovery;
        newStat.Armor = playerPowerData.Armor + playerStat.Armor;
        newStat.MoveSpeed = (playerPowerData.MoveSpeed * 0.05f * playerStat.MoveSpeed) + playerStat.MoveSpeed;
        newStat.Might = playerPowerData.Might * 0.05f + playerStat.Might;
        newStat.Area = playerPowerData.Area * 0.05f + playerStat.Area;
        newStat.Speed = playerPowerData.Speed * 0.1f + playerStat.Speed;
        newStat.Duration = playerPowerData.Duration * 0.15f + playerStat.Duration;
        newStat.Amount = playerPowerData.Amount + playerStat.Amount;
        newStat.CoolDown = playerPowerData.CoolDown * 0.025f + playerStat.CoolDown;
        newStat.Luck = playerPowerData.Luck * 0.1f + playerStat.Luck;
        newStat.Growth = playerPowerData.Growth * 0.03f + playerStat.Growth;
        newStat.Greed = playerPowerData.Greed * 0.1f + playerStat.Greed;
        newStat.Magnet = playerPowerData.Magnet * 0.25f + playerStat.Magnet;

        GameSystem.Instance.SetPlayerStatData(newStat);
    }

    void Awake()
    {
       
    }

}
