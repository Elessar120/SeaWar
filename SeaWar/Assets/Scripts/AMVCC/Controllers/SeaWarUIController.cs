using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace AMVCC.collider
{
    public class SeaWarUIController : SeaWarElement
    {
        [SerializeField] GameObject vehiclesPanel;
        [SerializeField] GameObject buildingsPanel;
        [SerializeField] private Image settingUserInfo;
        [SerializeField] private Image settingPanel;
        [SerializeField] private Image mainMenuPanel;
        private bool vehiclesPanelIsEnable;
        private bool buildingsPanelIsEnable;

        private string name;
        private float cost;
        
        private void Start()
        {

            name = gameObject.name;
            switch (name)
            {
                case "OilTankerButton":
                    cost = Application.model.oilTankerModel.cost;
                    break;
                case "SubmarineButton":
                    cost = Application.model.submarineModel.cost;

                    break;

                case "MotorBoatButton":
                    cost = Application.model.motorBoatModel.cost;

                    break;

                case "LenchButton":
                    cost = Application.model.lenchModel.cost;

                    break;

                case "RadioactiveTower":
                    cost = Application.model.radioActiveTowerModel.cost;

                    break;

                case "MagneticTower":
                    cost = Application.model.magneticTowerModel.cost;

                    break;

                case "ElectricTower":
                    cost = Application.model.electricTowerModel.cost;

                    break;

                case "Anti Air Craft":
                    cost = Application.model.antiAirCraftModel.cost;

                    break;

                case "Artillery":
                    cost = Application.model.artilleryModel.cost;

                    break;

                case "Trench":
                    cost = Application.model.trenchModel.cost;

                    break;
                

                case "Jet Fighter":
                    cost = Application.model.jetFighterModel.cost;

                    break;

                case "Helicopter":
                    cost = Application.model.helicopterModel.cost;

                    break;

                case "Frigate":
                    cost = Application.model.seaWarFrigateModel.cost;

                    break;

                case "Battleship":
                    cost = Application.model.battleshipModel.cost;
                    break;

                case "Sea Mine":
                    cost = Application.model.seaWarFrigateModel.cost;

                    break;
            }

            if (GetComponentInChildren<TextMeshProUGUI>())
            {
                GetComponentInChildren<TextMeshProUGUI>().text = cost.ToString();

            }

        }

        public void VehiclePanelShow()
        {
            vehiclesPanel.gameObject.SetActive(true);
            buildingsPanel.gameObject.SetActive(false);
            Debug.Log("VehiclePanelShow");
        }
        public void BuildingsPanelShow()
        {
            vehiclesPanel.gameObject.SetActive(false);
            buildingsPanel.gameObject.SetActive(true);
            Debug.Log("BuildingsPanelShow");

        }

        #region Main Menu UI

        public void SettingPanelShow()
        {
            mainMenuPanel.gameObject.SetActive(false);
            settingPanel.gameObject.SetActive(true);
            settingUserInfo.gameObject.SetActive(true);
        }
        

        #endregion
        
    }

}
    