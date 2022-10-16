class Program
{
    public static void Main(string[] args)
    {
        bool finish = false; // boolean for checking if we are finished with our user inputs
        Shape.svgActions();
        while (finish != true)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": Shape.availableShapes(); Shape.shapeSelector(); break;
                case "2": Shape.readShape(); break;
                case "3": Shape.updateShape(); break;
                case "4": Shape.deleteShape();break;
                case "5": finish = true; Shape.svgOpen(); Shape.svgClose(); Console.WriteLine("Shapes have been exported to file <svgShapesExport.svg>."); break;
                default: Console.WriteLine("Please input a valid operation."); break;
            }
        }
    }
}