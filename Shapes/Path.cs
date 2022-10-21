public class Path : Shape
{ 
    public Path() {points = "M20, 30 Q40,05 50,130 T40,230"; stroke = "blue"; stroke_width = 4; fill = "none";toString();}//Default constructor
    public Path(string points, string stroke, int stroke_width, string fill) //Parameterized constructor
    {   
        this.points = points;
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        this.fill = fill;
        toString();
    } 

    public override void toString()//convert our object into svg format shape with parameters and store it into list
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<path d=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()//delete from svg list my finding the correct indext
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<path d=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));
        svgShapes.RemoveAt(index);
    }
}