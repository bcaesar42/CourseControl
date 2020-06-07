using System;
using UnityEngine;

namespace Assets.src.View.Rooms
{
    internal static class RoomMaterialUtils
    {
        public static void ApplyDroneRoomMaterials(GameObject droneRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(droneRoom);
            ApplyMaterials(droneRoom, currentMaterials);
        }

        public static void ApplyMaintenanceRoomMaterials(GameObject maintenanceRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(maintenanceRoom);
            ApplyMaterials(maintenanceRoom, currentMaterials);
        }

        public static void ApplyMedicalRoomMaterials(GameObject medicalRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(medicalRoom);
            ApplyMaterials(medicalRoom, currentMaterials);
        }

        public static void ApplyNavigationRoomMaterials(GameObject navigationRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(navigationRoom);
            ApplyMaterials(navigationRoom, currentMaterials);
        }

        public static void ApplyReplicationRoomMaterials(GameObject replicationRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(replicationRoom);
            ApplyMaterials(replicationRoom, currentMaterials);
        }

        public static void ApplyResearchRoomMaterials(GameObject researchRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(researchRoom);
            ApplyMaterials(researchRoom, currentMaterials);
        }

        public static void ApplyScavengeRoomMaterials(GameObject scavengeRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(scavengeRoom);
            ApplyMaterials(scavengeRoom, currentMaterials);
        }

        public static void ApplyShieldRoomMaterials(GameObject shieldRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(shieldRoom);
            ApplyMaterials(shieldRoom, currentMaterials);
        }

        public static void ApplyWeaponRoomMaterials(GameObject weaponRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(weaponRoom);
            ApplyMaterials(weaponRoom, currentMaterials);
        }

        public static void ApplySensorRoomMaterials(GameObject sensorRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(sensorRoom);
            ApplyMaterials(sensorRoom, currentMaterials);
        }


        //Helper Methods
        private static void ApplyMaterials(GameObject gameObject,Material[] newMaterials)
        {
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.materials = newMaterials;
        }

        private static Material[] GetCurrentMaterials(GameObject gameObject)
        {
            return gameObject.GetComponent<MeshRenderer>().materials;
        }

        private static Material LoadMaterial(String name)
        {
            return Resources.Load<Material>("Materials/" + name);
        }
    }
}
