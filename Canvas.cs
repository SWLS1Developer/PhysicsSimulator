using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Canvas : PictureBox
{
    #region Public Vars
    public Bitmap Frame
    {
        get
        {
            return FrameBmp;
        }
    }

    public int FrameRefreshRate
    {
        get { return this.FrameTimer.Interval; }
        set { this.FrameTimer.Interval = value; }
    }

    public int ClientX { get; private set; }
    public int ClientY { get; private set; }

    public int cX { get { return ClientX; } }
    public int cY { get { return ClientY; } }

    public delegate void DrawNewFrameEventHandler(ref Graphics gfx);
    public event DrawNewFrameEventHandler DrawNewFrame;
    #endregion
    #region Private Vars
    private Timer FrameTimer;
    private Graphics FrameGFX;
    private Bitmap FrameBmp;
    #endregion
    #region Constructors
    public Canvas()
    {
        FrameTimer = new Timer() { Enabled = false };
        FrameRefreshRate = 100;
        UpdateCanvas();

        this.Resize += (sender, e) =>
        {
            UpdateCanvas();
        };

        FrameTimer.Tick += (sender, e) =>
        {
            gFrame();
        };

        this.MouseMove += (sender, e) =>
        {
            ClientX = e.Location.X;
            ClientY = e.Location.Y;
        };
    }
    ~Canvas()
    {
        FrameTimer.Stop();
    }
    #endregion
    #region Private Functions
    private void gFrame()
    {
        FrameGFX.Clear(this.BackColor);
        DrawNewFrame(ref FrameGFX);
        this.Image = FrameBmp;
    }

    private void UpdateCanvas()
    {
        FrameBmp = new Bitmap(this.Width, this.Height);
        FrameGFX = Graphics.FromImage(FrameBmp);
    }
    #endregion
    #region Public Functions
    public void Start()
    {
        FrameTimer.Start();
    }

    public void Stop()
    {
        FrameTimer.Stop();
    }

    public void GenerateFrame()
    {
        gFrame();
    }
    #endregion
}
