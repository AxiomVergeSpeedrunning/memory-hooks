using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;


namespace TrackerLibrary
{
    public static class Extensions
    {
        public static StringContent AsJson(this object o)
            => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }

    public class Item
    {
        public string name;
        public bool isAcquired;

        public Item(string name, bool isAcquired)
        {
            this.name = name;
            this.isAcquired = isAcquired;
        }

    }

    public class AxiomVergeTracker
    {
        public MemoryReader mr = new MemoryReader();
        /*
        ╔═════════════╗
        ║ HTTP CLIENT ║
        ╚═════════════╝
        */
        #region "Http Client"
        public string Url { get => url; }
        private readonly string url = "https://api.sudra-routes.com/tracker/";
        #endregion

        /*
        ╔═══════════════╗
        ║ GAME PPROCESS ║
        ╚═══════════════╝
        */
        #region "Game Process"
        public Process GameProcess { get => process; set => process = value; }
        private Process process;
        public long BaseAddress { get => THGame; set => THGame = value; }
        private long THGame;
        public int OffsetAddress { get => mGame; set => mGame = value; }
        private int mGame;
        #endregion

        /*
        ╔══════════════╗
        ║ GAME OFFSETS ║
        ╚══════════════╝
        */
        #region "mCurrentSave Offsets"
        private readonly int mCurrentSave = 0xE0;
        private readonly int mEffectiveFrames = 0xC;
        private readonly int mItems = 0x30;
        #region "mAutomaps Offsets"
        private static readonly int mScreenCounts = 0x28;
        #endregion
        private readonly int mCreaturesGlitched = 0x4C;
        private readonly int mAutoMapDictionary = 0x5C;
        private readonly int mCurrentAutoMapName = 0x7C;
        private readonly int mDifficulty = 0x8C;
        private readonly int mScreenCount = 0x90;
        private readonly int mNumDeaths = 0x98;
        private readonly int mRedGooDestroyed = 0x9C;
        private readonly int mBricksDestroyed = 0xA0;
        private readonly int mHitPoints = 0xB0;
        private readonly int mMaxHitPoints = 0xB4;
        private readonly int mItemCount = 0xE0;
        #endregion

        /*
        ╔═════════════════╗
        ║ LIST ITEM FLAGS ║
        ╚═════════════════╝
        */
        #region "List Flags"
        private static readonly int vCount = 0xC;
        private static readonly int vList = 0x4;
        private static readonly int vListItem = 0x8;
        private static readonly int vInfo = 0x4;
        #endregion

        /*
        ╔═════════════════════╗
        ║ STRING INFO OFFSETS ║
        ╚═════════════════════╝
        */
        #region "Info Offsets"
        private static readonly int vStringLength = 0x4;
        private static readonly int vStringArray = 0x8;
        #endregion

        /*
        ╔═══════════════════╗
        ║ GET/SET VARIABLES ║
        ╚═══════════════════╝
        */
        #region "Variables, Dictionaries, and Lists"
        public double EffectiveFrames { get; set; }
        public string GameDifficulty { get; set; }
        public int ItemCount { get; set; }
        public int ItemPercent { get; set; }
        public int ScreenCount { get; set; }
        public int ScreenPercent { get; set; }
        public int TraceCurrentHP { get; set; }
        public int TraceMaxHP { get; set; }
        public string TraceHP { get; set; }
        //public int DroneCurrentHP { get; set; }
        //public int DroneMaxHP { get; set; }
        public int BubblesPopped { get; set; }
        public int BlocksBroken { get; set; }
        public int CreaturesGlitched { get; set; }
        public int NumDeaths { get; set; }
        public string AreaName { get; set; }
        public string InGameAreaName { get; set; }
        public int AreaNumber { get; set; }
        public int[] ItemsCounts { get => itemsCounts; set => itemsCounts = value; }
        private int[] itemsCounts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private readonly int[] totalItemsCounts = { 1, 16, 25, 15, 22, 2, 11, 16, 9, 8 };
        public int CurrentAreaItemPercent { get; set; }
        public int[] ScreenCounts { get => screenCounts; set => screenCounts = value; }
        private int[] screenCounts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private readonly int[] totalScreenCounts = { 0, 104, 154, 102, 200, 74, 90, 119, 74, 65 };
        public int CurrentAreaScreenPercent { get; set; }

        public int pCount = 0;
        readonly int[] MaxCounts = { 125, 982 };
        readonly string[] areas = { "Unknown", "Eribu", "Absu", "Zi", "Kur", "Indi", "Ukkin-Na", "Edin", "E-Kur-Mah", "Mar-Uru" };

        #region "Item Location Database"
        public enum Area
        {
            None,
            Eribu,
            Absu,
            Zi,
            Kur,
            Indi,
            UkkinNa,
            Edin,
            EKurMah,
            MarUru
        }

        readonly Dictionary<string, int> itemdb = new Dictionary<string, int>()
        {
            { "AddressDisruptor1", (int)Area.Absu },
            { "AddressDisruptor2", (int)Area.Kur },
            { "BlackCoat", (int)Area.UkkinNa },
            { "BreachSuppressor", (int)Area.EKurMah },
            { "DataDisruptor", (int)Area.Eribu },
            { "DataGrenade", (int)Area.Absu },
            { "DistortionField", (int)Area.Edin },
            { "Drill", (int)Area.Eribu },
            { "DroneGun", (int)Area.Kur },
            { "DroneTeleport", (int)Area.Edin },
            { "EnhancedLaunch", (int)Area.Kur },
            { "FatBeam", (int)Area.None },
            { "FireWall", (int)Area.Kur },
            { "FlameThrower", (int)Area.Eribu },
            { "GlitchBomb", (int)Area.Edin },
            { "GlitchTeleport", (int)Area.Zi },
            { "Grapple", (int)Area.Kur },
            { "HealthNode1", (int)Area.Eribu },
            { "HealthNode2", (int)Area.Absu },
            { "HealthNode3", (int)Area.Zi },
            { "HealthNode4", (int)Area.Kur },
            { "HealthNode5", (int)Area.UkkinNa },
            { "HealthNode6", (int)Area.Edin },
            { "HealthNode7", (int)Area.Edin },
            { "HealthNode8", (int)Area.MarUru },
            { "HealthNode9", (int)Area.Eribu },
            { "HealthNodeFragment1", (int)Area.Absu },
            { "HealthNodeFragment10", (int)Area.Kur },
            { "HealthNodeFragment11", (int)Area.Kur },
            { "HealthNodeFragment12", (int)Area.Kur },
            { "HealthNodeFragment13", (int)Area.Eribu },
            { "HealthNodeFragment14", (int)Area.Zi },
            { "HealthNodeFragment15", (int)Area.None },
            { "HealthNodeFragment16", (int)Area.UkkinNa },
            { "HealthNodeFragment17", (int)Area.EKurMah },
            { "HealthNodeFragment18", (int)Area.UkkinNa },
            { "HealthNodeFragment19", (int)Area.Edin },
            { "HealthNodeFragment2", (int)Area.Eribu },
            { "HealthNodeFragment20", (int)Area.Edin },
            { "HealthNodeFragment3", (int)Area.Absu },
            { "HealthNodeFragment4", (int)Area.Absu },
            { "HealthNodeFragment5", (int)Area.Zi },
            { "HealthNodeFragment6", (int)Area.Absu },
            { "HealthNodeFragment7", (int)Area.Zi },
            { "HealthNodeFragment8", (int)Area.Kur },
            { "HealthNodeFragment9", (int)Area.Kur },
            { "HeatSeeker", (int)Area.None },
            { "HighJump", (int)Area.Kur },
            { "InertialPulse", (int)Area.Absu },
            { "IonBeam", (int)Area.Kur },
            { "Kilver", (int)Area.Absu },
            { "LightningGun", (int)Area.Eribu },
            { "MultiDisruptor", (int)Area.Eribu },
            { "Note1", (int)Area.EKurMah },
            { "Note10", (int)Area.Zi },
            { "Note11", (int)Area.EKurMah },
            { "Note12", (int)Area.Kur },
            { "Note13", (int)Area.Kur },
            { "Note14", (int)Area.Absu },
            { "Note15", (int)Area.Absu },
            { "Note16", (int)Area.Absu },
            { "Note17", (int)Area.Kur },
            { "Note18", (int)Area.Edin },
            { "Note19", (int)Area.Zi },
            { "Note2", (int)Area.Eribu },
            { "Note20", (int)Area.Zi },
            { "Note21", (int)Area.MarUru },
            { "Note22", (int)Area.UkkinNa },
            { "Note23", (int)Area.UkkinNa },
            { "Note24", (int)Area.Absu },
            { "Note25", (int)Area.Indi },
            { "Note26", (int)Area.MarUru },
            { "Note27", (int)Area.Edin },
            { "Note28", (int)Area.Absu },
            { "Note3", (int)Area.EKurMah },
            { "Note4", (int)Area.Edin },
            { "Note5", (int)Area.Edin },
            { "Note6", (int)Area.MarUru },
            { "Note7", (int)Area.Absu },
            { "Note8", (int)Area.UkkinNa },
            { "Note9", (int)Area.Indi },
            { "Nova", (int)Area.Eribu },
            { "PasswordTool", (int)Area.Zi },
            { "PowerNode1", (int)Area.Eribu },
            { "PowerNode2", (int)Area.Absu },
            { "PowerNode3", (int)Area.Kur },
            { "PowerNode4", (int)Area.Kur },
            { "PowerNode5", (int)Area.Edin },
            { "PowerNode6", (int)Area.EKurMah },
            { "PowerNodeFragment1", (int)Area.Zi },
            { "PowerNodeFragment10", (int)Area.UkkinNa },
            { "PowerNodeFragment11", (int)Area.MarUru },
            { "PowerNodeFragment12", (int)Area.MarUru },
            { "PowerNodeFragment13", (int)Area.UkkinNa },
            { "PowerNodeFragment14", (int)Area.Kur },
            { "PowerNodeFragment15", (int)Area.UkkinNa },
            { "PowerNodeFragment16", (int)Area.Eribu },
            { "PowerNodeFragment17", (int)Area.Edin },
            { "PowerNodeFragment18", (int)Area.EKurMah },
            { "PowerNodeFragment2", (int)Area.Eribu },
            { "PowerNodeFragment3", (int)Area.Absu },
            { "PowerNodeFragment4", (int)Area.Absu },
            { "PowerNodeFragment5", (int)Area.Absu },
            { "PowerNodeFragment6", (int)Area.Absu },
            { "PowerNodeFragment7", (int)Area.Absu },
            { "PowerNodeFragment8", (int)Area.Zi },
            { "PowerNodeFragment9", (int)Area.Absu },
            { "RangeNode1", (int)Area.Absu },
            { "RangeNode2", (int)Area.Zi },
            { "RangeNode3", (int)Area.Edin },
            { "RangeNode4", (int)Area.Absu },
            { "RedCoat", (int)Area.EKurMah },
            { "Reflect", (int)Area.Kur },
            { "Scythe", (int)Area.MarUru },
            { "Shards", (int)Area.Edin },
            { "SizeNode1", (int)Area.Eribu },
            { "SizeNode2", (int)Area.Absu },
            { "SizeNode3", (int)Area.Zi },
            { "SizeNode4", (int)Area.MarUru },
            { "Swim", (int)Area.EKurMah },
            { "TendrilsBottom", (int)Area.Edin },
            { "TendrilsTop", (int)Area.Zi },
            { "TetheredCharge", (int)Area.Kur },
            { "TriCone", (int)Area.UkkinNa },
            { "VerticalSpread", (int)Area.Kur },
            { "Voranj", (int)Area.Zi },
            { "WallTrace", (int)Area.Eribu },
            { "WebSlicer", (int)Area.None }
        };
        #endregion

        #region "Item Database"
        public static Item addressdisruptor1 = new Item("AddressDisruptor1", false);
        public static Item addressdisruptor2 = new Item("AddressDisruptor2", false);
        public static Item blackcoat = new Item("BlackCoat", false);
        public static Item breachsuppressor = new Item("BreachSuppressor", false);
        public static Item datadisruptor = new Item("DataDisruptor", false);
        public static Item datagrenade = new Item("DataGrenade", false);
        public static Item distortionfield = new Item("DistortionField", false);
        public static Item drill = new Item("Drill", false);
        public static Item dronegun = new Item("DroneGun", false);
        public static Item droneteleport = new Item("DroneTeleport", false);
        public static Item enhancedlaunch = new Item("EnhancedLaunch", false);
        public static Item fatbeam = new Item("FatBeam", false);
        public static Item firewall = new Item("FireWall", false);
        public static Item flamethrower = new Item("FlameThrower", false);
        public static Item glitchbomb = new Item("GlitchBomb", false);
        public static Item glitchteleport = new Item("GlitchTeleport", false);
        public static Item grapple = new Item("Grapple", false);
        public static Item healthnode1 = new Item("HealthNode1", false);
        public static Item healthnode2 = new Item("HealthNode2", false);
        public static Item healthnode3 = new Item("HealthNode3", false);
        public static Item healthnode4 = new Item("HealthNode4", false);
        public static Item healthnode5 = new Item("HealthNode5", false);
        public static Item healthnode6 = new Item("HealthNode6", false);
        public static Item healthnode7 = new Item("HealthNode7", false);
        public static Item healthnode8 = new Item("HealthNode8", false);
        public static Item healthnode9 = new Item("HealthNode9", false);
        public static Item healthnodefragment1 = new Item("HealthNodeFragment1", false);
        public static Item healthnodefragment10 = new Item("HealthNodeFragment10", false);
        public static Item healthnodefragment11 = new Item("HealthNodeFragment11", false);
        public static Item healthnodefragment12 = new Item("HealthNodeFragment12", false);
        public static Item healthnodefragment13 = new Item("HealthNodeFragment13", false);
        public static Item healthnodefragment14 = new Item("HealthNodeFragment14", false);
        public static Item healthnodefragment15 = new Item("HealthNodeFragment15", false);
        public static Item healthnodefragment16 = new Item("HealthNodeFragment16", false);
        public static Item healthnodefragment17 = new Item("HealthNodeFragment17", false);
        public static Item healthnodefragment18 = new Item("HealthNodeFragment18", false);
        public static Item healthnodefragment19 = new Item("HealthNodeFragment19", false);
        public static Item healthnodefragment2 = new Item("HealthNodeFragment2", false);
        public static Item healthnodefragment20 = new Item("HealthNodeFragment20", false);
        public static Item healthnodefragment3 = new Item("HealthNodeFragment3", false);
        public static Item healthnodefragment4 = new Item("HealthNodeFragment4", false);
        public static Item healthnodefragment5 = new Item("HealthNodeFragment5", false);
        public static Item healthnodefragment6 = new Item("HealthNodeFragment6", false);
        public static Item healthnodefragment7 = new Item("HealthNodeFragment7", false);
        public static Item healthnodefragment8 = new Item("HealthNodeFragment8", false);
        public static Item healthnodefragment9 = new Item("HealthNodeFragment9", false);
        public static Item heatseeker = new Item("HeatSeeker", false);
        public static Item highjump = new Item("HighJump", false);
        public static Item inertialpulse = new Item("InertialPulse", false);
        public static Item ionbeam = new Item("IonBeam", false);
        public static Item kilver = new Item("Kilver", false);
        public static Item lightninggun = new Item("LightningGun", false);
        public static Item multidisruptor = new Item("MultiDisruptor", false);
        public static Item note1 = new Item("Note1", false);
        public static Item note10 = new Item("Note10", false);
        public static Item note11 = new Item("Note11", false);
        public static Item note12 = new Item("Note12", false);
        public static Item note13 = new Item("Note13", false);
        public static Item note14 = new Item("Note14", false);
        public static Item note15 = new Item("Note15", false);
        public static Item note16 = new Item("Note16", false);
        public static Item note17 = new Item("Note17", false);
        public static Item note18 = new Item("Note18", false);
        public static Item note19 = new Item("Note19", false);
        public static Item note2 = new Item("Note2", false);
        public static Item note20 = new Item("Note20", false);
        public static Item note21 = new Item("Note21", false);
        public static Item note22 = new Item("Note22", false);
        public static Item note23 = new Item("Note23", false);
        public static Item note24 = new Item("Note24", false);
        public static Item note25 = new Item("Note25", false);
        public static Item note26 = new Item("Note26", false);
        public static Item note27 = new Item("Note27", false);
        public static Item note28 = new Item("Note28", false);
        public static Item note3 = new Item("Note3", false);
        public static Item note4 = new Item("Note4", false);
        public static Item note5 = new Item("Note5", false);
        public static Item note6 = new Item("Note6", false);
        public static Item note7 = new Item("Note7", false);
        public static Item note8 = new Item("Note8", false);
        public static Item note9 = new Item("Note9", false);
        public static Item nova = new Item("Nova", false);
        public static Item passwordtool = new Item("PasswordTool", false);
        public static Item powernode1 = new Item("PowerNode1", false);
        public static Item powernode2 = new Item("PowerNode2", false);
        public static Item powernode3 = new Item("PowerNode3", false);
        public static Item powernode4 = new Item("PowerNode4", false);
        public static Item powernode5 = new Item("PowerNode5", false);
        public static Item powernode6 = new Item("PowerNode6", false);
        public static Item powernodefragment1 = new Item("PowerNodeFragment1", false);
        public static Item powernodefragment10 = new Item("PowerNodeFragment10", false);
        public static Item powernodefragment11 = new Item("PowerNodeFragment11", false);
        public static Item powernodefragment12 = new Item("PowerNodeFragment12", false);
        public static Item powernodefragment13 = new Item("PowerNodeFragment13", false);
        public static Item powernodefragment14 = new Item("PowerNodeFragment14", false);
        public static Item powernodefragment15 = new Item("PowerNodeFragment15", false);
        public static Item powernodefragment16 = new Item("PowerNodeFragment16", false);
        public static Item powernodefragment17 = new Item("PowerNodeFragment17", false);
        public static Item powernodefragment18 = new Item("PowerNodeFragment18", false);
        public static Item powernodefragment2 = new Item("PowerNodeFragment2", false);
        public static Item powernodefragment3 = new Item("PowerNodeFragment3", false);
        public static Item powernodefragment4 = new Item("PowerNodeFragment4", false);
        public static Item powernodefragment5 = new Item("PowerNodeFragment5", false);
        public static Item powernodefragment6 = new Item("PowerNodeFragment6", false);
        public static Item powernodefragment7 = new Item("PowerNodeFragment7", false);
        public static Item powernodefragment8 = new Item("PowerNodeFragment8", false);
        public static Item powernodefragment9 = new Item("PowerNodeFragment9", false);
        public static Item rangenode1 = new Item("RangeNode1", false);
        public static Item rangenode2 = new Item("RangeNode2", false);
        public static Item rangenode3 = new Item("RangeNode3", false);
        public static Item rangenode4 = new Item("RangeNode4", false);
        public static Item redcoat = new Item("RedCoat", false);
        public static Item reflect = new Item("Reflect", false);
        public static Item scythe = new Item("Scythe", false);
        public static Item shards = new Item("Shards", false);
        public static Item sizenode1 = new Item("SizeNode1", false);
        public static Item sizenode2 = new Item("SizeNode2", false);
        public static Item sizenode3 = new Item("SizeNode3", false);
        public static Item sizenode4 = new Item("SizeNode4", false);
        public static Item swim = new Item("Swim", false);
        public static Item tendrilsbottom = new Item("TendrilsBottom", false);
        public static Item tendrilstop = new Item("TendrilsTop", false);
        public static Item tetheredcharge = new Item("TetheredCharge", false);
        public static Item tricone = new Item("TriCone", false);
        public static Item verticalspread = new Item("VerticalSpread", false);
        public static Item voranj = new Item("Voranj", false);
        public static Item walltrace = new Item("WallTrace", false);
        public static Item webslicer = new Item("WebSlicer", false);

        public List<Item> inventorydb = new List<Item>()
        {
            addressdisruptor1,
            addressdisruptor2,
            blackcoat,
            breachsuppressor,
            datadisruptor,
            datagrenade,
            distortionfield,
            drill,
            dronegun,
            droneteleport,
            enhancedlaunch,
            fatbeam,
            firewall,
            flamethrower,
            glitchbomb,
            glitchteleport,
            grapple,
            healthnode1,
            healthnode2,
            healthnode3,
            healthnode4,
            healthnode5,
            healthnode6,
            healthnode7,
            healthnode8,
            healthnode9,
            healthnodefragment1,
            healthnodefragment10,
            healthnodefragment11,
            healthnodefragment12,
            healthnodefragment13,
            healthnodefragment14,
            healthnodefragment15,
            healthnodefragment16,
            healthnodefragment17,
            healthnodefragment18,
            healthnodefragment19,
            healthnodefragment2,
            healthnodefragment20,
            healthnodefragment3,
            healthnodefragment4,
            healthnodefragment5,
            healthnodefragment6,
            healthnodefragment7,
            healthnodefragment8,
            healthnodefragment9,
            heatseeker,
            highjump,
            inertialpulse,
            ionbeam,
            kilver,
            lightninggun,
            multidisruptor,
            note1,
            note10,
            note11,
            note12,
            note13,
            note14,
            note15,
            note16,
            note17,
            note18,
            note19,
            note2,
            note20,
            note21,
            note22,
            note23,
            note24,
            note25,
            note26,
            note27,
            note28,
            note3,
            note4,
            note5,
            note6,
            note7,
            note8,
            note9,
            nova,
            passwordtool,
            powernode1,
            powernode2,
            powernode3,
            powernode4,
            powernode5,
            powernode6,
            powernodefragment1,
            powernodefragment10,
            powernodefragment11,
            powernodefragment12,
            powernodefragment13,
            powernodefragment14,
            powernodefragment15,
            powernodefragment16,
            powernodefragment17,
            powernodefragment18,
            powernodefragment2,
            powernodefragment3,
            powernodefragment4,
            powernodefragment5,
            powernodefragment6,
            powernodefragment7,
            powernodefragment8,
            powernodefragment9,
            rangenode1,
            rangenode2,
            rangenode3,
            rangenode4,
            redcoat,
            reflect,
            scythe,
            shards,
            sizenode1,
            sizenode2,
            sizenode3,
            sizenode4,
            swim,
            tendrilsbottom,
            tendrilstop,
            tetheredcharge,
            tricone,
            verticalspread,
            voranj,
            walltrace,
            webslicer
        };
        #endregion

        #endregion

        /*
        ╔════════════════╗
        ║ ITEM VARIABLES ║
        ╚════════════════╝
        */
        #region "Items"
        public bool AddressDisruptor1 { get; set; }
        public bool AddressDisruptor2 { get; set; }
        public bool BlackCoat { get; set; }
        public bool BreachSuppressor { get; set; }
        public bool DataDisruptor { get; set; }
        public bool DataGrenade { get; set; }
        public bool DistortionField { get; set; }
        public bool Drill { get; set; }
        public bool DroneGun { get; set; }
        public bool DroneTeleport { get; set; }
        public bool EnhancedLaunch { get; set; }
        public bool FatBeam { get; set; }
        public bool FireWall { get; set; }
        public bool FlameThrower { get; set; }
        public bool GlitchBomb { get; set; }
        public bool GlitchTeleport { get; set; }
        public bool Grapple { get; set; }
        public bool Heatseeker { get; set; }
        public bool HighJump { get; set; }
        public bool InertialPulse { get; set; }
        public bool IonBeam { get; set; }
        public bool Kilver { get; set; }
        public bool LightningGun { get; set; }
        public bool MultiDisruptor { get; set; }
        public bool Nova { get; set; }
        public bool PasswordTool { get; set; }
        public bool RedCoat { get; set; }
        public bool Reflect { get; set; }
        public bool WebSlicer { get; set; }
        public bool Scythe { get; set; }
        public bool Shards { get; set; }
        public bool Swim { get; set; }
        public bool TendrilsBottom { get; set; }
        public bool TendrilsTop { get; set; }
        public bool TetheredCharge { get; set; }
        public bool VerticalSpread { get; set; }
        public bool Voranj { get; set; }
        public bool WallTrace { get; set; }
        public bool TriCone { get; set; }
        public int HNodeCount { get; set; }
        public int PNodeCount { get; set; }
        public int HNodeFCount { get; set; }
        public int PNodeFCount { get; set; }
        public int SizeNodeCount { get; set; }
        public int RangeNodeCount { get; set; }
        public int NoteCount { get; set; }
        public string LastItem { get; set; }

        #endregion

        #region "CONNECT TO GAME PROCESS"
        public AxiomVergeTracker(){
        }
        public void ConnectToGameProcess(string _processName)
        {
            bool vanilla = (_processName == "AxiomVerge") ? true : false;
            GameProcess = Process.GetProcessesByName(_processName).FirstOrDefault();
            if (GameProcess is null) { return; }

            ProcessModuleWow64Safe[] modules = GameProcess.ModulesWow64Safe();
            bool steam = GameProcess.ModulesWow64Safe().Any(m => m.ModuleName == "steam_api.dll");

            SigScanTarget pattern = new SigScanTarget(0, "?? ?? ?? ?? 04 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? F8 07 00 00");

            foreach (var page in GameProcess.MemoryPages())
            {
                SignatureScanner scanner = new SignatureScanner(GameProcess, page.BaseAddress, (int)page.RegionSize);
                IntPtr ptr = scanner.Scan(pattern, 0x4);

                if (ptr != IntPtr.Zero)
                {
                    BaseAddress = (long)ptr;
                    break;
                }
            }
            if (vanilla) { OffsetAddress = steam ? 0x144 : 0xB0; }
            else { OffsetAddress = steam ? 0x50 : 0x24; }
        }
        #endregion

        #region "HTTP CLIENT"
        public void PostData(string _token)
        {

            var _items = new
            {
                LastItem,
                HNodeCount,
                PNodeCount,
                HNodeFCount,
                PNodeFCount,
                SizeNodeCount,
                RangeNodeCount,
                NoteCount,
                AddressDisruptor1 = addressdisruptor1.isAcquired,
                AddressDisruptor2 = addressdisruptor2.isAcquired,
                BlackCoat = blackcoat.isAcquired,
                BreachSuppressor = breachsuppressor.isAcquired,
                DataDisruptor = datadisruptor.isAcquired,
                DataGrenade = datagrenade.isAcquired,
                DistortionField = distortionfield.isAcquired,
                Drill = drill.isAcquired,
                DroneGun = dronegun.isAcquired,
                DroneTeleport = droneteleport.isAcquired,
                EnhancedLaunch = enhancedlaunch.isAcquired,
                FatBeam = fatbeam.isAcquired,
                FireWall = firewall.isAcquired,
                FlameThrower = flamethrower.isAcquired,
                GlitchBomb = glitchbomb.isAcquired,
                GlitchTeleport = glitchteleport.isAcquired,
                Grapple = grapple.isAcquired,
                Heatseeker = heatseeker.isAcquired,
                HighJump = highjump.isAcquired,
                InertialPulse = inertialpulse.isAcquired,
                IonBeam = ionbeam.isAcquired,
                Kilver = kilver.isAcquired,
                LightningGun = lightninggun.isAcquired,
                MultiDisruptor = multidisruptor.isAcquired,
                Nova = nova.isAcquired,
                PasswordTool = passwordtool.isAcquired,
                RedCoat = redcoat.isAcquired,
                Reflect = reflect.isAcquired,
                Scythe = scythe.isAcquired,
                Shards = shards.isAcquired,
                Swim = swim.isAcquired,
                TendrilsBottom = tendrilsbottom.isAcquired,
                TendrilsTop = tendrilstop.isAcquired,
                TetheredCharge = tetheredcharge.isAcquired,
                TriCone = tricone.isAcquired,
                VerticalSpread = verticalspread.isAcquired,
                Voranj = voranj.isAcquired,
                WallTrace = walltrace.isAcquired,
                WebSlicer = webslicer.isAcquired,
            };

            var _stats = new
            {
                ItemsInfo = _items,
                GameDifficulty,
                InGameAreaName,
                AreaNumber,
                ItemPercent,
                ScreenPercent,
                TraceCurrentHP,
                TraceMaxHP,
                BubblesPopped,
                BlocksBroken,
                CreaturesGlitched,
                NumDeaths,
                CurrentAreaItemPercent,
                CurrentAreaScreenPercent,
            };

            var json = new JavaScriptSerializer().Serialize(_stats);
            HttpPost(_token, json);
        }

        public async void HttpPost(string _token, string json)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _token);
                Console.WriteLine(client.ToString());
                using (HttpResponseMessage response = await client.PostAsync(Url + "store/", json.AsJson()))
                {
                    Console.WriteLine(response.ToString());
                    using (HttpContent content = response.Content)
                    {
                        Console.WriteLine(content.ToString());
                        string myContent = await content.ReadAsStringAsync();
                        Console.WriteLine(myContent.ToString());
                        HttpContentHeaders headers = content.Headers;
                        Console.WriteLine(headers.ToString());
                    }
                }
            }
        }
        #endregion

        #region "GET GAME DATA INFORMATION"
        public void GetData()
        {
            EffectiveFrames = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mEffectiveFrames);
            GameDifficulty = (mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mDifficulty) == 0) ? "Normal" : "Hard";
            AreaName = mr.MemoryReadString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mCurrentAutoMapName, vStringLength, vStringArray);
            AreaNumber = Convert.ToInt32(AreaName.Substring(AreaName.Length - 1, 1));
            ItemCount = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mItemCount);
            ItemPercent = GetPercentage(ItemCount, MaxCounts[0]);
            ScreenCount = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mScreenCount);
            ScreenPercent = GetPercentage(ScreenCount, MaxCounts[1]);
            TraceCurrentHP = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mHitPoints);
            TraceMaxHP = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mMaxHitPoints);
            TraceHP = $"{TraceCurrentHP}/{TraceMaxHP}";
            BubblesPopped = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mRedGooDestroyed);
            BlocksBroken = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mBricksDestroyed);
            CreaturesGlitched = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mCreaturesGlitched, vCount);
            NumDeaths = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mNumDeaths);
            InGameAreaName = GetAreaName();
            GetItemCounts(ItemCount);
            CurrentAreaItemPercent = GetPercentage(ItemsCounts[AreaNumber], totalItemsCounts[AreaNumber]);
            GetAutoMaps();
            CurrentAreaScreenPercent = GetPercentage(ScreenCounts[AreaNumber], totalScreenCounts[AreaNumber]);
            GetItems(ItemCount);
            int[] MiscCounts = GetMisc(ItemCount);
            HNodeCount = MiscCounts[0];
            PNodeCount = MiscCounts[1];
            HNodeFCount = MiscCounts[2];
            PNodeFCount = MiscCounts[3];
            NoteCount = MiscCounts[4];
            SizeNodeCount = MiscCounts[5];
            RangeNodeCount = MiscCounts[6];
            LastItem = GetLastItem(ItemCount);
        }

        void GetItemCounts(int _itemCount)
        {
            int startPosition = vListItem;

            if (pCount == _itemCount) { return; }

            else if (pCount < _itemCount)
            {
                Array.Clear(ItemsCounts, 0, ItemsCounts.Length);
                for (int i = 0; i < _itemCount; i++)
                {
                    var item = mr.MemoryReadListItemString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mItems, vList, startPosition, vInfo, vStringLength, vStringArray);
                    foreach (KeyValuePair<string, int> Item in itemdb)
                    {
                        if (Item.Key == item)
                        {
                            ItemsCounts[Item.Value]++;
                        }
                    }
                    startPosition += 4;
                }
                pCount = _itemCount;
            }
        }

        void GetAutoMaps()
        {
            int startPosition = 0xC;
            int mapCount = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mAutoMapDictionary, 0x8, 0x4);

            for (int i = 0; i < mapCount; i++)
            {
                var _current = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mAutoMapDictionary, 0x8, startPosition);
                if (_current == 0)
                {
                    continue;
                }
                int map = mr.MemoryReadListItemBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mAutoMapDictionary, 0x8, startPosition, mScreenCounts);
                string area = mr.MemoryReadListItemString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mAutoMapDictionary, 0x8, startPosition, vInfo, vStringLength, vStringArray);
                int index = Convert.ToInt32(area.Substring(area.Length - 1, 1));
                ScreenCounts[index] = map;
                startPosition += 0x10;
            }

        }

        public void GetItems(int _itemCount)
        {
            int startPosition = vListItem;
            for (int i = 0; i < _itemCount; i++)
            {
                var item = mr.MemoryReadListItemString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mItems, vList, startPosition, vInfo, vStringLength, vStringArray);
                foreach (Item _Item in inventorydb)
                {
                    if (_Item.name == item) { _Item.isAcquired = true; break; }
                }
                startPosition += 4;
            }
        }

        public int[] GetMisc(int _itemCount)
        {
            int startPosition = vListItem;
            int[] _MiscCount = { 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < _itemCount + 1; i++)
            {
                var item = mr.MemoryReadListItemString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mItems, vList, startPosition, vInfo, vStringLength, vStringArray);
                switch (item)
                {
                    case "HealthNode1":
                    case "HealthNode2":
                    case "HealthNode3":
                    case "HealthNode4":
                    case "HealthNode5":
                    case "HealthNode6":
                    case "HealthNode7":
                    case "HealthNode8":
                    case "HealthNode9":
                        _MiscCount[0]++;
                        break;
                    case "PowerNode1":
                    case "PowerNode2":
                    case "PowerNode3":
                    case "PowerNode4":
                    case "PowerNode5":
                    case "PowerNode6":
                        _MiscCount[1]++;
                        break;
                    case "HealthNodeFragment1":
                    case "HealthNodeFragment2":
                    case "HealthNodeFragment3":
                    case "HealthNodeFragment4":
                    case "HealthNodeFragment5":
                    case "HealthNodeFragment6":
                    case "HealthNodeFragment7":
                    case "HealthNodeFragment8":
                    case "HealthNodeFragment9":
                    case "HealthNodeFragment10":
                    case "HealthNodeFragment11":
                    case "HealthNodeFragment12":
                    case "HealthNodeFragment13":
                    case "HealthNodeFragment14":
                    case "HealthNodeFragment15":
                    case "HealthNodeFragment16":
                    case "HealthNodeFragment17":
                    case "HealthNodeFragment18":
                    case "HealthNodeFragment19":
                    case "HealthNodeFragment20":
                        _MiscCount[2]++;
                        break;
                    case "PowerNodeFragment1":
                    case "PowerNodeFragment2":
                    case "PowerNodeFragment3":
                    case "PowerNodeFragment4":
                    case "PowerNodeFragment5":
                    case "PowerNodeFragment6":
                    case "PowerNodeFragment7":
                    case "PowerNodeFragment8":
                    case "PowerNodeFragment9":
                    case "PowerNodeFragment10":
                    case "PowerNodeFragment11":
                    case "PowerNodeFragment12":
                    case "PowerNodeFragment13":
                    case "PowerNodeFragment14":
                    case "PowerNodeFragment15":
                    case "PowerNodeFragment16":
                    case "PowerNodeFragment17":
                    case "PowerNodeFragment18":
                        _MiscCount[3]++;
                        break;
                    case "Note1":
                    case "Note2":
                    case "Note3":
                    case "Note4":
                    case "Note5":
                    case "Note6":
                    case "Note7":
                    case "Note8":
                    case "Note9":
                    case "Note10":
                    case "Note11":
                    case "Note12":
                    case "Note13":
                    case "Note14":
                    case "Note15":
                    case "Note16":
                    case "Note17":
                    case "Note18":
                    case "Note19":
                    case "Note20":
                    case "Note21":
                    case "Note22":
                    case "Note23":
                    case "Note24":
                    case "Note25":
                    case "Note26":
                    case "Note27":
                    case "Note28":
                        _MiscCount[4]++;
                        break;
                    case "SizeNode1":
                    case "SizeNode2":
                    case "SizeNode3":
                    case "SizeNode4":
                        _MiscCount[5]++;
                        break;
                    case "RangeNode1":
                    case "RangeNode2":
                    case "RangeNode3":
                    case "RangeNode4":
                        _MiscCount[6]++;
                        break;

                }
                startPosition += 4;
            }
            return _MiscCount;
        }

        public string GetLastItem(int _itemCount)
        {
            int lastPosition = (_itemCount <= 1) ? 0x8 : 0x8 + (0x4 * (_itemCount - 1));
            var item = mr.MemoryReadListItemString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mItems, vList, lastPosition, vInfo, vStringLength, vStringArray);
            switch (item)
            {
                #region "Health Nodes"
                case "HealthNode1":
                case "HealthNode2":
                case "HealthNode3":
                case "HealthNode4":
                case "HealthNode5":
                case "HealthNode6":
                case "HealthNode7":
                case "HealthNode8":
                case "HealthNode9":
                    return "HealthNode";
                case "HealthNodeFragment1":
                case "HealthNodeFragment2":
                case "HealthNodeFragment3":
                case "HealthNodeFragment4":
                case "HealthNodeFragment5":
                case "HealthNodeFragment6":
                case "HealthNodeFragment7":
                case "HealthNodeFragment8":
                case "HealthNodeFragment9":
                case "HealthNodeFragment10":
                case "HealthNodeFragment11":
                case "HealthNodeFragment12":
                case "HealthNodeFragment13":
                case "HealthNodeFragment14":
                case "HealthNodeFragment15":
                case "HealthNodeFragment16":
                case "HealthNodeFragment17":
                case "HealthNodeFragment18":
                case "HealthNodeFragment19":
                case "HealthNodeFragment20":
                    return "HealthNodeFragment";
                #endregion
                #region "Power Nodes"
                case "PowerNode1":
                case "PowerNode2":
                case "PowerNode3":
                case "PowerNode4":
                case "PowerNode5":
                case "PowerNode6":
                    return "PowerNode";
                case "PowerNodeFragment1":
                case "PowerNodeFragment2":
                case "PowerNodeFragment3":
                case "PowerNodeFragment4":
                case "PowerNodeFragment5":
                case "PowerNodeFragment6":
                case "PowerNodeFragment7":
                case "PowerNodeFragment8":
                case "PowerNodeFragment9":
                case "PowerNodeFragment10":
                case "PowerNodeFragment11":
                case "PowerNodeFragment12":
                case "PowerNodeFragment13":
                case "PowerNodeFragment14":
                case "PowerNodeFragment15":
                case "PowerNodeFragment16":
                case "PowerNodeFragment17":
                case "PowerNodeFragment18":
                    return "PowerNodeFragment";
                #endregion
                #region "Size Nodes"
                case "SizeNode1":
                case "SizeNode2":
                case "SizeNode3":
                case "SizeNode4":
                    return "SizeNode";
                #endregion
                #region "Range Nodes"
                case "RangeNode1":
                case "RangeNode2":
                case "RangeNode3":
                case "RangeNode4":
                    return "RangeNode";
                #endregion
                #region "Notes"
                case "Note1":
                case "Note2":
                case "Note3":
                case "Note4":
                case "Note5":
                case "Note6":
                case "Note7":
                case "Note8":
                case "Note9":
                case "Note10":
                case "Note11":
                case "Note12":
                case "Note13":
                case "Note14":
                case "Note15":
                case "Note16":
                case "Note17":
                case "Note18":
                case "Note19":
                case "Note20":
                case "Note21":
                case "Note22":
                case "Note23":
                case "Note24":
                case "Note25":
                case "Note26":
                case "Note27":
                case "Note28":
                    return "Note";
                #endregion
                default:
                    return item;
            }
        }

        private int GetPercentage(int _current, int _total)
        {
            double current = _current;
            double total = _total;
            double pdouble = Math.Round((current / total) * 100);
            int percent = (int)pdouble;
            return percent;
        }

        public string GetAreaName()
        {
            int i = AreaNumber;
            if (i < 1 || i > 9) { return areas[0]; }
            return areas[AreaNumber];
        }
        #endregion

        #region "RESET FUNCTIONS"
        public void ResetArrays()
        {
            Array.Clear(ScreenCounts, 0, ScreenCounts.Length);
            Array.Clear(ItemsCounts, 0, ItemsCounts.Length);
        }

        public void ResetPCount()
        {
            pCount = 0;
        }

        public void ResetItems()
        {
            foreach (Item _Item in inventorydb) { _Item.isAcquired = false; }
        }
        #endregion
    }
}
