using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    private GameObject turretGO;
    private TurretData turretData;

    public GameObject buildEffect;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) return;
        TurretData selectedTD = BuildManager.Instance.selectedTurretData;
        if (selectedTD == null || selectedTD.turretPrefab == null) return;

        if (turretData != null) return;

        BuildTurret(selectedTD);
    }

    private void BuildTurret(TurretData _turretData)
    {
        if(!BuildManager.Instance.IsEnough(_turretData.cost)) return;
        BuildManager.Instance.ChangeMoney(-_turretData.cost);
        turretData = _turretData;
        turretGO = GameObject.Instantiate(_turretData.turretPrefab, transform.position, Quaternion.identity);
        GameObject soilParticle = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(soilParticle, 2);
    }
}
