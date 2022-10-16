public class Line : Shape
{
    public int x1 { get; set; }  // circle radius
    public int x2 { get; set; }  // circle radius
    public int y1 { get; set; }  // circle radius
    public int y2 { get; set; }  // circle radius

    public Line() { x1 = 100; x2 = 100; y1 = 100; y2 = 100; stroke = "black"; stroke_width = 4;}
    public Line(int x1, int x2, int y1, int y2, string stroke, int stroke_width) 
    {   
        this.x1 = x1; 
        this.x2 = x2; 
        this.y1 = y1;
        this.y2 = y2;  
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        toString();
    }

    public override void toString()
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<line x1=""{0}"" x2=""{1}"" y1=""{2}"" y2=""{3}"" stroke=""{4}"" stroke-width=""{5}""/>", x1, x2, y1, y2, stroke, stroke_width)); 
    }

    public override void deleteFromSVG()
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<line x1=""{0}"" x2=""{1}"" y1=""{2}"" y2=""{3}"" stroke=""{4}"" stroke-width=""{5}""/>", x1, x2, y1, y2, stroke, stroke_width)); 

        string temp = svgShapes[index];
        svgShapes.RemoveAt(index);
        svgShapes.Add(temp);
    }
}
