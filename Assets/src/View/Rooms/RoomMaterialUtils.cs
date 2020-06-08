using System;
using UnityEngine;

namespace Assets.src.View.Rooms
{
    internal static class RoomMaterialUtils
    {
        public static void ApplyDroneRoomMaterials(GameObject droneRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(droneRoom);
            currentMaterials[0] = LoadMaterial(MaterialNames.MetalLight);//Chains
            currentMaterials[1] = LoadMaterial(MaterialNames.MetalLight);//Drone Inner
            currentMaterials[2] = LoadMaterial(MaterialNames.WeaponGlowRed);//Drone Eye
            currentMaterials[3] = LoadMaterial(MaterialNames.Metal);//Drone Outer
            currentMaterials[4] = LoadMaterial(MaterialNames.Metal);//Screen outer
            currentMaterials[5] = LoadMaterial(MaterialNames.Glass);//Screen Inner
            currentMaterials[6] = LoadMaterial(MaterialNames.Metal);//Table
            currentMaterials[7] = LoadMaterial(MaterialNames.MetalRed);//Gas cylinders
            currentMaterials[8] = LoadMaterial(MaterialNames.MetalLight);//Gas cylinder heads
            currentMaterials[9] = LoadMaterial(MaterialNames.Rubber);//Torch Gas Line
            currentMaterials[10] = LoadMaterial(MaterialNames.MetalLight);//Torch head
            currentMaterials[11] = LoadMaterial(MaterialNames.MetalLight);//computer body
            currentMaterials[12] = LoadMaterial(MaterialNames.ComputerScreen);//computer screen
            currentMaterials[13] = LoadMaterial(MaterialNames.Rubber);//Floor
            currentMaterials[14] = LoadMaterial(MaterialNames.MetalLight);//walls
            currentMaterials[15] = LoadMaterial(MaterialNames.TeamBlueLight);//Inner Logo
            currentMaterials[16] = LoadMaterial(MaterialNames.TeamBlueDark);//Outer Logo
            ApplyMaterials(droneRoom, currentMaterials);
        }

        public static void ApplyMaintenanceRoomMaterials(GameObject maintenanceRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(maintenanceRoom);
            currentMaterials[0] = LoadMaterial(MaterialNames.Rubber);//Piston Case Wall
            currentMaterials[1] = LoadMaterial(MaterialNames.Metal);//Piston case
            currentMaterials[2] = LoadMaterial(MaterialNames.MetalLight);//pistons
            currentMaterials[3] = LoadMaterial(MaterialNames.Metal);//screens outer
            currentMaterials[4] = LoadMaterial(MaterialNames.Glass);//screens inner
            currentMaterials[5] = LoadMaterial(MaterialNames.MetalRed);//gas cylinder bodies
            currentMaterials[6] = LoadMaterial(MaterialNames.MetalLight);//gas cylinder heads
            currentMaterials[7] = LoadMaterial(MaterialNames.Metal);//table
            currentMaterials[8] = LoadMaterial(MaterialNames.Rubber);//gas cylinder tube
            currentMaterials[9] = LoadMaterial(MaterialNames.MetalLight);//torch head
            currentMaterials[10] = LoadMaterial(MaterialNames.Metal);//computer body
            currentMaterials[11] = LoadMaterial(MaterialNames.ComputerScreen);//computer screen
            currentMaterials[12] = LoadMaterial(MaterialNames.Rubber);// floor
            currentMaterials[13] = LoadMaterial(MaterialNames.MetalLight);//walls
            currentMaterials[14] = LoadMaterial(MaterialNames.TeamBlueLight);//logo inner
            currentMaterials[15] = LoadMaterial(MaterialNames.TeamBlueDark);//logo outer 
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
