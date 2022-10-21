//Operating System used: Windows 10, coded in Visual Studio Code
//Developped by Jevgenij Ivanov
//Last Update 10/18/2022

class Program
{
    public static void Main(string[] args)  // main driver code
    {
        bool finish = false; // boolean for checking if we are finished with our user inputs
        Shape.svgActions(); // print instructions of the application
        while (finish != true)  // loop until operation 5 is selected
        {
            string input = Console.ReadLine();  // user input for operation
            switch (input)
            {
                case "1": Shape.availableShapes(); Shape.shapeSelector(); break;    //print available shapes and create a shape through shape selector
                case "2": Shape.readShape(); break; //retrieve a list of shapes and display them
                case "3": Shape.updateShape(); break;   //update any shape from all the available shapes
                case "4": Shape.deleteShape(); break;    //delete any shape from all the available shapes
                case "5": Shape.defaultShape(); break;  //create default shape
                case "6": Shape.groupShapes(); break;   //group shapes
                case "7": Shape.unGroupShapes(); break; //ungroup shapes
                case "8": Shape.addGroupStyle(); break; //add styles to groups
                case "9": Shape.addText(); break;  //add random/defualt text
                case "10": finish = true; Shape.svgOpen(); Shape.svgClose(); Console.WriteLine("Shapes have been exported to file <svgShapesExport.svg>."); break;   //finish operations and export everything to canvas, it will ask about z-index before finishing up
                default: Console.WriteLine("Please input a valid operation."); break;   //if user inputs non-existant operation
            }
        }
    }
}

