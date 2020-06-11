using System;
using UnityEngine;

namespace Assets.src.View.Rooms
{
    internal class RoomMaterialUtils
    {
        public String TeamColorLight { get; } = MaterialNames.TeamBlueLight;
        public String TeamColorDark { get; } = MaterialNames.TeamBlueDark;
        public RoomMaterialUtils(String teamColorLight, String teamColorDark)
        {
            TeamColorLight = teamColorLight;
            TeamColorDark = teamColorDark;
        }


        public void ApplyDroneRoomMaterials(GameObject droneRoom)
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
            currentMaterials[15] = LoadMaterial(TeamColorLight);//Inner Logo
            currentMaterials[16] = LoadMaterial(TeamColorDark);//Outer Logo
            ApplyMaterials(droneRoom, currentMaterials);
        }

        public void ApplyMaintenanceRoomMaterials(GameObject maintenanceRoom)
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
            currentMaterials[14] = LoadMaterial(TeamColorLight);//logo inner
            currentMaterials[15] = LoadMaterial(TeamColorDark);//logo outer 
            ApplyMaterials(maintenanceRoom, currentMaterials);
        }

        public void ApplyMedicalRoomMaterials(GameObject medicalRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(medicalRoom);
            ApplyMaterials(medicalRoom, currentMaterials);
        }

        public void ApplyNavigationRoomMaterials(GameObject navigationRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(navigationRoom);
            currentMaterials[6] = LoadMaterial(TeamColorLight);
            currentMaterials[7] = LoadMaterial(TeamColorDark);
            ApplyMaterials(navigationRoom, currentMaterials);
        }

        public void ApplyReplicationRoomMaterials(GameObject replicationRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(replicationRoom);
            ApplyMaterials(replicationRoom, currentMaterials);
        }

        public void ApplyResearchRoomMaterials(GameObject researchRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(researchRoom);
            currentMaterials[1] = LoadMaterial(TeamColorDark);
            currentMaterials[2] = LoadMaterial(TeamColorLight);
            ApplyMaterials(researchRoom, currentMaterials);
        }

        public void ApplyScavengeRoomMaterials(GameObject scavengeRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(scavengeRoom);
            currentMaterials[6] = LoadMaterial(TeamColorDark);
            currentMaterials[7] = LoadMaterial(TeamColorLight);
            ApplyMaterials(scavengeRoom, currentMaterials);
        }

        public void ApplyShieldRoomMaterials(GameObject shieldRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(shieldRoom);
            currentMaterials[6] = LoadMaterial(TeamColorDark);
            currentMaterials[7] = LoadMaterial(TeamColorLight);
            ApplyMaterials(shieldRoom, currentMaterials);
        }

        public void ApplyWeaponRoomMaterials(GameObject weaponRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(weaponRoom);
            currentMaterials[6] = LoadMaterial(TeamColorDark);
            currentMaterials[7] = LoadMaterial(TeamColorLight);
            ApplyMaterials(weaponRoom, currentMaterials);
        }

        public void ApplySensorRoomMaterials(GameObject sensorRoom)
        {
            Material[] currentMaterials = GetCurrentMaterials(sensorRoom);
            currentMaterials[6] = LoadMaterial(TeamColorDark);
            currentMaterials[7] = LoadMaterial(TeamColorLight);
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
