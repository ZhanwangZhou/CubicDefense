using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance {get; private set;}

    public TurretData standardTurretData;
    public TurretData missileTurretData;
    public TurretData laserTurretData;
    public TurretData selectedTurretData;
    
    public TextMeshProUGUI moneyText;
    private int money = 1000;

    private void Awake()
    {
        Instance = this;
    }

    public void OnStandardSelected(bool isOn)
    {
        selectedTurretData = standardTurretData;
    }
    public void OnMissileSelected(bool isOn)
    {
        selectedTurretData = missileTurretData;
    }
    public void OnLaserSelected(bool isOn)
    {
        selectedTurretData = laserTurretData;
    }

    public bool IsEnough(int moneyNeeded)
    {
        return moneyNeeded <= money;
    }

    public void ChangeMoney(int changeAmount)
    {
        this.money += changeAmount;
        moneyText.text = "$" + money.ToString();
    }

}
