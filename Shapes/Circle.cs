public class Circle : Shape
{
    public int cx { get; set; }  // circle centre cx-coordinate
    public int cy { get; set; }  // circle centre cy-coordinate
    public int r { get; set; }  // circle radius

    public Circle() { cx = 100; cy = 100; r = 100; stroke = "black"; stroke_width = 4; fill = "red";}
    public Circle(int cx, int cy, int r, string stroke, int stroke_width, string fill) 
    {   
        this.cx = cx; 
        this.cy = cy; 
        this.r = r; 
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        this.fill = fill;  
        toString();
    }

    public override void toString()
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<circle cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""{3}"" stroke-width=""{4}"" fill=""{5}""/>", cx, cy, r, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<circle cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""{3}"" stroke-width=""{4}"" fill=""{5}""/>", cx, cy, r, stroke, stroke_width, fill));

        string temp = svgShapes[index];
        svgShapes.RemoveAt(index);
        svgShapes.Add(temp);
    }
}
