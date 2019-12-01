using System;
using System.Windows.Forms;
using TrackerLibrary;
using Microsoft.VisualBasic;

namespace TrackerUI
{
    public partial class UI : Form
    {
        public AxiomVergeTracker av;
        public bool connected = false;
        public bool Debug { get; set; }
        public UI()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Token == "")
            {
                string input = Interaction.InputBox("Please enter your Auth Token:", "Axiom Verge Tracker", "Token", -1, -1);
                Properties.Settings.Default.Token = input;
                Properties.Settings.Default.Save();
            }
            if (System.Diagnostics.Debugger.IsAttached){ Debug = true; } else { Debug = false; }
            if (Debug) { pingTestToolStripMenuItem.Visible = true; }
        }

        private void TrackerTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (connected == false) { return; }
                if (av.GameProcess.HasExited) { Disconnect(); }
                if (connected)
                {
                    if (av.EffectiveFrames == 0 || av.ItemCount < av.pCount) { av.ResetArrays(); av.ResetPCount(); av.ResetItems(); }
                    av.GetData();
                    Difficulty.Text = av.GameDifficulty;
                    ItemCount.Text = $"{av.ItemPercent}%";
                    ItemsCompleted.Visible = (av.ItemPercent == 100) ? true : false;
                    ScreenCount.Text = $"{av.ScreenPercent}%";
                    MapCompleted.Visible = (av.ScreenPercent == 100) ? true : false;
                    HitPoints.Text = av.TraceHP;
                    RedGooDestroyed.Text = $"{av.BubblesPopped}";
                    BricksDestroyed.Text = $"{av.BlocksBroken}";
                    CreaturesGlitched.Text = $"{av.CreaturesGlitched}";
                    NumDeaths.Text = $"{av.NumDeaths}";
                    CurrentAutoMapName.Text = $"{av.InGameAreaName}";
                    AreaItemCount.Text = $"{av.CurrentAreaItemPercent}%";
                    AreaItemsCompleted.Visible = (av.CurrentAreaItemPercent == 100) ? true : false;
                    AreaScreenCount.Text = $"{av.CurrentAreaScreenPercent}%";
                    AreaMapCompleted.Visible = (av.CurrentAreaScreenPercent == 100) ? true : false;
                }
            }
            catch { }
            
        }

        private void PostTimer_Tick(object sender, EventArgs e)
        {
            if (connected) { av.PostData(Properties.Settings.Default.Token); }
            else { return; }
        }

        void Connect(string _processName)
        {
            if (connected == false)
            {
                av.ConnectToGameProcess(_processName);
                if (av.GameProcess == null) { av = null;  return; }
                Connection.BackgroundImage = TrackerUI.Properties.Resources.Connected;
                connected = true;
                TrackerTimer.Start();
                PostTimer.Start();
            }
            else { return; }
        }

        void Disconnect()
        {
            if (connected)
            {
                av = null;
                Connection.BackgroundImage = TrackerUI.Properties.Resources.Disconnected;
                connected = false;
                TrackerTimer.Stop();
                Reset();
                //PostTimer.Stop();
            }
            else { return; }
        }

        void Reset()
        {
            ItemsCompleted.Visible = false;
            MapCompleted.Visible = false;
            AreaItemsCompleted.Visible = false;
            AreaMapCompleted.Visible = false;
            Difficulty.Text = "null";
            ItemCount.Text = "null";
            ScreenCount.Text = "null";
            HitPoints.Text = "null";
            RedGooDestroyed.Text = "null";
            BricksDestroyed.Text = "null";
            CreaturesGlitched.Text = "null";
            NumDeaths.Text = "null";
            CurrentAutoMapName.Text = "Area";
            AreaItemCount.Text = "null";
            AreaScreenCount.Text = "null";
            
        }
        private void DebugLabel_Click(object sender, EventArgs e)
        {
            return;
            //av.PostData(Properties.Settings.Default.Token);
        }

        private void ResetTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Please enter your Auth Token:", "Axiom Verge Tracker", "Token", -1, -1);
            Properties.Settings.Default.Token = input;
            Properties.Settings.Default.Save();
        }

        private void ConnectVanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected == false) { av = new AxiomVergeTracker(); Connect("AxiomVerge"); }
                else { return; }
            }
            catch { }
        }

        private void ConnectRandomizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected == false) { av = new AxiomVergeTracker(); Connect("RandomAV"); }
                else { return; }
            }
            catch { }
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected == true) { Disconnect(); }
                else { return; }
            }
            catch { }
        }

        private void PingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            av = new AxiomVergeTracker();
            av.ConnectToGameProcess("AxiomVerge");
            av.PostData(Properties.Settings.Default.Token);
            av = null;
        }
    }
}
