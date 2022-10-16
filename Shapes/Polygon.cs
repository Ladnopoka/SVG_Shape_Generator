public class Polygon : Polyline
{
    public Polygon() {points = "50 160 55 180 70 180 60 190 65 205 50 195 35 205 40 190 30 180 45 180"; stroke = "pink"; stroke_width = 4; fill = "red";}
    public Polygon(string points, string stroke, int stroke_width, string fill) 
    {   
        this.points = points;
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        this.fill = fill;
        toString();
    } 

    public override void toString()
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<polygon points=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<polygon points=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));

        string temp = svgShapes[index];
        svgShapes.RemoveAt(index);
        svgShapes.Add(temp);
    }
} 