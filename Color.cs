namespace PietSharp
{
    interface IColorComponent
    {
        public void Shift(int amount);
        public void Shift();
    }

    public class Hue : IColorComponent
    {
        // True = High value, False = Low value
        public bool RedComponent { get; private set; }
        public bool GreenComponent { get; private set; }
        public bool BlueComponent { get; private set; }

        public static readonly Hue Red = new() { RedComponent = true };
        public static readonly Hue Yellow = new() { RedComponent = true, GreenComponent = true };
        public static readonly Hue Green = new() { GreenComponent = true };
        public static readonly Hue Cyan = new() { GreenComponent = true, BlueComponent = true };
        public static readonly Hue Blue = new() { BlueComponent = true };
        public static readonly Hue Magenta = new() { RedComponent = true, BlueComponent = true };

        public void Shift(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Shift() => this.Shift(1);
    }

    public class Lightness : IColorComponent
    {
        private const int BrightValue = 0xFF;
        private const int DimValue = 0xC0;
        private const int DarkValue = 0x00;

        public int HighValue { get; private set; } = DarkValue;
        public int LowValue { get; private set; } = DarkValue;

        public static readonly Lightness Light = new() { HighValue = BrightValue, LowValue = DimValue };
        public static readonly Lightness Normal = new() { HighValue = BrightValue, LowValue = DarkValue };
        public static readonly Lightness Dark = new() { HighValue = DimValue, LowValue = DarkValue };

        public void Shift(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Shift() => this.Shift(1);
    }

    public struct RGB
    {
        public int Red;
        public int Green;
        public int Blue;
    }

    public class Color
    {
        public Hue Hue { get; }
        public Lightness Lightness { get; }

        public Color(Hue hue, Lightness lightness)
        {
            this.Hue = hue;
            this.Lightness = lightness;
        }

        public Color(Hue hue) : this(hue, Lightness.Normal)
        {
        }

        private int GetComponent(bool color) => color ? this.Lightness.HighValue : this.Lightness.LowValue;

        public int Red => this.GetComponent(this.Hue.RedComponent);
        public int Green => this.GetComponent(this.Hue.GreenComponent);
        public int Blue => this.GetComponent(this.Hue.BlueComponent);

        // ReSharper disable once InconsistentNaming
        public RGB RGB => new() { Red = this.Red, Green = this.Green, Blue = this.Blue };
    }
}
