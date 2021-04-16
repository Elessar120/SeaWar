using AMVCC;
using AMVCC.Controllers;
using UnityEngine;

public class SeaWarController : AMVCC.SeaWarElement
{
        public SeaWarRefineryController refineryController;
        public SeaWarSubmarineMoveController submarineMoveController;
        public SeaWarSubmarineFightController submarineFightController;
        public SeaWarOilTankerController oilTankerController;
        public SpawnManager spawnManager;
}
