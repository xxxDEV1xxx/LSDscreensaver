using System;
using System.Drawing;
using System.Windows.Forms;

class LsdSwirl : Form
{
    // Palette from assembly (0x026C–0x03EC), 128 colors, 6-bit RGB
    private readonly byte[] palette = new byte[] {
        0x3F,0x00,0x3F, 0x3F,0x02,0x3D, 0x3F,0x04,0x3B, 0x3F,0x06,0x39,
        0x3F,0x08,0x37, 0x3F,0x0A,0x35, 0x3F,0x0C,0x33, 0x3F,0x0E,0x31,
        0x3F,0x10,0x2F, 0x3F,0x12,0x2D, 0x3F,0x14,0x2B, 0x3F,0x16,0x29,
        0x3F,0x18,0x27, 0x3F,0x1A,0x25, 0x3F,0x1C,0x23, 0x3F,0x1E,0x21,
        0x3F,0x20,0x1F, 0x3F,0x22,0x1D, 0x3F,0x24,0x1B, 0x3F,0x26,0x19,
        0x3F,0x28,0x17, 0x3F,0x2A,0x15, 0x3F,0x2C,0x13, 0x3F,0x2E,0x11,
        0x3F,0x30,0x0F, 0x3F,0x32,0x0D, 0x3F,0x34,0x0B, 0x3F,0x36,0x09,
        0x3F,0x38,0x07, 0x3F,0x3A,0x05, 0x3F,0x3C,0x03, 0x3F,0x3E,0x01,
        0x3F,0x3F,0x00, 0x3D,0x3F,0x02, 0x3B,0x3F,0x04, 0x39,0x3F,0x06,
        0x37,0x3F,0x08, 0x35,0x3F,0x0A, 0x33,0x3F,0x0C, 0x31,0x3F,0x0E,
        0x2F,0x3F,0x10, 0x2D,0x3F,0x12, 0x2B,0x3F,0x14, 0x29,0x3F,0x16,
        0x27,0x3F,0x18, 0x25,0x3F,0x1A, 0x23,0x3F,0x1C, 0x21,0x3F,0x1E,
        0x1F,0x3F,0x20, 0x1D,0x3F,0x22, 0x1B,0x3F,0x24, 0x19,0x3F,0x26,
        0x17,0x3F,0x28, 0x15,0x3F,0x2A, 0x13,0x3F,0x2C, 0x11,0x3F,0x2E,
        0x0F,0x3F,0x30, 0x0D,0x3F,0x32, 0x0B,0x3F,0x34, 0x09,0x3F,0x36,
        0x07,0x3F,0x38, 0x05,0x3F,0x3A, 0x03,0x3F,0x3C, 0x01,0x3F,0x3E,
        0x00,0x3F,0x3F, 0x00,0x3D,0x3F, 0x00,0x3B,0x3F, 0x00,0x39,0x3F,
        0x00,0x37,0x3F, 0x00,0x35,0x3F, 0x00,0x33,0x3F, 0x00,0x31,0x3F,
        0x00,0x2F,0x3F, 0x00,0x2D,0x3F, 0x00,0x2B,0x3F, 0x00,0x29,0x3F,
        0x00,0x27,0x3F, 0x00,0x25,0x3F, 0x00,0x23,0x3F, 0x00,0x21,0x3F,
        0x00,0x1F,0x3F, 0x00,0x1D,0x3F, 0x00,0x1B,0x3F, 0x00,0x19,0x3F,
        0x00,0x17,0x3F, 0x00,0x15,0x3F, 0x00,0x13,0x3F, 0x00,0x11,0x3F,
        0x00,0x0F,0x3F, 0x00,0x0D,0x3F, 0x00,0x0B,0x3F, 0x00,0x09,0x3F,
        0x00,0x07,0x3F, 0x00,0x05,0x3F, 0x00,0x03,0x3F, 0x00,0x01,0x3F,
        0x00,0x00,0x3F, 0x02,0x00,0x3F, 0x04,0x00,0x3F, 0x06,0x00,0x3F,
        0x08,0x00,0x3F, 0x0A,0x00,0x3F, 0x0C,0x00,0x3F, 0x0E,0x00,0x3F,
        0x10,0x00,0x3F, 0x12,0x00,0x3F, 0x14,0x00,0x3F, 0x16,0x00,0x3F,
        0x18,0x00,0x3F, 0x1A,0x00,0x3F, 0x1C,0x00,0x3F, 0x1E,0x00,0x3F,
        0x20,0x00,0x3F, 0x22,0x00,0x3F, 0x24,0x00,0x3F, 0x26,0x00,0x3F,
        0x28,0x00,0x3F, 0x2A,0x00,0x3F, 0x2C,0x00,0x3F, 0x2E,0x00,0x3F,
        0x30,0x00,0x3F, 0x32,0x00,0x3F, 0x34,0x00,0x3F, 0x36,0x00,0x3F,
        0x38,0x00,0x3F, 0x3A,0x00,0x3F, 0x3C,0x00,0x3F, 0x3F,0x00,0x3F
    };

    // Lookup table from assembly (0x0128–0x01A7), used for color index calculations
    private readonly byte[] lookupTable = new byte[] {
        0x40,0x40,0x40,0x40,0x40,0x40,0x40,0x40,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3E,0x3E,0x3E,
        0x3E,0x3D,0x3D,0x3D,0x3C,0x3C,0x3B,0x3B,
        0x3A,0x3A,0x39,0x39,0x38,0x38,0x37,0x37,
        0x36,0x35,0x35,0x34,0x34,0x33,0x32,0x32,
        0x31,0x30,0x30,0x2F,0x2E,0x2E,0x2D,0x2C,
        0x2C,0x2B,0x2A,0x29,0x29,0x28,0x27,0x26,
        0x25,0x25,0x24,0x23,0x22,0x22,0x21,0x20,
        0x1F,0x1E,0x1E,0x1D,0x1C,0x1B,0x1B,0x1A,
        0x19,0x18,0x17,0x17,0x16,0x15,0x14,0x14,
        0x13,0x12,0x12,0x11,0x10,0x10,0x0F,0x0E,
        0x0E,0x0D,0x0C,0x0C,0x0B,0x0B,0x0A,0x09,
        0x09,0x08,0x08,0x07,0x07,0x06,0x06,0x05,
        0x05,0x05,0x04,0x04,0x03,0x03,0x03,0x02,
        0x02,0x02,0x02,0x01,0x01,0x01,0x01,0x01,
        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
    };

    private readonly Color[] colors = new Color[128];
    private byte var68a; // Maps to DL (X coordinate, [068Ah])
    private byte var68b; // Maps to DH (Y coordinate, [068Bh])
    private byte var68c; // Maps to CL (counter, [068Ch])
    private byte var68d; // Maps to CH (counter, [068Dh])
    private byte[] vars505 = new byte[] { 2, 1, 3, 4 }; // Maps to [0505h]–[0508h]
    private ushort bpVar; // Maps to BP
    private readonly Timer timer;
    private Bitmap canvas;
    private int canvasWidth = 320;
    private int canvasHeight = 200;
    private Point lastMousePosition;
    private Random mockTimer; // Mock BIOS timer for [068Ch], [068Dh]

    public LsdSwirl()
    {
        // Set up form for full-screen
        this.FormBorderStyle = FormBorderStyle.None; // Borderless
        this.WindowState = FormWindowState.Maximized; // Full-screen
        this.BackColor = Color.Black;
        this.DoubleBuffered = true; // Enable double-buffering

        // Get screen resolution
        Rectangle screen = Screen.PrimaryScreen.Bounds;
        int screenWidth = screen.Width;
        int screenHeight = screen.Height;

        // Move cursor to bottom-right corner
        Cursor.Position = new Point(screenWidth - 1, screenHeight - 1);
        lastMousePosition = Cursor.Position;

        // Calculate scaling factor to maintain 320x200 aspect ratio (1.6)
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

        // Initialize canvas (320x200 for 1x1 pixels)
        canvas = new Bitmap(320, 200);

        // Convert palette to Colors (6-bit to 8-bit)
        for (int i = 0; i < 128; i++)
        {
            int r = palette[i * 3 + 0] * 255 / 63; // Scale 0-63 to 0-255
            int g = palette[i * 3 + 1] * 255 / 63;
            int b = palette[i * 3 + 2] * 255 / 63;
            colors[i] = Color.FromArgb(r, g, b);
        }

        // Initialize mock BIOS timer (seeded with system time)
        mockTimer = new Random(Environment.TickCount);

        // Initialize variables with mock timer values
        var68c = (byte)mockTimer.Next(0, 256); // [068Ch]
        var68d = (byte)mockTimer.Next(0, 256); // [068Dh]
        var68a = (byte)mockTimer.Next(0, 256); // [068Ah]
        var68b = (byte)mockTimer.Next(0, 256); // [068Bh]
        bpVar = (ushort)((var68c | (var68d << 8))); // BP = BX (0x0067)

        // Set up timer (~60 FPS to match VGA retrace)
        timer = new Timer();
        timer.Interval = 16; // 1000ms / 60fps ≈ 16ms
        timer.Tick += new EventHandler(UpdateFrame);
        timer.Start();

        // Input handlers for exit
        this.KeyDown += new KeyEventHandler(KeyDownHandler);
    }

    private void KeyDownHandler(object sender, KeyEventArgs e)
    {
        // Mimic assembly's exit on any keypress (0x00D1)
        Application.Exit();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Center the scaled canvas
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
        // Emulate assembly's pixel movement loop (0x004E–0x00D7)
        int di = 0; // Maps to DI (video memory offset, 0x004E)
        byte ah = 0x50; // Maps to AH (outer counter, 0x0059)
        byte bh = 0; // Declare bh once, maps to BH (0x0064, 0x0093)
        byte ch = 0; // Declare ch once, maps to CH (0x0055, 0x0095)

        while (ah > 0) // Outer loop (0x008B–0x008D)
        {
            byte innerAh = 0x32; // Inner counter (0x0050, not int 1Ah)
            var68c = (byte)mockTimer.Next(0, 256); // [068Ch] (0x0052)
            var68d = (byte)mockTimer.Next(0, 256); // [068Dh] (0x0055)
            byte cl = var68c; // CL = [068Ch] (0x0052)
            ch = var68d; // CH = [068Dh] (0x0055)
            var68a = (byte)mockTimer.Next(0, 256); // [068Ah] (0x005B)
            var68b = (byte)mockTimer.Next(0, 256); // [068Bh] (0x005E)
            byte bl = var68c; // BL = [068Ch] (0x0061)
            bh = var68d; // BH = [068Dh] (0x0064)
            bpVar = (ushort)((bl | (bh << 8))); // BP = BX (0x0067)
            cl = bl; // CL = BL (0x0069)
            bh = 0; // xor bh, bh (0x006B)
            bl = (byte)(bpVar & 0xFF); // BL = BP low byte (0x006D)

            while (innerAh > 0) // Inner loop (0x0082–0x0084)
            {
                // Calculate pixel position (320x200)
                int x = var68a % 320; // DL, wrap to 0–319
                int y = var68b % 200; // DH, wrap to 0–199
                di = y * 320 + x; // DI = Y*320 + X (VGA offset)

                // Calculate color index (0x007B–0x007D)
                byte al = (byte)(mockTimer.Next(0, 256) | 0x80); // or al, 80h
                int colorIndex = (al - 0x80) % 128; // Map to 0–127
                canvas.SetPixel(x, y, colors[colorIndex]); // stosb (0x007D)

                // Update coordinates (0x007E–0x0080)
                var68a = (byte)(var68a + 1); // add dl, 01h
                var68b = (byte)(var68b + 3); // add dh, 03h

                innerAh--; // dec ah (0x0082)
            }

            // Update counters (0x0086–0x0088)
            var68c = (byte)(var68c + 2); // add cl, 02h
            var68d = (byte)(var68d + 1); // add ch, 01h

            ah--; // dec ah (0x008B)
        }

        // Emulate movement and feedback loop (0x008F–0x00C6)
        bpVar--; // dec bp (0x008F)
        byte bx = (byte)(bpVar & 0xFF); // mov bx, bp (0x0091)
        bh = 0; // xor bh, bh (0x0093)
        ch = 0; // xor ch, ch (0x0095)
        bpVar = (ushort)(bpVar + bx); // add bp, bx (0x0097)
        int si = bx; // add si, bx (0x0099, using si as offset)

        // Read pixel value (0x00C4)
        int feedbackX = 319; // Approximate [di] at end of frame
        int feedbackY = 199;
        byte pixelValue = GetPixelValue(feedbackX, feedbackY); // mov al, [di]

        // Boundary and color adjustment (0x009B–0x00C6)
        // Note: bh is always 0 (from xor bh, bh), so test bh, 08h is false
        // This block simplifies to the else branch, but we keep both for fidelity
        if ((bh & 0x08) == 0) // test bh, 08h (0x009B)
        {
            byte diIndex = (byte)(bx & 0x03); // and bl, 03h (0x00A0)
            // Read current pixel value at feedback position
            if (pixelValue < 0xFD) // cmp byte [di], 03h (0x00A3, adjusted for pixelValue)
            {
                pixelValue++; // inc byte [di] (0x00A8)
                canvas.SetPixel(feedbackX, feedbackY, colors[(pixelValue - 0x80) % 128]);
            }
        }
        else
        {
            byte diIndex = (byte)(bx & 0x03); // and bl, 03h (0x00AC)
            if (pixelValue > 0x03) // cmp byte [di], 0FDh (0x00AF, adjusted for pixelValue)
            {
                pixelValue--; // dec byte [di] (0x00B4)
                canvas.SetPixel(feedbackX, feedbackY, colors[(pixelValue - 0x80) % 128]);
            }
        }

        // Update variables with vars505 (0x00B6–0x00BF)
        var68a = vars505[0]; // mov dl, [0505h]
        var68b = vars505[1]; // mov dh, [0506h]
        var68c = vars505[2]; // mov cl, [0507h]
        var68d = vars505[3]; // mov ch, [0508h]

        Invalidate(); // Redraw the form
    }

    private byte GetPixelValue(int x, int y)
    {
        // Read pixel color and convert to approximate index (0x00C4)
        Color pixel = canvas.GetPixel(x, y);
        // Find closest palette index
        int minDistance = int.MaxValue;
        int bestIndex = 0;
        for (int i = 0; i < 128; i++)
        {
            int r = palette[i * 3 + 0] * 255 / 63;
            int g = palette[i * 3 + 1] * 255 / 63;
            int b = palette[i * 3 + 2] * 255 / 63;
            int distance = Math.Abs(pixel.R - r) + Math.Abs(pixel.G - g) + Math.Abs(pixel.B - b);
            if (distance < minDistance)
            {
                minDistance = distance;
                bestIndex = i;
            }
        }
        return (byte)(bestIndex + 0x80); // Map back to 0x80–0xFF
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LsdSwirl());
    }
}