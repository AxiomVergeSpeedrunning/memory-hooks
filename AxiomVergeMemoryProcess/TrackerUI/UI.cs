using System;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class UI : Form
    {
        public AxiomVergeTracker av = new AxiomVergeTracker();
        public bool connected = false;
        readonly int[] MaxCounts = { 125, 982 };
        readonly string[] areas = { "None", "Eribu", "Absu", "Zi", "Kur", "Indi", "Ukkin-Na", "Edin", "E-Kur-Mah", "Mar-Uru" };
        private static readonly int[] totalItemsCounts = { 16, 25, 15, 22, 2, 11, 16, 9, 8, 1 };
        private static readonly int[] totalScreenCounts = { 104, 154, 102, 200, 74, 90, 119, 74, 65 };

        public UI()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (connected)
            {
                av.GetData();
                Difficulty.Text = av.GameDifficulty;
                ItemCount.Text = $"{GetPercentage(av.ItemCount, MaxCounts[0])}%";
                ItemsCompleted.Visible = (GetPercentage(av.ItemCount, MaxCounts[0]) == 100) ? true : false;
                ScreenCount.Text = $"{GetPercentage(av.ScreenCount, MaxCounts[1])}%";
                MapCompleted.Visible = (GetPercentage(av.ScreenCount, MaxCounts[1]) == 100) ? true : false;
                HitPoints.Text = av.TraceHP;
                RedGooDestroyed.Text = $"{av.BubblesPopped}";
                BricksDestroyed.Text = $"{av.BlocksBroken}";
                CurrentAutoMapName.Text = $"{GetAreaName(av.AreaName)}";
                AreaItemCount.Text = $"{GetPercentage(av.ItemsCounts, totalItemsCounts)}%";
                AreaItemsCompleted.Visible = (GetPercentage(av.ItemsCounts, totalItemsCounts) == 100) ? true : false;
                AreaScreenCount.Text = $"{GetPercentage(av.ScreenCounts, totalScreenCounts)}%";
                AreaMapCompleted.Visible = (GetPercentage(av.ScreenCounts, totalScreenCounts) == 100) ? true : false;
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

        private int GetPercentage(int[] _current, int[] _total)
        {
            string area = av.AreaName;
            int i = Convert.ToInt16(area.Substring(area.Length - 1, 1)) - 1;
            double current = _current[i];
            double total = _total[i];
            double pdouble = Math.Round((current / total) * 100);
            int percent = (int)pdouble;
            return percent;
        }

        public string GetAreaName(string name)
        {
            string area = name;
            string test = areas[Convert.ToInt16(area.Substring(area.Length - 1, 1))];
            return test;
        }

        private void Connection_Click(object sender, EventArgs e)
        {
            if (av.GameProcess == null)
            {
                av.ConnectToGameProcess();
                if (av.GameProcess == null)
                {
                    return;
                }
            }
            Connection.BackgroundImage = TrackerUI.Properties.Resources.Connected;
            connected = true;
        }
    }
}
