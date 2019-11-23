using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TrackerLibrary
{
    public class AxiomVergeTracker
    {
        /*
        ╔══════════════╗
        ║ GAME PPROCESS ║
        ╚══════════════╝
        */
        public MemoryReader mr = new MemoryReader();
        public Process GameProcess { get => process; set => process = value; }
        private Process process;
        public long BaseAddress { get => THGame; set => THGame = value; }
        private long THGame;
        public int OffsetAddress { get => mGame; set => mGame = value; }
        private int mGame;

        /*
        ╔══════════════╗
        ║ GAME OFFSETS ║
        ╚══════════════╝
        */
        private readonly int mCurrentSave = 0xE0;
        #region "mCurrentSave Offsets"
        private readonly int mEffectiveFrames = 0xC;
        private readonly int mItems = 0x30;
        private readonly int mAutoMaps = 0x44;
        #region "mAutomaps Offsets"
        private static readonly int mScreenCounts = 0x28;
        #endregion
        private readonly int mCreaturesGlitched = 0x4C;
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

        public string GameDifficulty { get; set; }
        public int ItemCount { get; set; }
        public int ScreenCount { get; set; }
        public int TraceCurrentHP { get; set; }
        public int TraceMaxHP { get; set; }
        public string TraceHP { get; set; }
        //public int DroneCurrentHP { get; set; }
        //public int DroneMaxHP { get; set; }
        public int BubblesPopped { get; set; }
        public int BlocksBroken { get; set; }
        public string AreaName { get; set; }
        public int[] ItemsCounts { get => itemsCounts; set => itemsCounts = value; }
        private int[] itemsCounts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] ScreenCounts { get => screenCounts; set => screenCounts = value; }
        private int[] screenCounts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private static double frames = 0;
        private static int pCount = 0;
        public enum Area
        {
            Eribu,
            Absu,
            Zi,
            Kur,
            Indi,
            UkkinNa,
            Edin,
            EKurMah,
            MarUru,
            None
        }

        Dictionary<string, int> itemdb = new Dictionary<string, int>()
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
            { "VerticalSpread", (int)Area.Kur },
            { "Voranj", (int)Area.Zi },
            { "WallTrace", (int)Area.Eribu },
            { "TriCone", (int)Area.UkkinNa }
        };

        public AxiomVergeTracker()
        {
            ConnectToGameProcess();
        }

        public void ConnectToGameProcess()
        {
            GameProcess = Process.GetProcessesByName("AxiomVerge").FirstOrDefault();
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
            OffsetAddress = steam ? 0x144 : 0xB0;
            string version = steam ? "Steam" : "Epic";
        }

        public void GetData()
        {
            GameDifficulty = (mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mDifficulty) == 0) ? "Normal" : "Hard";
            ItemCount = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mItemCount);
            ScreenCount = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mScreenCount);
            TraceCurrentHP = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mHitPoints);
            TraceMaxHP = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mMaxHitPoints);
            TraceHP = $"{TraceCurrentHP}/{TraceMaxHP}";
            BubblesPopped = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mRedGooDestroyed);
            BlocksBroken = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mBricksDestroyed);
            AreaName = mr.MemoryReadString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mCurrentAutoMapName, vStringLength, vStringArray);
            GetItemCounts(ItemCount);
            GetAutoMaps();
        }

        void GetAutoMaps()
        {
            int startPosition = vListItem;
            int mapCount = mr.MemoryReadBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mAutoMaps, vCount);

            for (int i = 0; i < mapCount; i++)
            {
                int map = mr.MemoryReadListItemBytes(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mAutoMaps, vList, startPosition, mScreenCounts); 
                string area = mr.MemoryReadListItemString(GameProcess, BaseAddress, OffsetAddress, mCurrentSave, mAutoMaps, vList, startPosition, vInfo, vStringLength, vStringArray);
                int index = Convert.ToInt16(area.Substring(area.Length - 1, 1)) - 1;
                ScreenCounts[index] = map;
                startPosition += 4;
            }

        }

        void GetItemCounts(int _itemCount)
        {
            int startPosition = vListItem;

            if (pCount == _itemCount) { return; }
            else if (pCount < _itemCount)
            {
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
    }
}
