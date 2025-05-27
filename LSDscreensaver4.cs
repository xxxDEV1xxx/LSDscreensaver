using System; // Imports basic system functionalities
using System.Drawing; // Imports graphics-related classes (e.g., Color, Bitmap)
using System.Drawing.Imaging; // Imports image processing classes (e.g., BitmapData, PixelFormat)
using System.Windows.Forms; // Imports Windows Forms classes for UI (e.g., Form, Timer)

class LsdSwirl : Form // Defines LsdSwirl class, inheriting from Form for a windowed application
{
    private readonly byte[] palette = new byte[] { // Defines a 384-byte RGB palette (128 colors, 3 bytes each)
        0x3f,0x00,0x3f, 0x3f,0x02,0x3d, 0x3f,0x04,0x3b, 0x3f,0x06,0x39, // RGB values for colors 0–3 (6-bit, 0–63 range)
        0x3f,0x08,0x37, 0x3f,0x0a,0x35, 0x3f,0x0c,0x33, 0x3f,0x0e,0x31, // RGB values for colors 4–7
        0x3f,0x10,0x2f, 0x3f,0x12,0x2d, 0x3f,0x14,0x2b, 0x3f,0x16,0x29, // RGB values for colors 8–11
        0x3f,0x18,0x27, 0x3f,0x1a,0x25, 0x3f,0x1c,0x23, 0x3f,0x1e,0x21, // RGB values for colors 12–15
        0x3f,0x20,0x1f, 0x3f,0x22,0x1d, 0x3f,0x24,0x1b, 0x3f,0x26,0x19, // RGB values for colors 16–19
        0x3f,0x28,0x17, 0x3f,0x2a,0x15, 0x3f,0x2c,0x13, 0x3f,0x2e,0x11, // RGB values for colors 20–23
        0x3f,0x30,0x0f, 0x3f,0x32,0x0d, 0x3f,0x34,0x0b, 0x3f,0x36,0x09, // RGB values for colors 24–27
        0x3f,0x38,0x07, 0x3f,0x3a,0x05, 0x3f,0x3c,0x03, 0x3f,0x3e,0x01, // RGB values for colors 28–31
        0x3f,0x3f,0x00, 0x3d,0x3f,0x02, 0x3b,0x3f,0x04, 0x39,0x3f,0x06, // RGB values for colors 32–35
        0x37,0x3f,0x08, 0x35,0x3f,0x0a, 0x33,0x3f,0x0c, 0x31,0x3f,0x0e, // RGB values for colors 36–39
        0x2f,0x3f,0x10, 0x2d,0x3f,0x12, 0x2b,0x3f,0x14, 0x29,0x3f,0x16, // RGB values for colors 40–43
        0x27,0x3f,0x18, 0x25,0x3f,0x1a, 0x23,0x3f,0x1c, 0x21,0x3f,0x1e, // RGB values for colors 44–47
        0x1f,0x3f,0x20, 0x1d,0x3f,0x22, 0x1b,0x3f,0x24, 0x19,0x3f,0x26, // RGB values for colors 48–51
        0x17,0x3f,0x28, 0x15,0x3f,0x2a, 0x13,0x3f,0x2c, 0x11,0x3f,0x2e, // RGB values for colors 52–55
        0x0f,0x3f,0x30, 0x0d,0x3f,0x32, 0x0b,0x3f,0x34, 0x09,0x3f,0x36, // RGB values for colors 56–59
        0x07,0x3f,0x38, 0x05,0x3f,0x3a, 0x03,0x3f,0x3c, 0x01,0x3f,0x3e, // RGB values for colors 60–63
        0x00,0x3f,0x3f, 0x00,0x3d,0x3f, 0x00,0x3b,0x3f, 0x00,0x39,0x3f, // RGB values for colors 64–67
        0x00,0x37,0x3f, 0x00,0x35,0x3f, 0x00,0x33,0x3f, 0x00,0x31,0x3f, // RGB values for colors 68–71
        0x00,0x2f,0x3f, 0x00,0x2d,0x3f, 0x00,0x2b,0x3f, 0x00,0x29,0x3f, // RGB values for colors 72–75
        0x00,0x27,0x3f, 0x00,0x25,0x3f, 0x00,0x23,0x3f, 0x00,0x21,0x3f, // RGB values for colors 76–79
        0x00,0x1f,0x3f, 0x00,0x1d,0x3f, 0x00,0x1b,0x3f, 0x00,0x19,0x3f, // RGB values for colors 80–83
        0x00,0x17,0x3f, 0x00,0x15,0x3f, 0x00,0x13,0x3f, 0x00,0x11,0x3f, // RGB values for colors 84–87
        0x00,0x0f,0x3f, 0x00,0x0d,0x3f, 0x00,0x0b,0x3f, 0x00,0x09,0x3f, // RGB values for colors 88–91
        0x00,0x07,0x3f, 0x00,0x05,0x3f, 0x00,0x03,0x3f, 0x00,0x01,0x3f, // RGB values for colors 92–95
        0x00,0x00,0x3f, 0x02,0x00,0x3f, 0x04,0x00,0x3f, 0x06,0x00,0x3f, // RGB values for colors 96–99
        0x08,0x00,0x3f, 0x0a,0x00,0x3f, 0x0c,0x00,0x3f, 0x0e,0x00,0x3f, // RGB values for colors 100–103
        0x10,0x00,0x3f, 0x12,0x00,0x3f, 0x14,0x00,0x3f, 0x16,0x00,0x3f, // RGB values for colors 104–107
        0x18,0x00,0x3f, 0x1a,0x00,0x3f, 0x1c,0x00,0x3f, 0x1e,0x00,0x3f, // RGB values for colors 108–111
        0x20,0x00,0x3f, 0x22,0x00,0x3f, 0x24,0x00,0x3f, 0x26,0x00,0x3f, // RGB values for colors 112–115
        0x28,0x00,0x3f, 0x2a,0x00,0x3f, 0x2c,0x00,0x3f, 0x2e,0x00,0x3f, // RGB values for colors 116–119
        0x30,0x00,0x3f, 0x32,0x00,0x3f, 0x34,0x00,0x3f, 0x36,0x00,0x3f, // RGB values for colors 120–123
        0x38,0x00,0x3f, 0x3a,0x00,0x3f, 0x3c,0x00,0x3f, 0x3f,0x00,0x3f // RGB values for colors 124–127
    }; // Stores 128 RGB colors for the palette

    private readonly byte[] lookupTable = new byte[] { // Defines a 128-byte lookup table for color index calculations
        0x40,0x40,0x40,0x40,0x40,0x40,0x40,0x40, // Values 0–7 (0x40)
        0x3f,0x3f,0x3f,0x3f,0x3f,0x3e,0x3e,0x3e, // Values 8–15 (0x3f–0x3e)
        0x3e,0x3d,0x3d,0x3d,0x3c,0x3c,0x3b,0x3b, // Values 16–23 (0x3e–0x3b)
        0x3a,0x3a,0x39,0x39,0x38,0x38,0x37,0x37, // Values 24–31 (0x3a–0x37)
        0x36,0x35,0x35,0x34,0x34,0x33,0x32,0x32, // Values 32–39 (0x36–0x32)
        0x31,0x30,0x30,0x2f,0x2e,0x2e,0x2d,0x2c, // Values 40–47 (0x31–0x2c)
        0x2c,0x2b,0x2a,0x29,0x29,0x28,0x27,0x26, // Values 48–55 (0x2c–0x26)
        0x25,0x25,0x24,0x23,0x22,0x22,0x21,0x20, // Values 56–63 (0x25–0x20)
        0x1f,0x1e,0x1e,0x1d,0x1c,0x1b,0x1b,0x1a, // Values 64–71 (0x1f–0x1a)
        0x19,0x18,0x17,0x17,0x16,0x15,0x14,0x14, // Values 72–79 (0x19–0x14)
        0x13,0x12,0x12,0x11,0x10,0x10,0x0f,0x0e, // Values 80–87 (0x13–0x0e)
        0x0e,0x0d,0x0c,0x0c,0x0b,0x0b,0x0a,0x09, // Values 88–95 (0x0e–0x09)
        0x09,0x08,0x08,0x07,0x07,0x06,0x06,0x05, // Values 96–103 (0x09–0x05)
        0x05,0x05,0x04,0x04,0x03,0x03,0x03,0x02, // Values 104–111 (0x05–0x02)
        0x02,0x02,0x02,0x01,0x01,0x01,0x01,0x01, // Values 112–119 (0x02–0x01)
        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 // Values 120–127 (0x00)
    }; // Stores values for color index offset calculations

    private readonly Color[] colors = new Color[128]; // Array to store 128 Color objects for palette
    private readonly byte[,] colorBytes = new byte[128, 3]; // 2D array for precomputed BGR bytes (128 colors, 3 bytes each)
    private byte var68a = 0; // Animation variable for color index feedback (x-direction)
    private byte var68b = 0; // Animation variable for color index feedback (x-direction, faster)
    private byte var68c = 0; // Animation variable for color index feedback (y-direction)
    private byte var68d = 0; // Animation variable for color index feedback (frame-based)
    private byte[] vars505 = new byte[] { 2, 1, 3, 4 }; // Array of 4 bytes controlling animation speeds
    private ushort bpVar = 0; // 16-bit variable for animation state (decrements per frame)
    private readonly Timer timer; // Timer for frame updates
    private Bitmap canvas; // Bitmap for rendering the 320x200 effect
    private int canvasWidth = 320; // Canvas width in pixels
    private int canvasHeight = 200; // Canvas height in pixels
    private Point lastMousePosition; // Stores last mouse position for exit detection
    private byte[] vars = new byte[320 * 200]; // 320x200 color map (64,000 bytes for color indices)

    public LsdSwirl() // Constructor for LsdSwirl form
    {
        this.FormBorderStyle = FormBorderStyle.None; // Removes window borders
        this.WindowState = FormWindowState.Maximized; // Maximizes window to full screen
        this.BackColor = Color.Black; // Sets background to black
        this.DoubleBuffered = true; // Enables double buffering to reduce flicker

        Rectangle screen = Screen.PrimaryScreen.Bounds; // Gets primary screen dimensions
        int screenWidth = screen.Width; // Stores screen width
        int screenHeight = screen.Height; // Stores screen height

        Cursor.Position = new Point(screenWidth - 1, screenHeight - 1); // Moves cursor to bottom-right
        lastMousePosition = Cursor.Position; // Initializes last mouse position

        float aspectRatio = (float)canvasWidth / canvasHeight; // Calculates canvas aspect ratio (1.6)
        float screenAspectRatio = (float)screenWidth / screenHeight; // Calculates screen aspect ratio

        if (screenAspectRatio > aspectRatio) // If screen is wider than canvas aspect
        {
            canvasHeight = screenHeight; // Sets canvas height to screen height
            canvasWidth = (int)(screenHeight * aspectRatio); // Scales canvas width to maintain aspect
        }
        else // If screen is taller or equal
        {
            canvasWidth = screenWidth; // Sets canvas width to screen width
            canvasHeight = (int)(screenWidth / aspectRatio); // Scales canvas height to maintain aspect
        }

        canvas = new Bitmap(320, 200, PixelFormat.Format24bppRgb); // Creates 320x200 bitmap (24-bit RGB)

        for (int i = 0; i < 128; i++) // Loops through 128 palette colors
        {
            int r = palette[i * 3 + 0] * 255 / 63; // Scales red component (0–63) to 0–255
            int g = palette[i * 3 + 1] * 255 / 63; // Scales green component (0–63) to 0–255
            int b = palette[i * 3 + 2] * 255 / 63; // Scales blue component (0–63) to 0–255
            colors[i] = Color.FromArgb(r, g, b); // Creates Color object for palette index i
            colorBytes[i, 0] = (byte)b; // Stores blue byte (BGR order)
            colorBytes[i, 1] = (byte)g; // Stores green byte
            colorBytes[i, 2] = (byte)r; // Stores red byte
        }

        timer = new Timer(); // Initializes timer
        timer.Interval = 66; // Sets timer interval to 66ms (~15 FPS)
        timer.Tick += new EventHandler(UpdateFrame); // Binds UpdateFrame to timer tick event
        timer.Start(); // Starts the timer

        this.MouseMove += new MouseEventHandler(MouseMoveHandler); // Binds mouse move event handler
        this.MouseClick += new MouseEventHandler(MouseClickHandler); // Binds mouse click event handler
        this.KeyDown += new KeyEventHandler(KeyDownHandler); // Binds key down event handler
    }

    private void MouseMoveHandler(object sender, MouseEventArgs e) // Handles mouse movement
    {
        Point current = Cursor.Position; // Gets current mouse position
        if (Math.Abs(current.X - lastMousePosition.X) > 5 || Math.Abs(current.Y - lastMousePosition.Y) > 5) // Checks if mouse moved >5 pixels
        {
            Application.Exit(); // Exits application on significant mouse movement
        }
        lastMousePosition = current; // Updates last mouse position
    }

    private void MouseClickHandler(object sender, MouseEventArgs e) // Handles mouse clicks
    {
        Application.Exit(); // Exits application on any mouse click
    }

    private void KeyDownHandler(object sender, KeyEventArgs e) // Handles key presses
    {
        Application.Exit(); // Exits application on any key press
    }

    protected override void OnPaint(PaintEventArgs e) // Overrides paint event for custom rendering
    {
        Rectangle screen = Screen.PrimaryScreen.Bounds; // Gets screen dimensions
        int screenWidth = screen.Width; // Stores screen width
        int screenHeight = screen.Height; // Stores screen height

        int xOffset = (screenWidth - canvasWidth) / 2; // Calculates x-offset to center canvas
        int yOffset = (screenHeight - canvasHeight) / 2; // Calculates y-offset to center canvas

        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; // Sets scaling to nearest-neighbor (no smoothing)
        e.Graphics.DrawImage(canvas, xOffset, yOffset, canvasWidth, canvasHeight); // Draws canvas centered on screen
        base.OnPaint(e); // Calls base paint method
    }

    private void UpdateFrame(object sender, EventArgs e) // Updates frame for animation
    {
        BitmapData bmpData = canvas.LockBits( // Locks bitmap for direct pixel access
            new Rectangle(0, 0, canvas.Width, canvas.Height), // Specifies entire 320x200 canvas
            ImageLockMode.WriteOnly, // Sets write-only mode
            PixelFormat.Format24bppRgb // Uses 24-bit RGB format
        );

        unsafe // Enables unsafe code for pointer operations
        {
            byte* ptr = (byte*)bmpData.Scan0; // Gets pointer to bitmap data
            int stride = bmpData.Stride; // Gets bytes per row (may include padding)

            for (int y = 0; y < 200; y++) // Loops through 200 rows
            {
                byte* row = ptr + y * stride; // Points to start of current row
                for (int x = 0; x < 320; x++) // Loops through 320 columns
                {
                    // Compute color index directly for 320x200
                    byte al = (byte)(bpVar & 0xFF); // Gets low byte of bpVar as base value
                    al += lookupTable[y % lookupTable.Length]; // Adds lookup value for y-coordinate
                    al += lookupTable[x % lookupTable.Length]; // Adds lookup value for x-coordinate
                    al += lookupTable[(y + 2) % lookupTable.Length]; // Adds lookup value for y+2
                    al += lookupTable[(x + 1) % lookupTable.Length]; // Adds lookup value for x+1
                    al |= 0x80; // Sets high bit (adds 128)
                    byte colorIndex = (byte)(al - 128); // Subtracts 128 to get palette index
                    vars[y * 320 + x] = colorIndex; // Stores color index in vars array

                    int offset = x * 3; // Calculates byte offset for pixel (3 bytes per pixel)
                    row[offset + 0] = colorBytes[colorIndex, 0]; // Sets blue component
                    row[offset + 1] = colorBytes[colorIndex, 1]; // Sets green component
                    row[offset + 2] = colorBytes[colorIndex, 2]; // Sets red component

                    var68a++; // Increments var68a (per pixel)
                    var68b = (byte)(var68b + 3); // Increments var68b by 3 (per pixel)
                }
                var68c = (byte)(var68c + 2); // Increments var68c by 2 (per row)
                var68d++; // Increments var68d (per row)
            }
        }

        canvas.UnlockBits(bmpData); // Unlocks bitmap data

        // Animation update
        bpVar--; // Decrements 16-bit bpVar
        byte bl = (byte)(bpVar & 0xFF); // Gets low byte of bpVar
        bl ^= (byte)((bpVar >> 8) & 0xFF); // XORs with high byte of bpVar
        byte pixel = vars[199 * 320 + 319]; // Gets color index at bottom-right (319,199)
        bl ^= pixel; // XORs with pixel value
        bl ^= var68c; // XORs with var68c
        bl ^= var68a; // XORs with var68a
        bl = (byte)(bl + var68d); // Adds var68d
        bl = (byte)(bl + var68b); // Adds var68b

        if ((bl & 0x08) == 0) // Checks if bit 3 of bl is 0
        {
            int di = bl & 0x03; // Gets low 2 bits of bl (index 0–3)
            if (vars505[di] < 0xFD) // If vars505[di] is below 253
                vars505[di]++; // Increments vars505[di]
        }
        else // If bit 3 of bl is 1
        {
            int di = bl & 0x03; // Gets low 2 bits of bl (index 0–3)
            if (vars505[di] > 0x03) // If vars505[di] is above 3
                vars505[di]--; // Decrements vars505[di]
        }

        var68a = (byte)(var68a + vars505[0]); // Updates var68a with vars505[0]
        var68b = (byte)(var68b - vars505[1]); // Updates var68b with vars505[1] (subtract)
        var68c = (byte)(var68c + vars505[2]); // Updates var68c with vars505[2]
        var68d = (byte)(var68d - vars505[3]); // Updates var68d with vars505[3] (subtract)

        // Partial redraw
        Rectangle screen = Screen.PrimaryScreen.Bounds; // Gets screen dimensions
        int xOffset = (screen.Width - canvasWidth) / 2; // Calculates x-offset to center
        int yOffset = (screen.Height - canvasHeight) / 2; // Calculates y-offset to center
        Invalidate(new Rectangle(xOffset, yOffset, canvasWidth, canvasHeight)); // Requests redraw of canvas area
    }

    [STAThread] // Specifies single-threaded apartment model for COM compatibility
    static void Main() // Program entry point
    {
        Application.EnableVisualStyles(); // Enables visual styles for UI
        Application.SetCompatibleTextRenderingDefault(false); // Sets text rendering compatibility
        Application.Run(new LsdSwirl()); // Starts application with LsdSwirl form
    }
}