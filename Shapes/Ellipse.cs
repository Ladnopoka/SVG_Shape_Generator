public class Ellipse : Shape
{
    public int cx { get; set; }  // ellipse radius
    public int cy { get; set; }  // ellipse radius
    public int rx { get; set; }  // ellipse radius
    public int ry { get; set; }  // ellipse radius

    public Ellipse() { cx = 100; cy = 100; rx = 100; ry = 100; stroke = "black"; stroke_width = 4; fill = "orange"; toString();}//Default constructor
    public Ellipse(int cx, int cy, int rx, int ry, string stroke, int stroke_width, string fill) //Parameterized constructor
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

    public override void toString()//convert our object into svg format shape with parameters and store it into list
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", cx, cy, rx, ry, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()//delete from svg list my finding the correct indext
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", cx, cy, rx, ry, stroke, stroke_width, fill));
        svgShapes.RemoveAt(index);
    }
}