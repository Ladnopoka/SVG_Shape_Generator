public class Polyline : Shape
{
    public string points {get; set;}

    public Polyline() {points = "60 110 65 120 70 115 75 130 80 125 85 140 90 135 95 150 100 145"; stroke = "black"; stroke_width = 4; fill = "red";}
    public Polyline(string points, string stroke, int stroke_width, string fill) 
    {   
        this.points = points;
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        this.fill = fill;
        toString();
    } 

    public override void toString()
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<polyline points=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<polyline points=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));

        string temp = svgShapes[index];
        svgShapes.RemoveAt(index);
        svgShapes.Add(temp);
    }
}

