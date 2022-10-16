public class Ellipse : Circle
{
    public int rx { get; set; }  // circle radius
    public int ry { get; set; }  // circle radius

    public Ellipse() { cx = 100; cy = 100; rx = 100; ry = 100; stroke = "black"; stroke_width = 4; fill = "orange";}
    public Ellipse(int cx, int cy, int rx, int ry, string stroke, int stroke_width, string fill) 
    {   
        this.cx = cx; 
        this.cy = cy; 
        this.rx = rx;
        this.ry = ry;  
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        this.fill = fill;
        toString();
    }

    public override void toString()
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", cx, cy, rx, ry, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", cx, cy, rx, ry, stroke, stroke_width, fill));

        string temp = svgShapes[index];
        svgShapes.RemoveAt(index);
        svgShapes.Add(temp);
    }
}