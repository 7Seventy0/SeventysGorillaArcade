using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace SeventysGorillaArcade
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        GameObject player;
        GameObject buttonRight;
        GameObject buttonLeft;
        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
        }
        ArcadeManager manager;
        void OnGameInitialized(object sender, EventArgs e)
        {
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("SeventysGorillaArcade.AssetsFolder.gorillaarcade");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);
            GameObject arcde = bundle.LoadAsset<GameObject>("Arcade");
            arcde.AddComponent<ArcadeManager>();
            manager = arcde.GetComponent<ArcadeManager>();
            manager.banana = bundle.LoadAsset<GameObject>("banana");
            manager.banana.transform.localScale = new Vector3(150, 150, 150);
            arcde = Instantiate(arcde);
            arcde.transform.position = new Vector3(-52.3331f, 16.1058f, - 119.5022f);
            arcde.transform.localEulerAngles = new Vector3(270f, 0, 0);
            arcde.transform.localScale = new Vector3(30, 30, 30);
            arcde.GetComponent<BoxCollider>().enabled = false;
            player = GameObject.Find("ArcadePlatform");
            player.AddComponent<ArcadePlayerController>();
            buttonRight = GameObject.Find("RightButton");
            buttonLeft = GameObject.Find("LeftButton");

            buttonRight.AddComponent<RightButton>();
            buttonLeft.AddComponent<LeftButton>();

            GameObject failzone = GameObject.Find("failzone");
            failzone.AddComponent<FailZone>();

            GameObject startButton = GameObject.Find("StartButton");
            startButton.AddComponent<StartButton>();

            GameObject succesParticle = bundle.LoadAsset<GameObject>("SuccesParticle");
            succesParticle.AddComponent<DestroyAfter5s>();
            player.GetComponent<ArcadePlayerController>().succesParticle = succesParticle;
        }

        void Update()
        {
            /* Code here runs every frame when the mod is enabled */
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
