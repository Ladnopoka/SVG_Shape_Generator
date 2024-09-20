# SVG Shape Generator
The SVG Shape Generator is a C# project designed to create and manipulate SVG shapes such as circles, rectangles, ellipses, polygons, lines, and more. This tool allows users to generate random shapes, group them, modify their properties, and export them to an SVG canvas. Developed and tested on Windows 10 using Visual Studio Code.

## Features
- **Shape Creation**: Create a variety of SVG shapes such as circles, rectangles, polygons, and lines.
- **Shape Management**: Read, update, and delete shapes. Modify shape parameters like position, size, stroke, and fill.
- **Group and Style**: Group shapes and apply styles like colors, stroke-width, and transformations (rotate, scale, skew).
- **Export to SVG**: Export all shapes to an SVG file with customizable z-index for layering shapes.
- **Random Shape Generation**: Generate shapes with random parameters and colors.
- **Text Addition**: Add random or default text with various styles and fonts to the SVG canvas.

## Supported Shapes
- **Circle**: Generates circles with customizable position, radius, stroke, and fill.
- **Rectangle**: Creates rectangles with customizable width, height, and colors.
- **Ellipse**: Allows for the creation of ellipses with adjustable radii.
- **Line**: Draws lines between two points with customizable stroke.
- **Polyline**: Generates complex shapes by connecting multiple points.
- **Polygon**: Creates polygons by connecting multiple points with edges.
- **Path**: Allows for drawing custom paths with complex commands.

## Prerequisites
- Visual Studio Code or any C# compatible IDE.
- .NET runtime installed on your machine.

## How to Use
Run the application through the command line. You will be prompted to choose an operation to perform:
bash
dotnet run
