using System;
using System.IO;
using System.Reflection;
using ICities;
using UnityEngine;
using ColossalFramework.UI;

//using ColossalManaged;
//using Assembly-CSharp;


namespace AllTilesMod
{
    public class AllTiles : IUserMod
    {
        public string Name
        {
            get { return "AllTiles"; }
        }
        public string Description
        {
            get { return "Unlock tiles that aren't directly adjacent to currently owned tiles. Modify camera. Filter areas"; }
        }
    }

    //create class for filtering out tiles based on connections, access methods to check which is which?
    //use unity interaces
    //fix visibility of tiles, free camera movement

    public class AllAreas : AreasExtensionBase
    {

        override public bool OnCanUnlockArea(int x, int z, bool originalResult)
        {


            int road = ColossalFramework.Singleton<NetManager>.instance.GetTileNodeCount(x, z, ItemClass.Service.Road, ItemClass.SubService.None);
            int train = 0;
            if (true)//train unlocked)
            {
                train = ColossalFramework.Singleton<NetManager>.instance.GetTileNodeCount(x, z, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportTrain);
            }             //stolen from GameAreaInfoPanel code, line 189            
            /*int ship = ColossalFramework.Singleton<NetManager>.instance.GetTileNodeCount(
                x, z, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportTrain);
                //stolen from GameAreaInfoPanel code, line 189*/
            //commented out ship because it is hard to use the ships
            return (road > 0 ||(train > 0));//CHECK TRAIN UNLOCKED


            //CHECK FOR IF TRAIN IS UNLOCKED BEFORE ALLOWING
            //INCREASE DEMAND IN AREA SIMILAR TO HOW DEMAND IS IN BEGINNING OF GAME?

            //ExceptionPanel panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
            //panel.SetMessage("AllAreas", "All areas available!", false);


        }
        /*public override int OnGetAreaPrice(uint ore, uint oil, uint forest, uint fertility, uint water, bool road, bool train, bool ship, bool plane, float landFlatness, int originalPrice)
        {
            areaManager.maxAreaCount = 81;
            this.tempRoad = road;
            this.tempTrain = train;
            this.tempShip = ship;
            return base.OnGetAreaPrice(ore, oil, forest, fertility, water, road, train, ship, plane, landFlatness, originalPrice);
        }*/
        override public void OnUnlockArea(int x, int z)
        {
            //DebugOutputPanel.print("area purchased");//GameAreaManager.DEFAULT_START_X);
            //DebugOutputPanel.print(GameAreaManager.DEFAULT_START_Z);
            //create list of distinct areas
            /*for (int xCor = 0; xCor < GameAreaManager.TOTAL_AREA_RESOLUTION; xCor++)
            {
                for (int zCor = 0; zCor < GameAreaManager.TOTAL_AREA_RESOLUTION; zCor++)
                {
                    areaManager.IsAreaUnlocked(xCor, zCor);
                }
            }*/
            //cam.transform.SetPositionAndRotation(managers.resource.GridToWorldPosition(x, z), Quaternion.AngleAxis(0, Vector3.left));
        }
    }
    /*public class cam : MonoBehaviour
    {
        void update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                //camera switches focus to element determined to be in detached area
                GameAreaManager.A
            }
        }
    }*/
}