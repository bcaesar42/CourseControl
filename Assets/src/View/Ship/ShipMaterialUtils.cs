using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.src.View.Ship
{
    public class ShipMaterialUtils
    {
        private static string TeamColor { get; set; }

        public ShipMaterialUtils(String teamColor)
        {
            TeamColor = teamColor;
        }

        public void ApplyShipMaterials(String shipName)
        {
            GameObject ship = GameObject.Find(shipName);
            MeshRenderer meshRenderer =  ship.GetComponent<MeshRenderer>();
            Material[] currentMaterials = meshRenderer.materials;
            currentMaterials[0] = LoadMaterial("MetalLight");
            currentMaterials[1] = LoadMaterial(TeamColor);
            meshRenderer.materials = currentMaterials;

        }

        private static Material LoadMaterial(String name)
        {
            return Resources.Load<Material>("Materials/" + name);
        }
    }
}
