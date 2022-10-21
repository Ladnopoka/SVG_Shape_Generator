//Operating System used: Windows 10, coded in Visual Studio Code
//Developped by Jevgenij Ivanov
//Last Update 10/18/2022

public class Text : Shape
{
    private int x { get; set; }  // text centre x-coordinate
    private int y { get; set; }  // text centre y-coordinate
    private string font_style {get; set;} 
    private int font_size {get; set;}
    private string text {get; set;}

    public Text() { x = 400; y = 400; fill = "black"; font_style = "italic"; font_size = 50; text = "Default text"; toString();}   //Default constructor
    public Text(int x, int y, string fill, string font_style, int font_size, string text)  //Parameterized constructor
    {   
        this.x = x; 
        this.y = y;  
        this.fill = fill; 
        this.font_style = font_style; 
        this.font_size = font_size; 
        this.text = text;
        toString();
    }

    public override void toString() //convert our object into svg format shape with parameters and store it into list
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<text x=""{0}"" y=""{1}"" fill=""{2}"" font-style=""{3}"" font-size=""{4}"">{5}</text>", x, y, fill, font_style, font_size, text));
    }

    public override void deleteFromSVG() //delete from svg list my finding the correct indext
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<text x=""{0}"" y=""{1}"" fill=""{2}"" font-style=""{3}"" font-size=""{4}"">{5}</text>", x, y, fill, font_style, font_size, text));
        svgShapes.RemoveAt(index);
    }
}