public class Path : Polyline
{ 
    public Path() {points = "M20, 30 Q40,05 50,130 T40,230"; stroke = "blue"; stroke_width = 4; fill = "none";}
    public Path(string points, string stroke, int stroke_width, string fill) 
    {   
        this.points = points;
        this.stroke = stroke;
        this.stroke_width = stroke_width;
        this.fill = fill;
        toString();
    } 

    public override void toString()
    {
        svgShapes.Add("".PadLeft(3, ' ') + String.Format(@"<path d=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));
    }

    public override void deleteFromSVG()
    {
        int index;
        index = svgShapes.IndexOf("".PadLeft(3, ' ') + String.Format(@"<path d=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", points, stroke, stroke_width, fill));

        string temp = svgShapes[index];
        svgShapes.RemoveAt(index);
        svgShapes.Add(temp);
    }
}


// // common paths
// M 230 230 
// A 45 45 0 1 1 265 273 
// L 275 230 Z
// M 230 230 A 45 45 0 1 1 257 269 L 275 230 Z
// M 290 273 A 45 45 0 1 1 318 232 L 275 230 Z
// M 320 250 A 45 45 0 1 1 318 202 L 275 230 Z
// M 324 224 A 45 45 0 1 1 301 190 L 275 230 Z
// M 303 268 A 45 45 0 1 1 301 190 L 275 230 Z
// M 303 268 A 45 45 0 1 1 322 227 L 275 230 Z




// M 345 136 A 45 45 90 1 1 309 86 L 298 131 Z
// M 190 117 A 45 45 90 1 1 223 79 L 171 70 Z
// M 47 167 A 45 45 90 1 1 110 163 L 73 129 Z
// M 77 239 A 45 45 90 1 1 87 193 L 56 210 Z
// M 163 215 A 45 45 90 1 1 156 163 L 122 198 Z
// M 227 256 A 45 45 90 1 1 250 197 L 209 216 Z
// M 297 200 A 45 45 90 1 1 270 155 L 256 193 Z
// M 262 105 A 45 45 90 1 1 304 156 L 310 105 Z
// M 392 71 A 45 45 90 1 1 444 127 L 445 74 Z
// M 473 61 A 45 45 90 1 1 513 112 L 517 59 Z
// M 476 154 A 45 45 90 1 1 516 181 L 517 130 Z
// M 403 217 A 45 45 90 1 1 411 261 L 448 234 Z
// M 677 384 A 45 45 90 1 1 721 401 L 712 354 Z
// M 477 407 A 45 45 90 1 1 461 457 L 497 444 Z
// M 481 517 A 45 45 90 1 1 464 566 L 506 552 Z
// M 381 499 A 45 45 90 1 1 371 545 L 430 540 Z
