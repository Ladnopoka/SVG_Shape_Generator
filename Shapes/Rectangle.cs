public class Rectangle : Shape
{
    public int x { get; set; }  // x-coordinate of rectangle
    public int y { get; set; }  // y-coordinate of rectangle
    public int width { get; set; }  // circle radiusaaas
    public int height { get; set; }  // circle radiusaaas

    public Rectangle() { x = 100; y = 100; width = 100; height = 100; stroke = "black"; stroke_width = 4; fill = "purple";}
    public Rectangle(int x, int y, int width, int height, string stroke, int stroke_width, string fill) 
    {   
        this.x = x; 
        this.y = x; 
        this.width = width;
        this.height = height; 
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        this.fill = fill;
        toString();
    }

    public override void toString()
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<rect x=""{0}"" y=""{1}"" width=""{2}"" height=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", x, y, width, height, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<rect x=""{0}"" y=""{1}"" width=""{2}"" height=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", x, y, width, height, stroke, stroke_width, fill));

        string temp = svgShapes[index];
        svgShapes.RemoveAt(index);
        svgShapes.Add(temp);
    }
}
