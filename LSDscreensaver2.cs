using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

class LsdSwirl : Form
{
    private readonly byte[] palette = new byte[] {
        0x3f,0x00,0x3f, 0x3f,0x02,0x3d, 0x3f,0x04,0x3b, 0x3f,0x06,0x39,
        0x3f,0x08,0x37, 0x3f,0x0a,0x35, 0x3f,0x0c,0x33, 0x3f,0x0e,0x31,
        0x3f,0x10,0x2f, 0x3f,0x12,0x2d, 0x3f,0x14,0x2b, 0x3f,0x16,0x29,
        0x3f,0x18,0x27, 0x3f,0x1a,0x25, 0x3f,0x1c,0x23, 0x3f,0x1e,0x21,
        0x3f,0x20,0x1f, 0x3f,0x22,0x1d, 0x3f,0x24,0x1b, 0x3f,0x26,0x19,
        0x3f,0x28,0x17, 0x3f,0x2a,0x15, 0x3f,0x2c,0x13, 0x3f,0x2e,0x11,
        0x3f,0x30,0x0f, 0x3f,0x32,0x0d, 0x3f,0x34,0x0b, 0x3f,0x36,0x09,
        0x3f,0x38,0x07, 0x3f,0x3a,0x05, 0x3f,0x3c,0x03, 0x3f,0x3e,0x01,
        0x3f,0x3f,0x00, 0x3d,0x3f,0x02, 0x3b,0x3f,0x04, 0x39,0x3f,0x06,
        0x37,0x3f,0x08, 0x35,0x3f,0x0a, 0x33,0x3f,0x0c, 0x31,0x3f,0x0e,
        0x2f,0x3f,0x10, 0x2d,0x3f,0x12, 0x2b,0x3f,0x14, 0x29,0x3f,0x16,
        0x27,0x3f,0x18, 0x25,0x3f,0x1a, 0x23,0x3f,0x1c, 0x21,0x3f,0x1e,
        0x1f,0x3f,0x20, 0x1d,0x3f,0x22, 0x1b,0x3f,0x24, 0x19,0x3f,0x26,
        0x17,0x3f,0x28, 0x15,0x3f,0x2a, 0x13,0x3f,0x2c, 0x11,0x3f,0x2e,
        0x0f,0x3f,0x30, 0x0d,0x3f,0x32, 0x0b,0x3f,0x34, 0x09,0x3f,0x36,
        0x07,0x3f,0x38, 0x05,0x3f,0x3a, 0x03,0x3f,0x3c, 0x01,0x3f,0x3e,
        0x00,0x3f,0x3f, 0x00,0x3d,0x3f, 0x00,0x3b,0x3f, 0x00,0x39,0x3f,
        0x00,0x37,0x3f, 0x00,0x35,0x3f, 0x00,0x33,0x3f, 0x00,0x31,0x3f,
        0x00,0x2f,0x3f, 0x00,0x2d,0x3f, 0x00,0x2b,0x3f, 0x00,0x29,0x3f,
        0x00,0x27,0x3f, 0x00,0x25,0x3f, 0x00,0x23,0x3f, 0x00,0x21,0x3f,
        0x00,0x1f,0x3f, 0x00,0x1d,0x3f, 0x00,0x1b,0x3f, 0x00,0x19,0x3f,
        0x00,0x17,0x3f, 0x00,0x15,0x3f, 0x00,0x13,0x3f, 0x00,0x11,0x3f,
        0x00,0x0f,0x3f, 0x00,0x0d,0x3f, 0x00,0x0b,0x3f, 0x00,0x09,0x3f,
        0x00,0x07,0x3f, 0x00,0x05,0x3f, 0x00,0x03,0x3f, 0x00,0x01,0x3f,
        0x00,0x00,0x3f, 0x02,0x00,0x3f, 0x04,0x00,0x3f, 0x06,0x00,0x3f,
        0x08,0x00,0x3f, 0x0a,0x00,0x3f, 0x0c,0x00,0x3f, 0x0e,0x00,0x3f,
        0x10,0x00,0x3f, 0x12,0x00,0x3f, 0x14,0x00,0x3f, 0x16,0x00,0x3f,
        0x18,0x00,0x3f, 0x1a,0x00,0x3f, 0x1c,0x00,0x3f, 0x1e,0x00,0x3f,
        0x20,0x00,0x3f, 0x22,0x00,0x3f, 0x24,0x00,0x3f, 0x26,0x00,0x3f,
        0x28,0x00,0x3f, 0x2a,0x00,0x3f, 0x2c,0x00,0x3f, 0x2e,0x00,0x3f,
        0x30,0x00,0x3f, 0x32,0x00,0x3f, 0x34,0x00,0x3f, 0x36,0x00,0x3f,
        0x38,0x00,0x3f, 0x3a,0x00,0x3f, 0x3c,0x00,0x3f, 0x3f,0x00,0x3f
    };

    private readonly byte[] lookupTable = new byte[] {
        0x40,0x40,0x40,0x40,0x40,0x40,0x40,0x40,
        0x3f,0x3f,0x3f,0x3f,0x3f,0x3e,0x3e,0x3e,
        0x3e,0x3d,0x3d,0x3d,0x3c,0x3c,0x3b,0x3b,
        0x3a,0x3a,0x39,0x39,0x38,0x38,0x37,0x37,
        0x36,0x35,0x35,0x34,0x34,0x33,0x32,0x32,
        0x31,0x30,0x30,0x2f,0x2e,0x2e,0x2d,0x2c,
        0x2c,0x2b,0x2a,0x29,0x29,0x28,0x27,0x26,
        0x25,0x25,0x24,0x23,0x22,0x22,0x21,0x20,
        0x1f,0x1e,0x1e,0x1d,0x1c,0x1b,0x1b,0x1a,
        0x19,0x18,0x17,0x17,0x16,0x15,0x14,0x14,
        0x13,0x12,0x12,0x11,0x10,0x10,0x0f,0x0e,
        0x0e,0x0d,0x0c,0x0c,0x0b,0x0b,0x0a,0x09,
        0x09,0x08,0x08,0x07,0x07,0x06,0x06,0x05,
        0x05,0x05,0x04,0x04,0x03,0x03,0x03,0x02,
        0x02,0x02,0x02,0x01,0x01,0x01,0x01,0x01,
        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
    };

    private readonly Color[] colors = new Color[128];
    private readonly byte[,] colorBytes = new byte[128, 3]; // Precomputed BGR
    private byte var68a = 0;
    private byte var68b = 0;
    private byte var68c = 0;
    private byte var68d = 0;
    private byte[] vars505 = new byte[] { 2, 1, 3, 4 };
    private ushort bpVar = 0;
    private readonly Timer timer;
    private Bitmap canvas;
    private int canvasWidth = 320;
    private int canvasHeight = 200;
    private Point lastMousePosition;
    private byte[] vars = new byte[1280 * 800]; // 1280x800 color map

    public LsdSwirl()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.WindowState = FormWindowState.Maximized;
        this.BackColor = Color.Black;
        this.DoubleBuffered = true;

        Rectangle screen = Screen.PrimaryScreen.Bounds;
        int screenWidth = screen.Width;
        int screenHeight = screen.Height;

        Cursor.Position = new Point(screenWidth - 1, screenHeight - 1);
        lastMousePosition = Cursor.Position;

        float aspectRatio = (float)canvasWidth / canvasHeight;
        float screenAspectRatio = (float)screenWidth / screenHeight;

        if (screenAspectRatio > aspectRatio)
        {
            canvasHeight = screenHeight;
            canvasWidth = (int)(screenHeight * aspectRatio);
        }
        else
        {
            canvasWidth = screenWidth;
            canvasHeight = (int)(screenWidth / aspectRatio);
        }

        canvas = new Bitmap(320, 200, PixelFormat.Format24bppRgb);

        for (int i = 0; i < 128; i++)
        {
            int r = palette[i * 3 + 0] * 255 / 63;
            int g = palette[i * 3 + 1] * 255 / 63;
            int b = palette[i * 3 + 2] * 255 / 63;
            colors[i] = Color.FromArgb(r, g, b);
            colorBytes[i, 0] = (byte)b; // B
            colorBytes[i, 1] = (byte)g; // G
            colorBytes[i, 2] = (byte)r; // R
        }

        timer = new Timer();
        timer.Interval = 66; // ~15 FPS
        timer.Tick += new EventHandler(UpdateFrame);
        timer.Start();

        this.MouseMove += new MouseEventHandler(MouseMoveHandler);
        this.MouseClick += new MouseEventHandler(MouseClickHandler);
        this.KeyDown += new KeyEventHandler(KeyDownHandler);
    }

    private void MouseMoveHandler(object sender, MouseEventArgs e)
    {
        Point current = Cursor.Position;
        if (Math.Abs(current.X - lastMousePosition.X) > 5 || Math.Abs(current.Y - lastMousePosition.Y) > 5)
        {
            Application.Exit();
        }
        lastMousePosition = current;
    }

    private void MouseClickHandler(object sender, MouseEventArgs e)
    {
        Application.Exit();
    }

    private void KeyDownHandler(object sender, KeyEventArgs e)
    {
        Application.Exit();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle screen = Screen.PrimaryScreen.Bounds;
        int screenWidth = screen.Width;
        int screenHeight = screen.Height;

        int xOffset = (screenWidth - canvasWidth) / 2;
        int yOffset = (screenHeight - canvasHeight) / 2;

        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        e.Graphics.DrawImage(canvas, xOffset, yOffset, canvasWidth, canvasHeight);
        base.OnPaint(e);
    }

    private void UpdateFrame(object sender, EventArgs e)
    {
        // Update 1280x800 grid, downsample to 320x200
        BitmapData bmpData = canvas.LockBits(
            new Rectangle(0, 0, canvas.Width, canvas.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format24bppRgb
        );

        unsafe
        {
            byte* ptr = (byte*)bmpData.Scan0;
            int stride = bmpData.Stride;

            for (int y = 0; y < 800; y += 4)
            {
                for (int x = 0; x < 1280; x += 4)
                {
                    // Compute color index for 4x4 sub-grid
                    for (int dy = 0; dy < 4; dy++)
                    {
                        for (int dx = 0; dx < 4; dx++)
                        {
                            int subX = x + dx;
                            int subY = y + dy;
                            byte al = (byte)(bpVar & 0xFF);
                            al += lookupTable[subY % lookupTable.Length];
                            al += lookupTable[subX % lookupTable.Length];
                            al += lookupTable[(subY + 2) % lookupTable.Length];
                            al += lookupTable[(subX + 1) % lookupTable.Length];
                            al |= 0x80;
                            vars[subY * 1280 + subX] = (byte)(al - 128);
                        }
                    }

                    // Downsample 4x4 sub-grid to 1 pixel
                    int pixelX = x / 4;
                    int pixelY = y / 4;
                    if (pixelX < 320 && pixelY < 200)
                    {
                        int rSum = 0, gSum = 0, bSum = 0;
                        for (int dy = 0; dy < 4; dy++)
                        {
                            for (int dx = 0; dx < 4; dx++)
                            {
                                int index = vars[(y + dy) * 1280 + (x + dx)];
                                rSum += colorBytes[index, 2];
                                gSum += colorBytes[index, 1];
                                bSum += colorBytes[index, 0];
                            }
                        }
                        byte rAvg = (byte)(rSum / 16);
                        byte gAvg = (byte)(gSum / 16);
                        byte bAvg = (byte)(bSum / 16);

                        byte* row = ptr + pixelY * stride;
                        int offset = pixelX * 3;
                        row[offset + 0] = bAvg;
                        row[offset + 1] = gAvg;
                        row[offset + 2] = rAvg;
                    }

                    var68a++;
                    var68b = (byte)(var68b + 3);
                }
                var68c = (byte)(var68c + 2);
                var68d++;
            }
        }

        canvas.UnlockBits(bmpData);

        // Animation update
        bpVar--;
        byte bl = (byte)(bpVar & 0xFF);
        bl ^= (byte)((bpVar >> 8) & 0xFF);
        byte pixel = vars[799 * 1280 + 1279]; // Use grid value
        bl ^= pixel;
        bl ^= var68c;
        bl ^= var68a;
        bl = (byte)(bl + var68d);
        bl = (byte)(bl + var68b);

        if ((bl & 0x08) == 0)
        {
            int di = bl & 0x03;
            if (vars505[di] < 0xFD)
                vars505[di]++;
        }
        else
        {
            int di = bl & 0x03;
            if (vars505[di] > 0x03)
                vars505[di]--;
        }

        var68a = (byte)(var68a + vars505[0]);
        var68b = (byte)(var68b - vars505[1]);
        var68c = (byte)(var68c + vars505[2]);
        var68d = (byte)(var68d - vars505[3]);

        // Partial redraw
        Rectangle screen = Screen.PrimaryScreen.Bounds;
        int xOffset = (screen.Width - canvasWidth) / 2;
        int yOffset = (screen.Height - canvasHeight) / 2;
        Invalidate(new Rectangle(xOffset, yOffset, canvasWidth, canvasHeight));
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LsdSwirl());
    }
}