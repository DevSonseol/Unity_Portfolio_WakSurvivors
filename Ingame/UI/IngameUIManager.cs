using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
    public static IngameUIManager Instance;

    [SerializeField]
    private PowerUI weaponUI;
    public PowerUI WeaponUI { get { return weaponUI; } }

    [SerializeField]
    private WeaponSelectUI weaponSelectUI;

    public WeaponSelectUI WeaponSelectUI { get { return weaponSelectUI; } }

    [SerializeField]
    private SlotMachine slotMachineUI;
    public SlotMachine SlotMachineUI { get { return slotMachineUI; } }

    [SerializeField]
    private GameEndUI gameEndUI;
    public GameEndUI GameEndUI { get { return gameEndUI; } }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //InvokeRepeating("openWS", 1f,2f);
    }

    void openWS()
    {
        weaponSelectUI.Open_WSUI();
    }


}
