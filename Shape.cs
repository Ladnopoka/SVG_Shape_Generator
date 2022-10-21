public class Shape
{
    protected string stroke {get; set;} //a common variable that is used throughout all the shapes, getter and setter
    protected string fill {get; set;} //a common variable that is used throughout all the shapes, getter and setter
    protected string points {get; set;} // for polylines
    protected int stroke_width {get; set;} //a common variable that is used throughout all the shapes, getter and setter
    public static List<Circle> myCircles = new List<Circle>();  // to store a shape object into a list of objects
    public static List<Rectangle> myRectangles = new List<Rectangle>(); // to store a shape object into a list of objects
    public static List<Ellipse> myEllipse = new List<Ellipse>();    // to store a shape object into a list of objects
    public static List<Line> myLine = new List<Line>(); // to store a shape object into a list of objects
    public static List<Polyline> myPolyline = new List<Polyline>(); // to store a shape object into a list of objects
    public static List<Polygon> myPolygon = new List<Polygon>();    // to store a shape object into a list of objects
    public static List<Path> myPath = new List<Path>(); // to store a shape object into a list of objects
    public static List<Text> myText = new List<Text>();
    public static List<string> svgShapes = new List<string>();  //to store the shapes into a list of strings, these shapes are in svg format

    public Shape() { stroke = "red"; stroke_width = 5; fill = "green"; }    //default constructor for Shape
    public Shape(string stroke, int stroke_width, string fill) //parameterized constructor for Shape
    {   
        this.stroke = stroke; 
        this.stroke_width = stroke_width; 
        this.fill = fill; 
    }

    public virtual void toString(){} // Will be overriden by subclasses
    public virtual void deleteFromSVG(){}//Will be overriden by subclesses
    public static void svgActions() //Method that prints the available actions/operations of this application
    {
        Console.WriteLine("\nPlease choose your operation: ");
        Console.WriteLine("1: Create a Shape");
        Console.WriteLine("2: Display a Shape");
        Console.WriteLine("3: Update a Shape");
        Console.WriteLine("4: Delete a Shape");
        Console.WriteLine("5: Create a Default Shape");
        Console.WriteLine("6: Group Shapes");
        Console.WriteLine("7: Ungroup Shapes");
        Console.WriteLine("8: Add Style to Group");
        Console.WriteLine("9: Add Text");
        Console.WriteLine("10: Finish up and export everything to canvas");
    }
    public static void svgOpen()    //Method that opens an svg file and puts a gray canvas on it
    {
        string svgOpen = @"<svg height=""800"" width=""800"" xmlns=""http://www.w3.org/2000/svg"">";    //opening line of svg file
        svgOpen += Environment.NewLine + "".PadLeft(3, ' ') + @"<rect width=""100%"" height=""100%"" fill=""gray""/>" + "\n";   //Creating a canvas
        File.WriteAllText(@".\svgShapesExport.svg", svgOpen); //add it to a file
    }
    public static void svgClose()   //Method that finishes up the SVG export, but it also checks if user wants to set z-index of any shape and display it on top of every other shape
    {
        Console.WriteLine("Before exporting all the shapes to SVG canvas, do you want\n" +  //message for user if he wants to set z-index
                "to set z-index of a shape and display it on top of every other shape?\nY/N?");
        string yesNo = Console.ReadLine();  //yes or no
        while(true) //infinite loop, loop is broken when user inputs N
        {
            if (yesNo.Equals("Y", StringComparison.InvariantCultureIgnoreCase)) //if input is y
            {
                Console.Write("Select the index of a shape you want to display on top of all other shapes:\n");
                for (int i = 0; i < svgShapes.Count; i++)   //display all the shapes in svg format
                {
                    Console.WriteLine("|index " + i + "|" + svgShapes[i]);
                }

                try
                {
                    int svgLineNum = int.Parse(Console.ReadLine()); //get user input for index
                    svgShapes.Add(svgShapes[svgLineNum]);   //add shape to the end of the list
                    svgShapes.RemoveAt(svgLineNum); //remove the hape at specified index
                    Console.WriteLine("The shape at index " + svgLineNum + " has been placed on top of every other shape (z-index highest priority)");
                }
                catch   //if any errors
                {
                    Console.WriteLine("Please enter a valid index");
                }
            }
            else if(yesNo.Equals("N", StringComparison.InvariantCultureIgnoreCase)) //if user inputs n we exit out of the infinite loop
            {
                break;
            }

            Console.Write("Do you want to change z-index of another shape?\nY/N\n");
            yesNo = Console.ReadLine(); //if user wants to go again
            if (yesNo.Equals("N", StringComparison.InvariantCultureIgnoreCase)) //if he doesn't, we are finished
            {
                break;
            }
        }

        for (int i = 0; i < svgShapes.Count; i++)   // append all line into an svg file
        {
            File.AppendAllText(@".\svgShapesExport.svg", Environment.NewLine + svgShapes[i]);
        }

        File.AppendAllText(@".\svgShapesExport.svg", "\n</svg>");   //add closing tag to svg file
    }
    public static void availableShapes()    //Method that prints available shapes
    {
        Console.WriteLine("\nInput the desired shape from the list below:");
        Console.WriteLine("Circle | Rectangle | Ellipse | Line | Polyline | Polygon | Path\n");
    }
    public static void shapeSelector()//Method that generates shapes objects and puts them into a list of objects
    {
        Random rnd = new Random(); // random number generator
        switch (Console.ReadLine().ToLower())   //switch between different shapes
        {
            case "circle": myCircles.Add(new Circle(rnd.Next(0, 600), rnd.Next(0, 600), rnd.Next(0, 190), randomColourSelector(), rnd.Next(1, 6), randomColourSelector())); Console.WriteLine("A Circle has been created! \n"); Shape.svgActions(); break; //put a shape with random parameters
            case "rectangle": myRectangles.Add(new Rectangle(rnd.Next(0, 700), rnd.Next(0, 700), rnd.Next(20, 150), rnd.Next(20, 150), randomColourSelector(), rnd.Next(1, 6), randomColourSelector())); Console.WriteLine("A Rectangle has been created! \n"); Shape.svgActions(); break;//put a shape with random parameters
            case "ellipse": myEllipse.Add(new Ellipse(rnd.Next(0, 700), rnd.Next(0, 700), rnd.Next(10, 100), rnd.Next(10, 100), randomColourSelector(), rnd.Next(1, 6), randomColourSelector())); Console.WriteLine("An Ellipse has been created! \n"); Shape.svgActions(); break;//put a shape with random parameters
            case "line": myLine.Add(new Line(rnd.Next(0, 800), rnd.Next(0, 800), rnd.Next(150, 800), rnd.Next(150, 800), randomColourSelector(), rnd.Next(1, 6))); Console.WriteLine("A Line has been created! \n"); Shape.svgActions(); break;//put a shape with random parameters
            case "polyline": //just an algorithm that applies a random number to points so that a shape can be added in different spots without losing it's shape
                int [] polypointsArr = {60, 110, 65, 120, 70, 115, 75, 130, 80, 125, 85, 140, 90, 135, 95, 150, 100, 145};  //a set of points for polyline
                int rndPolyNum = rnd.Next(30, 600); //too add to all points array to move the objects to a different place
                string polyPath = "";
                for (int i = 0; i < polypointsArr.Length; i++)//add our random number to all the points and add it to path string
                {   
                    polyPath += (polypointsArr[i]+rndPolyNum) + " ";
                }
                polyPath.Substring(0, polyPath.Length-1); //remove extra space at the end
                myPolyline.Add(new Polyline(polyPath, randomColourSelector(), rnd.Next(1, 6), randomColourSelector())); //create a new object parameterized
                Console.WriteLine("A Polyline has been created! \n"); Shape.svgActions(); break;
            case "polygon": //just an algorithm that applies a random number to points so that a shape can be added in different spots without losing it's shape
                int [] pointsArr = {150, 260, 155, 280, 170, 280, 160, 290, 165, 305, 150, 295, 135, 305, 140, 290, 130, 280, 145, 280};
                int rndNum = rnd.Next(30, 400);
                string polygonPath = "";
                for (int i = 0; i < pointsArr.Length; i++)  //add our random number to all the points and add it to path string
                {   
                    polygonPath += (pointsArr[i]+rndNum) + " ";
                }
                polygonPath = polygonPath.Substring(0, polygonPath.Length-1); // remove extra space at the end
                myPolygon.Add(new Polygon(polygonPath, randomColourSelector(), rnd.Next(1, 6), randomColourSelector())); //create parameterized object
                Console.WriteLine("A Polygon has been created! \n"); Shape.svgActions(); break;
            case "path": 
                List<string> availablePaths = new List<string>();   //i make a list of paths and then select a random path from the list
                availablePaths.Add("M 345 136 A 45 45 90 1 1 309 86 L 298 131 Z");
                availablePaths.Add("M 190 117 A 45 45 90 1 1 223 79 L 171 70 Z");
                availablePaths.Add("M 47 167 A 45 45 90 1 1 110 163 L 73 129 Z");
                availablePaths.Add("M 77 239 A 45 45 90 1 1 87 193 L 56 210 Z");
                availablePaths.Add("M 163 215 A 45 45 90 1 1 156 163 L 122 198 Z");
                availablePaths.Add("M 227 256 A 45 45 90 1 1 250 197 L 209 216 Z");
                availablePaths.Add("M 297 200 A 45 45 90 1 1 270 155 L 256 193 Z");
                availablePaths.Add("M 262 105 A 45 45 90 1 1 304 156 L 310 105 Z");
                availablePaths.Add("M 392 71 A 45 45 90 1 1 444 127 L 445 74 Z");
                availablePaths.Add("M 473 61 A 45 45 90 1 1 513 112 L 517 59 Z");
                availablePaths.Add("M 476 154 A 45 45 90 1 1 516 181 L 517 130 Z");
                availablePaths.Add("M 403 217 A 45 45 90 1 1 411 261 L 448 234 Z");
                availablePaths.Add("M 677 384 A 45 45 90 1 1 721 401 L 712 354 Z");
                availablePaths.Add("M 477 407 A 45 45 90 1 1 461 457 L 497 444 Z");
                availablePaths.Add("M 481 517 A 45 45 90 1 1 464 566 L 506 552 Z");
                availablePaths.Add("M 381 499 A 45 45 90 1 1 371 545 L 430 540 Z");
                int rndPathNum = rnd.Next(0, availablePaths.Count-1);
                string rndPath = availablePaths[rndPathNum];
                myPath.Add(new Path(rndPath, randomColourSelector(), rnd.Next(1, 6), randomColourSelector()));
                Console.WriteLine("A Path has been created! \n"); Shape.svgActions(); break; // create a polyline Object and store it into a list of objects
            default: Console.WriteLine("Incorrect shape, please try another operation.\n"); Shape.svgActions(); break;
        }
    }
    public static void deleteShape()    //Method that deletes any shape
    {
        Console.WriteLine("Which shape do you want to delete?");
        availableShapes();  // print available shapes

        switch(Console.ReadLine().ToLower())    // switch between shapes
        {
            case "circle":  //the comments applied to circle also apply to every other shape in this switch statement
                if(Circle.myCircles.Any()) 
                {
                    Console.WriteLine("You have " + Circle.myCircles.Count + " Circles");
                    for (int i = 0; i < Circle.myCircles.Count; i++)    //print all current shapes that you have, showing the parameters
                    {
                        Console.WriteLine("\nCircle number " + i + ": ");
                        Console.WriteLine("cx: " + Circle.myCircles[i].cx + 
                        "\ncy: " + Circle.myCircles[i].cy +
                        "\nr: " + Circle.myCircles[i].r +
                        "\nstroke: " + Circle.myCircles[i].stroke +
                        "\nstroke-width: " + Circle.myCircles[i].stroke_width +
                        "\nfill: " + Circle.myCircles[i].fill);
                    }
                    Console.WriteLine("\nWhich circle do you want to delete? Specify Index ranging between 0 and " + (Circle.myCircles.Count-1) + " inclusive.");
                    
                    try
                    {
                        int numCircle = Int32.Parse(Console.ReadLine());    //read input from user
                        while(true)
                        {
                            if (numCircle > (Circle.myCircles.Count-1) && numCircle < 0)    //wrong index
                                Console.WriteLine("Please specify indext ranging between 0 and " + (Circle.myCircles.Count-1) + " inclusive.");
                            else
                            {
                                Circle.myCircles[numCircle].deleteFromSVG(); Circle.myCircles.RemoveAt(numCircle); // remove from both object list and svg list
                                Console.WriteLine("Circle at index " + numCircle + " has been deleted. \n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a valid index number. \n");
                    }
                }
                else
                {
                    Console.WriteLine("You have no Circles to delete.");
                }Shape.svgActions(); break;

                case "rectangle":
                if(Rectangle.myRectangles.Any()) 
                {
                    Console.WriteLine("You have " + Rectangle.myRectangles.Count + " Rectangles");
                    for (int i = 0; i < Rectangle.myRectangles.Count; i++)
                    {
                        Console.WriteLine("\nRectangle number " + i + ": ");
                        Console.WriteLine("x: " + Rectangle.myRectangles[i].x + 
                        "\ny: " + Rectangle.myRectangles[i].y +
                        "\nwidth: " + Rectangle.myRectangles[i].width +
                        "\nheight: " + Rectangle.myRectangles[i].height +
                        "\nstroke: " + Rectangle.myRectangles[i].stroke +
                        "\nstroke-width: " + Rectangle.myRectangles[i].stroke_width +
                        "\nfill: " + Rectangle.myRectangles[i].fill);
                    }
                    Console.WriteLine("\nWhich Rectangle do you want to delete? Specify Index ranging between 0 and " + (Rectangle.myRectangles.Count-1) + " inclusive.");
                    
                    try
                    {
                        int numRectangle = Int32.Parse(Console.ReadLine());
                        while(true)
                        {
                            if (numRectangle > (Rectangle.myRectangles.Count-1) && numRectangle < 0)
                                Console.WriteLine("Please specify indext ranging between 0 and " + (Rectangle.myRectangles.Count-1) + " inclusive.");
                            else
                            {
                                Rectangle.myRectangles[numRectangle].deleteFromSVG(); Rectangle.myRectangles.RemoveAt(numRectangle);
                                Console.WriteLine("Rectangle at index " + numRectangle + " has been deleted. \n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a valid index number. \n");
                    }
                }
                else
                {
                    Console.WriteLine("You have no Rectangles to delete.");
                }Shape.svgActions(); break;
            
                case "ellipse":
                if(Ellipse.myEllipse.Any()) 
                {
                    Console.WriteLine("You have " + Ellipse.myEllipse.Count + " Ellipse");
                    for (int i = 0; i < Ellipse.myEllipse.Count; i++)
                    {
                        Console.WriteLine("\nEllipse number " + i + ": ");
                        Console.WriteLine("cx: " + Ellipse.myEllipse[i].cx + 
                        "\ncy: " + Ellipse.myEllipse[i].cy +
                        "\nrx: " + Ellipse.myEllipse[i].rx +
                        "\nry: " + Ellipse.myEllipse[i].ry +
                        "\nstroke: " + Ellipse.myEllipse[i].stroke +
                        "\nstroke-width: " + Ellipse.myEllipse[i].stroke_width +
                        "\nfill: " + Ellipse.myEllipse[i].fill);
                    }
                    Console.WriteLine("\nWhich Ellipse do you want to delete? Specify Index ranging between 0 and " + (Ellipse.myEllipse.Count-1) + " inclusive.");
                    
                    try
                    {
                        int numEllipse = Int32.Parse(Console.ReadLine());
                        while(true)
                        {
                            if (numEllipse > (Ellipse.myEllipse.Count-1) && numEllipse < 0)
                                Console.WriteLine("Please specify indext ranging between 0 and " + (Ellipse.myEllipse.Count-1) + " inclusive.");
                            else
                            {
                                Ellipse.myEllipse[numEllipse].deleteFromSVG(); Ellipse.myEllipse.RemoveAt(numEllipse);
                                Console.WriteLine("Ellipse at index " + numEllipse + " has been deleted. \n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a valid index number. \n");
                    }
                }
                else
                {
                    Console.WriteLine("You have no Ellipse to delete.");
                }Shape.svgActions(); break;
            
                case "line":
                if(Line.myLine.Any()) 
                {
                    Console.WriteLine("You have " + Line.myLine.Count + " Line");
                    for (int i = 0; i < Line.myLine.Count; i++)
                    {
                        Console.WriteLine("\nLine number " + i + ": ");
                        Console.WriteLine("x1: " + Line.myLine[i].x1 + 
                        "\nx2: " + Line.myLine[i].x2 +
                        "\ny1: " + Line.myLine[i].y1 +
                        "\ny2: " + Line.myLine[i].y2 +
                        "\nstroke: " + Line.myLine[i].stroke +
                        "\nstroke-width: " + Line.myLine[i].stroke_width);
                    }
                    Console.WriteLine("\nWhich Line do you want to delete? Specify Index ranging between 0 and " + (Line.myLine.Count-1) + " inclusive.");
                    
                    try
                    {
                        int numLine = Int32.Parse(Console.ReadLine());
                        while(true)
                        {
                            if (numLine > (Line.myLine.Count-1) && numLine < 0)
                                Console.WriteLine("Please specify indext ranging between 0 and " + (Line.myLine.Count-1) + " inclusive.");
                            else
                            {
                                Line.myLine[numLine].deleteFromSVG(); Line.myLine.RemoveAt(numLine);
                                Console.WriteLine("Line at index " + numLine + " has been deleted. \n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a valid index number. \n");
                    }
                }
                else
                {
                    Console.WriteLine("You have no Line to delete.");
                }Shape.svgActions(); break;

                case "polyline":
                if(Polyline.myPolyline.Any()) 
                {
                    Console.WriteLine("You have " + Polyline.myPolyline.Count + " Polyline");
                    for (int i = 0; i < Polyline.myPolyline.Count; i++)
                    {
                        Console.WriteLine("\nPolyline number " + i + ": ");
                        Console.WriteLine("points: " + Polyline.myPolyline[i].points + 
                        "\nstroke: " + Polyline.myPolyline[i].stroke +
                        "\nstroke-width: " + Polyline.myPolyline[i].stroke_width +
                        "\nfill: " + Polyline.myPolyline[i].fill);
                    }
                    Console.WriteLine("\nWhich Polyline do you want to delete? Specify Index ranging between 0 and " + (Polyline.myPolyline.Count-1) + " inclusive.");
                    
                    try
                    {
                        int numPolyline = Int32.Parse(Console.ReadLine());
                        while(true)
                        {
                            if (numPolyline > (Polyline.myPolyline.Count-1) && numPolyline < 0)
                                Console.WriteLine("Please specify indext ranging between 0 and " + (Polyline.myPolyline.Count-1) + " inclusive.");
                            else
                            {
                                Polyline.myPolyline[numPolyline].deleteFromSVG(); Polyline.myPolyline.RemoveAt(numPolyline);
                                Console.WriteLine("Polyline at index " + numPolyline + " has been deleted. \n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a valid index number. \n");
                    }
                }
                else
                {
                    Console.WriteLine("You have no Polyline to delete.");
                }Shape.svgActions(); break;

                case "polygon":
                if(Polygon.myPolygon.Any()) 
                {
                    Console.WriteLine("You have " + Polygon.myPolygon.Count + " Polygon");
                    for (int i = 0; i < Polygon.myPolygon.Count; i++)
                    {
                        Console.WriteLine("\nPolygon number " + i + ": ");
                        Console.WriteLine("points: " + Polygon.myPolygon[i].points + 
                        "\nstroke: " + Polygon.myPolygon[i].stroke +
                        "\nstroke-width: " + Polygon.myPolygon[i].stroke_width +
                        "\nfill: " + Polygon.myPolygon[i].fill);
                    }
                    Console.WriteLine("\nWhich Polygon do you want to delete? Specify Index ranging between 0 and " + (Polygon.myPolygon.Count-1) + " inclusive.");
                    
                    try
                    {
                        int numPolygon = Int32.Parse(Console.ReadLine());
                        while(true)
                        {
                            if (numPolygon > (Polygon.myPolygon.Count-1) && numPolygon < 0)
                                Console.WriteLine("Please specify indext ranging between 0 and " + (Polygon.myPolygon.Count-1) + " inclusive.");
                            else
                            {
                                Polygon.myPolygon[numPolygon].deleteFromSVG(); Polygon.myPolygon.RemoveAt(numPolygon);
                                Console.WriteLine("Polygon at index " + numPolygon + " has been deleted. \n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a valid index number. \n");
                    }
                }
                else
                {
                    Console.WriteLine("You have no Polygon to delete.");
                }Shape.svgActions(); break;

                case "path":
                if(Path.myPath.Any()) 
                {
                    Console.WriteLine("You have " + Path.myPath.Count + " Path");
                    for (int i = 0; i < Path.myPath.Count; i++)
                    {
                        Console.WriteLine("\nPath number " + i + ": ");
                        Console.WriteLine("Path: " + Path.myPath[i].points + 
                        "\nstroke: " + Path.myPath[i].stroke +
                        "\nstroke-width: " + Path.myPath[i].stroke_width +
                        "\nfill: " + Path.myPath[i].fill);
                    }
                    Console.WriteLine("\nWhich Path do you want to delete? Specify Index ranging between 0 and " + (Path.myPath.Count-1) + " inclusive.");
                    
                    try
                    {
                        int numPath = Int32.Parse(Console.ReadLine());
                        while(true)
                        {
                            if (numPath > (Path.myPath.Count-1) && numPath < 0)
                                Console.WriteLine("Please specify indext ranging between 0 and " + (Path.myPath.Count-1) + " inclusive.");
                            else
                            {
                                Path.myPath[numPath].deleteFromSVG(); Path.myPath.RemoveAt(numPath);
                                Console.WriteLine("Path at index " + numPath + " has been deleted. \n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a valid index number. \n");
                    }
                }
                else
                {
                    Console.WriteLine("You have no Path to delete.");
                }Shape.svgActions(); break;

            default: Console.WriteLine("Incorrect shape, please try another action.\n"); Shape.svgActions(); ; break;
        }
    }
    public static void readShape()  //Method that reads the shapes and outputs the shapes to console with all the parameters
    {
        Console.WriteLine("Which shape do you want to Read/Retrieve?");
        availableShapes();  // print available shapes

        switch(Console.ReadLine().ToLower())    //read circle 
        {
            case "circle":  //all comments for circle apply to other shapes too
            if(Circle.myCircles.Any()) 
            {
                Console.WriteLine("You have " + Circle.myCircles.Count + " Circles:");
                for (int i = 0; i < Circle.myCircles.Count; i++)    // print all the shapes that you have and show parameters
                {
                    Console.WriteLine("\nCircle number " + i + ": ");
                    Console.WriteLine("cx: " + Circle.myCircles[i].cx + 
                    "\ncy: " + Circle.myCircles[i].cy +
                    "\nr: " + Circle.myCircles[i].r +
                    "\nstroke: " + Circle.myCircles[i].stroke +
                    "\nstroke-width: " + Circle.myCircles[i].stroke_width +
                    "\nfill: " + Circle.myCircles[i].fill);
                }
            }
            else    // if you have no circles
            {
                Console.WriteLine("You have no Circles.");
            }Shape.svgActions(); break;
                                    
            case "rectangle":
            if(Rectangle.myRectangles.Any()) 
            {
                Console.WriteLine("You have " + Rectangle.myRectangles.Count + " Rectangles:");
                for (int i = 0; i < Rectangle.myRectangles.Count; i++)
                {
                    Console.WriteLine("\nRectangle number " + i + ": ");
                    Console.WriteLine("x: " + Rectangle.myRectangles[i].x + 
                    "\ny: " + Rectangle.myRectangles[i].y +
                    "\nwidth: " + Rectangle.myRectangles[i].width +
                    "\nheight: " + Rectangle.myRectangles[i].height +
                    "\nstroke: " + Rectangle.myRectangles[i].stroke +
                    "\nstroke-width: " + Rectangle.myRectangles[i].stroke_width +
                    "\nfill: " + Rectangle.myRectangles[i].fill);
                }
            }
            else
            {
                Console.WriteLine("You have no Rectangles.");
            }Shape.svgActions(); break;

            case "ellipse":
            if(Ellipse.myEllipse.Any()) 
            {
                Console.WriteLine("You have " + Ellipse.myEllipse.Count + " Ellipses:");
                for (int i = 0; i < Ellipse.myEllipse.Count; i++)
                {
                    Console.WriteLine("\nEllipse number " + i + ": ");
                    Console.WriteLine("cx: " + Ellipse.myEllipse[i].cx + 
                    "\ncy: " + Ellipse.myEllipse[i].cy +
                    "\nrx: " + Ellipse.myEllipse[i].rx +
                    "\nry: " + Ellipse.myEllipse[i].ry +
                    "\nstroke: " + Ellipse.myEllipse[i].stroke +
                    "\nstroke-width: " + Ellipse.myEllipse[i].stroke_width +
                    "\nfill: " + Ellipse.myEllipse[i].fill);
                }
            }
            else
            {
                Console.WriteLine("You have no Ellipses.");
            }Shape.svgActions(); break;

            case "line":
            if(Line.myLine.Any()) 
            {
                Console.WriteLine("You have " + Line.myLine.Count + " Lines:");
                for (int i = 0; i < Line.myLine.Count; i++)
                {
                    Console.WriteLine("\nLine number " + i + ": ");
                    Console.WriteLine("x1: " + Line.myLine[i].x1 + 
                    "\nx2: " + Line.myLine[i].x2 +
                    "\ny1: " + Line.myLine[i].y1 +
                    "\ny2: " + Line.myLine[i].y2 +
                    "\nstroke: " + Line.myLine[i].stroke +
                    "\nstroke-width: " + Line.myLine[i].stroke_width);
                }
            }
            else
            {
                Console.WriteLine("You have no Lines.");
            }Shape.svgActions(); break;

            case "polyline":
            if(Polyline.myPolyline.Any()) 
            {
                Console.WriteLine("You have " + Polyline.myPolyline.Count + " Polylines:");
                for (int i = 0; i < Polyline.myPolyline.Count; i++)
                {
                    Console.WriteLine("\nPolyline number " + i + ": ");
                    Console.WriteLine("points: " + Polyline.myPolyline[i].points + 
                    "\nstroke: " + Polyline.myPolyline[i].stroke +
                    "\nstroke-width: " + Polyline.myPolyline[i].stroke_width +
                    "\nfill: " + Polyline.myPolyline[i].fill);
                }
            }
            else
            {
                Console.WriteLine("You have no Polylines.");
            }Shape.svgActions(); break;

            case "polygon":
            if(Polygon.myPolygon.Any()) 
            {
                Console.WriteLine("You have " + Polygon.myPolygon.Count + " Polygons:");
                for (int i = 0; i < Polygon.myPolygon.Count; i++)
                {
                    Console.WriteLine("\nPolygon number " + i + ": ");
                    Console.WriteLine("points: " + Polygon.myPolygon[i].points + 
                    "\nstroke: " + Polygon.myPolygon[i].stroke +
                    "\nstroke-width: " + Polygon.myPolygon[i].stroke_width +
                    "\nfill: " + Polygon.myPolygon[i].fill);
                }
            }
            else
            {
                Console.WriteLine("You have no Polygons.");
            }Shape.svgActions(); break;

            case "path":
            if(Path.myPath.Any()) 
            {
                Console.WriteLine("You have " + Path.myPath.Count + " Paths:");
                for (int i = 0; i < Path.myPath.Count; i++)
                {
                    Console.WriteLine("\nPath number " + i + ": ");
                    Console.WriteLine("Path: " + Path.myPath[i].points + 
                    "\nstroke: " + Path.myPath[i].stroke +
                    "\nstroke-width: " + Path.myPath[i].stroke_width +
                    "\nfill: " + Path.myPath[i].fill);
                }
            }
            else
            {
                Console.WriteLine("You have no Paths.");
            }Shape.svgActions(); break;
            default: Console.WriteLine("No such shape exists, try again."); Shape.svgActions(); break;
        }
    }
    public static void updateShape()    //Method to update any shape that you have
    {
        Console.WriteLine("\nWhich shape do you want to update?");
        availableShapes();

        switch(Console.ReadLine().ToLower())
        {
            case "circle":  //all comments apply 
            if(Circle.myCircles.Any()) 
            {
                Console.WriteLine("You have " + Circle.myCircles.Count + " Circles.");

                for (int i = 0; i < Circle.myCircles.Count; i++)    //print all the shapes with parameters
                {   
                    Console.WriteLine("Circle index " + i);
                    Console.WriteLine("cx: " + Circle.myCircles[i].cx + 
                    "\ncy: " + Circle.myCircles[i].cy +
                    "\nr: " + Circle.myCircles[i].r +
                    "\nstroke: " + Circle.myCircles[i].stroke +
                    "\nstroke-width: " + Circle.myCircles[i].stroke_width +
                    "\nfill: " + Circle.myCircles[i].fill + "\n");
                }
                Console.WriteLine("\nInput the index of a circle you want to update (indexes 0-" + (Circle.myCircles.Count-1) + ").");

                try
                {
                    int numCircle = Int32.Parse(Console.ReadLine());
                    while(true)
                    {
                        if (numCircle > (Circle.myCircles.Count-1) && numCircle < 0)
                            Console.WriteLine("Please specify indext ranging between 0 and " + (Circle.myCircles.Count-1) + " inclusive.");
                        else
                        {
                            Console.WriteLine("Which parameter would you like to edit?");
                            Console.WriteLine("cx: " + Circle.myCircles[numCircle].cx + 
                                                "\ncy: " + Circle.myCircles[numCircle].cy +
                                                "\nr: " + Circle.myCircles[numCircle].r +
                                                "\nstroke: " + Circle.myCircles[numCircle].stroke +
                                                "\nstroke-width: " + Circle.myCircles[numCircle].stroke_width +
                                                "\nfill: " + Circle.myCircles[numCircle].fill);
                            
                            string parameter = Console.ReadLine();
                            if (parameter == "cx")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Circle.myCircles[numCircle].cx = int.Parse(Console.ReadLine());
                                Console.WriteLine("cx value of Circle " + numCircle + " has been changed to " + Circle.myCircles[numCircle].cx + ".");
                                break;
                            }
                            else if (parameter == "cy")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Circle.myCircles[numCircle].cy = int.Parse(Console.ReadLine());
                                Console.WriteLine("cy value of Circle " + numCircle + " has been changed to " + Circle.myCircles[numCircle].cy + ".");
                                break;
                            }
                            else if (parameter == "r")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Circle.myCircles[numCircle].r = int.Parse(Console.ReadLine());
                                Console.WriteLine("r value of Circle " + numCircle + " has been changed to " + Circle.myCircles[numCircle].r + ".");
                                break;
                            }
                            else if (parameter == "stroke")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Circle.myCircles[numCircle].stroke = Console.ReadLine();
                                Console.WriteLine("stroke value of Circle " + numCircle + " has been changed to " + Circle.myCircles[numCircle].stroke + ".");
                                break;
                            }
                            else if (parameter == "stroke-width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Circle.myCircles[numCircle].stroke_width = int.Parse(Console.ReadLine());
                                Console.WriteLine("stroke-width value of Circle " + numCircle + " has been changed to " + Circle.myCircles[numCircle].stroke_width + ".");
                                break;
                            }
                            else if (parameter == "fill")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Circle.myCircles[numCircle].fill = Console.ReadLine();
                                Console.WriteLine("fill value of Circle " + numCircle + " has been changed to " + Circle.myCircles[numCircle].fill + ".");
                                break;
                            }
                            else
                                Console.WriteLine("No such parameter, try a different one.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please input a valid index number. \n");
                }
            }
            else
            {
                Console.WriteLine("You don't have any Circles. Select another operation \n");
            }Shape.svgActions(); break;

            case "rectangle":
            if(Rectangle.myRectangles.Any()) 
            {
                Console.WriteLine("You have " + Rectangle.myRectangles.Count + " Rectangles.");

                for (int i = 0; i < Rectangle.myRectangles.Count; i++)
                {   
                    Console.WriteLine("Rectangle index " + i);
                    Console.WriteLine("x: " + Rectangle.myRectangles[i].x + 
                    "\ny: " + Rectangle.myRectangles[i].y +
                    "\nwidth: " + Rectangle.myRectangles[i].width +
                    "\nheight: " + Rectangle.myRectangles[i].height +
                    "\nstroke: " + Rectangle.myRectangles[i].stroke +
                    "\nstroke-width: " + Rectangle.myRectangles[i].stroke_width +
                    "\nfill: " + Rectangle.myRectangles[i].fill + "\n");
                }
                Console.WriteLine("\nInput the index of a Rectangle you want to update (indexes 0-" + (Rectangle.myRectangles.Count-1) + ").");

                try
                {
                    int numRectangle = Int32.Parse(Console.ReadLine());
                    while(true)
                    {
                        if (numRectangle > (Rectangle.myRectangles.Count-1) && numRectangle < 0)
                            Console.WriteLine("Please specify indext ranging between 0 and " + (Rectangle.myRectangles.Count-1) + " inclusive.");
                        else
                        {
                            Console.WriteLine("Which parameter would you like to edit?");
                            Console.WriteLine("x: " + Rectangle.myRectangles[numRectangle].x + 
                                                "\ny: " + Rectangle.myRectangles[numRectangle].y +
                                                "\nwidth: " + Rectangle.myRectangles[numRectangle].width +
                                                "\nheight: " + Rectangle.myRectangles[numRectangle].height +
                                                "\nstroke: " + Rectangle.myRectangles[numRectangle].stroke +
                                                "\nstroke-width: " + Rectangle.myRectangles[numRectangle].stroke_width +
                                                "\nfill: " + Rectangle.myRectangles[numRectangle].fill);
                            
                            string parameter = Console.ReadLine();
                            if (parameter == "x")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Rectangle.myRectangles[numRectangle].x = int.Parse(Console.ReadLine());
                                Console.WriteLine("x value of Rectangle " + numRectangle + " has been changed to " + Rectangle.myRectangles[numRectangle].x + ".");
                                break;
                            }
                            else if (parameter == "y")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Rectangle.myRectangles[numRectangle].y = int.Parse(Console.ReadLine());
                                Console.WriteLine("y value of Rectangle " + numRectangle + " has been changed to " + Rectangle.myRectangles[numRectangle].y + ".");
                                break;
                            }
                            else if (parameter == "width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Rectangle.myRectangles[numRectangle].width = int.Parse(Console.ReadLine());
                                Console.WriteLine("width value of Rectangle " + numRectangle + " has been changed to " + Rectangle.myRectangles[numRectangle].width + ".");
                                break;
                            }
                            else if (parameter == "height")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Rectangle.myRectangles[numRectangle].height = int.Parse(Console.ReadLine());
                                Console.WriteLine("height value of Rectangle " + numRectangle + " has been changed to " + Rectangle.myRectangles[numRectangle].height + ".");
                                break;
                            }
                            else if (parameter == "stroke")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Rectangle.myRectangles[numRectangle].stroke = Console.ReadLine();
                                Console.WriteLine("stroke value of Rectangle " + numRectangle + " has been changed to " + Rectangle.myRectangles[numRectangle].stroke + ".");
                                break;
                            }
                            else if (parameter == "stroke-width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Rectangle.myRectangles[numRectangle].stroke_width = int.Parse(Console.ReadLine());
                                Console.WriteLine("stroke-width value of Rectangle " + numRectangle + " has been changed to " + Rectangle.myRectangles[numRectangle].stroke_width + ".");
                                break;
                            }
                            else if (parameter == "fill")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Rectangle.myRectangles[numRectangle].fill = Console.ReadLine();
                                Console.WriteLine("fill value of Rectangle " + numRectangle + " has been changed to " + Rectangle.myRectangles[numRectangle].fill + ".");
                                break;
                            }
                            else
                                Console.WriteLine("No such parameter, try a different one.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please input a valid index number. \n");
                }
            }
            else
            {
                Console.WriteLine("You don't have any Rectangles. Select another operation \n");
            }Shape.svgActions(); break;
        
            case "ellipse":
            if(Ellipse.myEllipse.Any()) 
            {
                Console.WriteLine("You have " + Ellipse.myEllipse.Count + " Ellipses.");

                for (int i = 0; i < Ellipse.myEllipse.Count; i++)
                {   
                    Console.WriteLine("Ellipse index " + i);
                    Console.WriteLine("cx: " + Ellipse.myEllipse[i].cx + 
                    "\ncy: " + Ellipse.myEllipse[i].cy +
                    "\nrx: " + Ellipse.myEllipse[i].rx +
                    "\nry: " + Ellipse.myEllipse[i].ry +
                    "\nstroke: " + Ellipse.myEllipse[i].stroke +
                    "\nstroke-width: " + Ellipse.myEllipse[i].stroke_width +
                    "\nfill: " + Ellipse.myEllipse[i].fill + "\n");
                }
                Console.WriteLine("\nInput the index of a Ellipse you want to update (indexes 0-" + (Ellipse.myEllipse.Count-1) + ").");

                try
                {
                    int numEllipse = Int32.Parse(Console.ReadLine());
                    while(true)
                    {
                        if (numEllipse > (Ellipse.myEllipse.Count-1) && numEllipse < 0)
                            Console.WriteLine("Please specify indext ranging between 0 and " + (Ellipse.myEllipse.Count-1) + " inclusive.");
                        else
                        {
                            Console.WriteLine("Which parameter would you like to edit?");
                            Console.WriteLine("cx: " + Ellipse.myEllipse[numEllipse].cx + 
                                                "\ncy: " + Ellipse.myEllipse[numEllipse].cy +
                                                "\nrx: " + Ellipse.myEllipse[numEllipse].rx +
                                                "\nry: " + Ellipse.myEllipse[numEllipse].ry +
                                                "\nstroke: " + Ellipse.myEllipse[numEllipse].stroke +
                                                "\nstroke-width: " + Ellipse.myEllipse[numEllipse].stroke_width +
                                                "\nfill: " + Ellipse.myEllipse[numEllipse].fill);
                            
                            string parameter = Console.ReadLine();
                            if (parameter == "cx")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Ellipse.myEllipse[numEllipse].cx = int.Parse(Console.ReadLine());
                                Console.WriteLine("cx value of Ellipse " + numEllipse + " has been changed to " + Ellipse.myEllipse[numEllipse].cx + ".");
                                break;
                            }
                            else if (parameter == "cy")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Ellipse.myEllipse[numEllipse].cy = int.Parse(Console.ReadLine());
                                Console.WriteLine("cy value of Ellipse " + numEllipse + " has been changed to " + Ellipse.myEllipse[numEllipse].cy + ".");
                                break;
                            }
                            else if (parameter == "rx")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Ellipse.myEllipse[numEllipse].rx = int.Parse(Console.ReadLine());
                                Console.WriteLine("rx value of Ellipse " + numEllipse + " has been changed to " + Ellipse.myEllipse[numEllipse].rx + ".");
                                break;
                            }
                            else if (parameter == "ry")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Ellipse.myEllipse[numEllipse].ry = int.Parse(Console.ReadLine());
                                Console.WriteLine("ry value of Ellipse " + numEllipse + " has been changed to " + Ellipse.myEllipse[numEllipse].ry + ".");
                                break;
                            }
                            else if (parameter == "stroke")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Ellipse.myEllipse[numEllipse].stroke = Console.ReadLine();
                                Console.WriteLine("stroke value of Ellipse " + numEllipse + " has been changed to " + Ellipse.myEllipse[numEllipse].stroke + ".");
                                break;
                            }
                            else if (parameter == "stroke-width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Ellipse.myEllipse[numEllipse].stroke_width = int.Parse(Console.ReadLine());
                                Console.WriteLine("stroke-width value of Ellipse " + numEllipse + " has been changed to " + Ellipse.myEllipse[numEllipse].stroke_width + ".");
                                break;
                            }
                            else if (parameter == "fill")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Ellipse.myEllipse[numEllipse].fill = Console.ReadLine();
                                Console.WriteLine("fill value of Ellipse " + numEllipse + " has been changed to " + Ellipse.myEllipse[numEllipse].fill + ".");
                                break;
                            }
                            else
                                Console.WriteLine("No such parameter, try a different one.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please input a valid index number. \n");
                }
            }
            else
            {
                Console.WriteLine("You don't have any Ellipses. Select another operation \n");
            }Shape.svgActions(); break;
            
            case "line":
            if(Line.myLine.Any()) 
            {
                Console.WriteLine("You have " + Line.myLine.Count + " Lines.");

                for (int i = 0; i < Line.myLine.Count; i++)
                {   
                    Console.WriteLine("Line index " + i);
                    Console.WriteLine("x1: " + Line.myLine[i].x1 + 
                    "\nx2: " + Line.myLine[i].x2 +
                    "\ny1: " + Line.myLine[i].y1 +
                    "\ny2: " + Line.myLine[i].y2 +
                    "\nstroke: " + Line.myLine[i].stroke +
                    "\nstroke-width: " + Line.myLine[i].stroke_width + "\n");
                }
                Console.WriteLine("\nInput the index of a Line you want to update (indexes 0-" + (Line.myLine.Count-1) + ").");

                try
                {
                    int numLine = Int32.Parse(Console.ReadLine());
                    while(true)
                    {
                        if (numLine > (Line.myLine.Count-1) && numLine < 0)
                            Console.WriteLine("Please specify indext ranging between 0 and " + (Line.myLine.Count-1) + " inclusive.");
                        else
                        {
                            Console.WriteLine("Which parameter would you like to edit?");
                            Console.WriteLine("x1: " + Line.myLine[numLine].x1 + 
                                                "\nx2: " + Line.myLine[numLine].x2 +
                                                "\ny1: " + Line.myLine[numLine].y1 +
                                                "\ny2: " + Line.myLine[numLine].y2 +
                                                "\nstroke: " + Line.myLine[numLine].stroke +
                                                "\nstroke-width: " + Line.myLine[numLine].stroke_width);
                            
                            string parameter = Console.ReadLine();
                            if (parameter == "x1")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Line.myLine[numLine].x1 = int.Parse(Console.ReadLine());
                                Console.WriteLine("x1 value of Line " + numLine + " has been changed to " + Line.myLine[numLine].x1 + ".");
                                break;
                            }
                            else if (parameter == "x2")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Line.myLine[numLine].x2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("x2 value of Line " + numLine + " has been changed to " + Line.myLine[numLine].x2 + ".");
                                break;
                            }
                            else if (parameter == "y1")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Line.myLine[numLine].y1 = int.Parse(Console.ReadLine());
                                Console.WriteLine("y1 value of Line " + numLine + " has been changed to " + Line.myLine[numLine].y1 + ".");
                                break;
                            }
                            else if (parameter == "y2")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Line.myLine[numLine].y2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("y2 value of Line " + numLine + " has been changed to " + Line.myLine[numLine].y2 + ".");
                                break;
                            }
                            else if (parameter == "stroke")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Line.myLine[numLine].stroke = Console.ReadLine();
                                Console.WriteLine("stroke value of Line " + numLine + " has been changed to " + Line.myLine[numLine].stroke + ".");
                                break;
                            }
                            else if (parameter == "stroke-width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Line.myLine[numLine].stroke_width = int.Parse(Console.ReadLine());
                                Console.WriteLine("stroke-width value of Line " + numLine + " has been changed to " + Line.myLine[numLine].stroke_width + ".");
                                break;
                            }
                            else
                                Console.WriteLine("No such parameter, try a different one.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please input a valid index number. \n");
                }
            }
            else
            {
                Console.WriteLine("You don't have any Lines. Select another operation \n");
            }Shape.svgActions(); break;

            case "polyline":
            if(Polyline.myPolyline.Any()) 
            {
                Console.WriteLine("You have " + Polyline.myPolyline.Count + " Polylines.");

                for (int i = 0; i < Polyline.myPolyline.Count; i++)
                {   
                    Console.WriteLine("Polyline index " + i);
                    Console.WriteLine("path: " + Polyline.myPolyline[i].points + 
                    "\nstroke: " + Polyline.myPolyline[i].stroke +
                    "\nstroke-width: " + Polyline.myPolyline[i].stroke_width +
                    "\nfill: " + Polyline.myPolyline[i].fill + "\n");
                }
                Console.WriteLine("\nInput the index of a Polyline you want to update (indexes 0-" + (Polyline.myPolyline.Count-1) + ").");

                try
                {
                    int numPolyline = Int32.Parse(Console.ReadLine());
                    while(true)
                    {
                        if (numPolyline > (Polyline.myPolyline.Count-1) && numPolyline < 0)
                            Console.WriteLine("Please specify indext ranging between 0 and " + (Polyline.myPolyline.Count-1) + " inclusive.");
                        else
                        {
                            Console.WriteLine("Which parameter would you like to edit?");
                            Console.WriteLine("path: " + Polyline.myPolyline[numPolyline].points + 
                                                "\nstroke: " + Polyline.myPolyline[numPolyline].stroke +
                                                "\nstroke-width: " + Polyline.myPolyline[numPolyline].stroke_width +
                                                "\nfill: " + Polyline.myPolyline[numPolyline].fill);
                            
                            string parameter = Console.ReadLine();
                            if (parameter == "path")
                            {
                                Console.WriteLine("Enter your new Polyline Path:");
                                Polyline.myPolyline[numPolyline].points = Console.ReadLine();
                                Console.WriteLine("path value of Polyline " + numPolyline + " has been changed to " + Polyline.myPolyline[numPolyline].points + ".");
                                break;
                            }
                            else if (parameter == "stroke")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Polyline.myPolyline[numPolyline].stroke = Console.ReadLine();
                                Console.WriteLine("stroke value of Polyline " + numPolyline + " has been changed to " + Polyline.myPolyline[numPolyline].stroke + ".");
                                break;
                            }
                            else if (parameter == "stroke-width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Polyline.myPolyline[numPolyline].stroke_width = int.Parse(Console.ReadLine());
                                Console.WriteLine("stroke-width value of Polyline " + numPolyline + " has been changed to " + Polyline.myPolyline[numPolyline].stroke_width + ".");
                                break;
                            }
                            else if (parameter == "fill")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Polyline.myPolyline[numPolyline].fill = Console.ReadLine();
                                Console.WriteLine("fill value of Polyline " + numPolyline + " has been changed to " + Polyline.myPolyline[numPolyline].fill + ".");
                                break;
                            }
                            else
                                Console.WriteLine("No such parameter, try a different one.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please input a valid index number. \n");
                }
            }
            else
            {
                Console.WriteLine("You don't have any Polylines. Select another operation \n");
            }Shape.svgActions(); break;
        
            case "polygon":
            if(Polygon.myPolygon.Any()) 
            {
                Console.WriteLine("You have " + Polygon.myPolygon.Count + " Polygons.");

                for (int i = 0; i < Polygon.myPolygon.Count; i++)
                {   
                    Console.WriteLine("Polygon index " + i);
                    Console.WriteLine("path: " + Polygon.myPolygon[i].points + 
                    "\nstroke: " + Polygon.myPolygon[i].stroke +
                    "\nstroke-width: " + Polygon.myPolygon[i].stroke_width +
                    "\nfill: " + Polygon.myPolygon[i].fill + "\n");
                }
                Console.WriteLine("\nInput the index of a Polygon you want to update (indexes 0-" + (Polygon.myPolygon.Count-1) + ").");

                try
                {
                    int numPolygon = Int32.Parse(Console.ReadLine());
                    while(true)
                    {
                        if (numPolygon > (Polygon.myPolygon.Count-1) && numPolygon < 0)
                            Console.WriteLine("Please specify indext ranging between 0 and " + (Polygon.myPolygon.Count-1) + " inclusive.");
                        else
                        {
                            Console.WriteLine("Which parameter would you like to edit?");
                            Console.WriteLine("path: " + Polygon.myPolygon[numPolygon].points + 
                                                "\nstroke: " + Polygon.myPolygon[numPolygon].stroke +
                                                "\nstroke-width: " + Polygon.myPolygon[numPolygon].stroke_width +
                                                "\nfill: " + Polygon.myPolygon[numPolygon].fill);
                            
                            string parameter = Console.ReadLine();
                            if (parameter == "path")
                            {
                                Console.WriteLine("Enter your new Polygon Path:");
                                Polygon.myPolygon[numPolygon].points = Console.ReadLine();
                                Console.WriteLine("path value of Polygon " + numPolygon + " has been changed to " + Polygon.myPolygon[numPolygon].points + ".");
                                break;
                            }
                            else if (parameter == "stroke")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Polygon.myPolygon[numPolygon].stroke = Console.ReadLine();
                                Console.WriteLine("stroke value of Polygon " + numPolygon + " has been changed to " + Polygon.myPolygon[numPolygon].stroke + ".");
                                break;
                            }
                            else if (parameter == "stroke-width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Polygon.myPolygon[numPolygon].stroke_width = int.Parse(Console.ReadLine());
                                Console.WriteLine("stroke-width value of Polygon " + numPolygon + " has been changed to " + Polygon.myPolygon[numPolygon].stroke_width + ".");
                                break;
                            }
                            else if (parameter == "fill")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Polygon.myPolygon[numPolygon].fill = Console.ReadLine();
                                Console.WriteLine("fill value of Polygon " + numPolygon + " has been changed to " + Polygon.myPolygon[numPolygon].fill + ".");
                                break;
                            }
                            else
                                Console.WriteLine("No such parameter, try a different one.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please input a valid index number. \n");
                }
            }
            else
            {
                Console.WriteLine("You don't have any Polygons. Select another operation \n");
            }Shape.svgActions(); break;
            
            case "path":
            if(Path.myPath.Any()) 
            {
                Console.WriteLine("You have " + Path.myPath.Count + " Paths.");

                for (int i = 0; i < Path.myPath.Count; i++)
                {   
                    Console.WriteLine("Path index " + i);
                    Console.WriteLine("path: " + Path.myPath[i].points + 
                    "\nstroke: " + Path.myPath[i].stroke +
                    "\nstroke-width: " + Path.myPath[i].stroke_width +
                    "\nfill: " + Path.myPath[i].fill + "\n");
                }
                Console.WriteLine("\nInput the index of a Path you want to update (indexes 0-" + (Path.myPath.Count-1) + ").");

                try
                {
                    int numPath = Int32.Parse(Console.ReadLine());
                    while(true)
                    {
                        if (numPath > (Path.myPath.Count-1) && numPath < 0)
                            Console.WriteLine("Please specify indext ranging between 0 and " + (Path.myPath.Count-1) + " inclusive.");
                        else
                        {
                            Console.WriteLine("Which parameter would you like to edit?");
                            Console.WriteLine("path: " + Path.myPath[numPath].points + 
                                                "\nstroke: " + Path.myPath[numPath].stroke +
                                                "\nstroke-width: " + Path.myPath[numPath].stroke_width +
                                                "\nfill: " + Path.myPath[numPath].fill);
                            
                            string parameter = Console.ReadLine();
                            if (parameter == "path")
                            {
                                Console.WriteLine("Enter your new Path:");
                                Path.myPath[numPath].points = Console.ReadLine();
                                Console.WriteLine("path value of Path " + numPath + " has been changed to " + Path.myPath[numPath].points + ".");
                                break;
                            }
                            else if (parameter == "stroke")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Path.myPath[numPath].stroke = Console.ReadLine();
                                Console.WriteLine("stroke value of Path " + numPath + " has been changed to " + Path.myPath[numPath].stroke + ".");
                                break;
                            }
                            else if (parameter == "stroke-width")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Path.myPath[numPath].stroke_width = int.Parse(Console.ReadLine());
                                Console.WriteLine("stroke-width value of Path " + numPath + " has been changed to " + Path.myPath[numPath].stroke_width + ".");
                                break;
                            }
                            else if (parameter == "fill")
                            {
                                Console.WriteLine("Enter your new parameter value:");
                                Path.myPath[numPath].fill = Console.ReadLine();
                                Console.WriteLine("fill value of Path " + numPath + " has been changed to " + Path.myPath[numPath].fill + ".");
                                break;
                            }
                            else
                                Console.WriteLine("No such parameter, try a different one.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please input a valid index number. \n");
                }
            }
            else
            {
                Console.WriteLine("You don't have any Paths. Select another operation \n");
            }Shape.svgActions(); break;
            default: Console.WriteLine("No such shape, try another operation."); break;
        }
    }
    public static string randomColourSelector() //Method that selects a random colour and returns it
    {
        Random rnd = new Random(); // random number generator
        string [] colourArray = {"aquamarine", "black", "blueviolet", "chartreuse", "darkseagreen", "green", "red", "blue", "orange",
        "yellow", "darkmagenta", "darksalmon", "darkslategray", "firebrick", "gold", "forestgreen", "hotpink", "pink", "lightgreen"};

        return colourArray[rnd.Next(0, colourArray.Length-1)]; //return random color
    }
    public static void defaultShape()   //Method that creates a default shape

    {
        Shape.availableShapes();
        switch (Console.ReadLine().ToLower())   //switch between different shapes
        {
            case "circle": myCircles.Add(new Circle()); Console.WriteLine("A default Circle has been created! \n"); Shape.svgActions(); break; //put a shape with default parameters
            case "rectangle": myRectangles.Add(new Rectangle()); Console.WriteLine("A default Rectangle has been created! \n"); Shape.svgActions(); break;//put a shape with default parameters
            case "ellipse": myEllipse.Add(new Ellipse()); Console.WriteLine("A default Ellipse has been created! \n"); Shape.svgActions(); break;//put a shape with default parameters
            case "line": myLine.Add(new Line()); Console.WriteLine("A default Line has been created! \n"); Shape.svgActions(); break;//put a shape with default parameters
            case "polyline": //just an algorithm that applies a default number to points so that a shape can be added in different spots without losing it's shape
                myPolyline.Add(new Polyline()); //create a new object parameterized
                Console.WriteLine("A default Polyline has been created! \n"); Shape.svgActions(); break;
            case "polygon": //just an algorithm that applies a default number to points so that a shape can be added in different spots without losing it's shape
                myPolygon.Add(new Polygon()); //create parameterized object
                Console.WriteLine("A default Polygon has been created! \n"); Shape.svgActions(); break;
            case "path": 
                myPath.Add(new Path());
                Console.WriteLine("A default Path has been created! \n"); Shape.svgActions(); break; // create a polyline Object and store it into a list of objects
            default: Console.WriteLine("Incorrect shape, please try another operation.\n"); Shape.svgActions(); break;
        }
    }
    public static void groupShapes()    //Method to group up individual shapes
    {
        while(true)
        {
            if (!svgShapes.Contains("<g>"))
            {
                Console.WriteLine("Select the index of a shape you want to put in a group:");
                for (int i = 0; i < svgShapes.Count; i++)   //display all the shapes in svg format
                {
                    Console.WriteLine("|index " + i + "|" + svgShapes[i]);
                }

                int groupIndex = int.Parse(Console.ReadLine());

                svgShapes.Insert(groupIndex, "<g>");
                svgShapes.Insert(groupIndex+2, "</g>");

                Console.WriteLine("Do you want to put another shape into a group? Y/N");
                string yesNo = Console.ReadLine();
                if (yesNo.Equals("N", StringComparison.InvariantCultureIgnoreCase)) //if he doesn't, we are finished
                {
                    svgActions();
                    break;
                }
                else if (!yesNo.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("You didn't type Y, terminating operation.");
                    break;
                }
            }   
            else
            {
                while(true)
                {
                    Console.WriteLine("Select the index of a shape you want to put in a group:");
                    for (int i = 0; i < svgShapes.Count; i++)   //display all the shapes in svg format
                    {
                        Console.WriteLine("|index " + i + "|" + svgShapes[i]);
                    }

                    int groupIndex = int.Parse(Console.ReadLine());

                    if (svgShapes[groupIndex] == "<g>" || svgShapes[groupIndex] == "</g>")  // wrong index selected
                    {
                        Console.WriteLine("You have selected an index with a group tag. Please chose and index that contains a shape.");
                    }
                    else    // if index selected doesnt have <g> or </g>
                    {
                        string temp = svgShapes[groupIndex];
                        svgShapes.RemoveAt(groupIndex); // remove old element

                        int index;
                        index = svgShapes.IndexOf("</g>");  // find the end of our group

                        svgShapes.Insert(index, temp);  // insert at the end of our group
                    }

                    Console.WriteLine("Do you want to put another shape into a group? Y/N");
                    string yesNo = Console.ReadLine();
                    if (yesNo.Equals("N", StringComparison.InvariantCultureIgnoreCase)) //if he doesn't, we are finished
                    {
                        svgActions();
                        break;
                    }
                    else if (!yesNo.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("You didn't type Y, terminating operation.");
                        break;
                    }
                }
                break;
            }
        }
    }
    public static void unGroupShapes()  //Method to ungroup all the shapes
    {
        int indexOpen;
        int indexClose;
        indexOpen = svgShapes.IndexOf("<g>");  // find the group tag
        svgShapes.RemoveAt(indexOpen);

        indexClose = svgShapes.IndexOf("</g>");
        svgShapes.RemoveAt(indexClose);

        Console.WriteLine("All shapes have been ungrouped.");
        svgActions();
    }
    public static void addGroupStyle()  // Method changing syles for fill, stroke, width and applying various translations and transformations
    {
        if (svgShapes.Contains("<g>"))
        {
            int indexOpen;
            indexOpen = svgShapes.IndexOf("<g>");

            Console.WriteLine("Type youre desired fill colour for the group");
            string fill = Console.ReadLine();
            Console.WriteLine("Type youre desired stroke colour for the group");
            string stroke = Console.ReadLine();
            Console.WriteLine("Type youre desired stroke-width number for the group");
            string stroke_width = Console.ReadLine();

            //changing syles for fill, stroke, width and applying various translations and transformations
            svgShapes[indexOpen] = String.Format(@"<g fill=""{0}"" stroke=""{1}"" stroke-width=""{2}"" transform=""rotate(-10 50 100) 
            translate(-36 45.5) skewX(40) scale(1 0.5)"">", fill, stroke, stroke_width);

            Console.WriteLine("\nStyle changes and default transformations have been applied to group of shapes");

            Console.WriteLine("Do you want to set your own transformations for: Rotate | Translate | Skew | Scale? Y/N");
            string yesNo = Console.ReadLine();
            if (yesNo.Equals("Y", StringComparison.InvariantCultureIgnoreCase)) //if he doesn't, we are finished
            {
                Console.WriteLine("Type your values for Rotate in form of <rotate(x)>, where x is your input");
                string rotate = Console.ReadLine();
                Console.WriteLine("Type your values for Translate in form of <translate(x)>, where x is your input");
                Console.WriteLine("Please be careful, inaccurate values can potentially erase shape from canvas");
                string translate = Console.ReadLine();
                Console.WriteLine("Type your values for SkewX in form of <skewX(x)>, where x is your input");
                Console.WriteLine("Please be careful, inaccurate values can potentially erase shape from canvas");
                string skewX = Console.ReadLine();
                Console.WriteLine("Type your values for Scale in form of <scale(x)>, where x is your input");
                Console.WriteLine("Please be careful, inaccurate values can potentially erase shape from canvas");
                string scale = Console.ReadLine();

                svgShapes[indexOpen] = String.Format(@"<g fill=""{0}"" stroke=""{1}"" stroke-width=""{2}"" transform=""rotate({3}) 
                translate({4}) skewX({5}) scale({6})"">", fill, stroke, stroke_width, rotate, translate, skewX, scale);

                Console.WriteLine("Your personal shape transformations have been applied to the group.");
            }

            Shape.svgActions();
        }
        else
            Console.WriteLine("You don't have any groups");
    }
    public static string randomFonts()
    {
        Random rnd = new Random();
        string [] rndFonts = {"italic", "verdana", "helvetica", "arial", "trajan", "futura", "bodoni", "frutiger", "sabon"};
        return rndFonts[rnd.Next(0, rndFonts.Length-1)];
    }
    public static void addText()
    {
        Console.WriteLine("\nDo you want to add randomly generated text or default text?");
        Console.WriteLine("1: Random Text and styles");
        Console.WriteLine("2: Default Text with default styles");

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("\nInput the text you want to display on canvas.");
                string text = Console.ReadLine();
                Random rnd = new Random();
                myText.Add(new Text(rnd.Next(0,600), rnd.Next(0,600), randomColourSelector(), randomFonts(), rnd.Next(20, 100), text)); Console.WriteLine("A Text has been created! \n"); Shape.svgActions(); break;//put a text with random parameters
            }
            else if (input == "2")
            {
                myText.Add(new Text()); Shape.svgActions(); break; //put a shape with default parameters
            }
            else
                Console.WriteLine("Please select either 1 for random or 2 for default.");
        }
    }
}

// <g fill="white" stroke="green" stroke-width="5">
//     <circle cx="40" cy="40" r="25" />
//     <circle cx="60" cy="60" r="25" />
//   </g>