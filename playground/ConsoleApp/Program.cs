﻿using Html2Pdf.Lib;
using Microsoft.Extensions.Logging;

var pathToSamples = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

//log provider
ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Debug);
});
ILogger logger = factory.CreateLogger("Program");


Console.WriteLine("Initializing HTML to PDF conversion...");


var arguments = new Arguments()
    // When jpeg compressing images use this quality (default 94)
    .SetImageQuality(80)

    // Do not print background
    .DoNotPrintBackground()

    // Do not load or print images
    .DoNotLoadOrPrintImages()

    // Do not use lossless compression on pdf objects
    .WithNoPdfCompression()

    // Do not make links to remote web pages
    .DisableExternalLinks()

    // Do not make local links
    .DisableInternalLinks()

    // The title of the generated pdf file (The title of the first document is used if not specified)
    .SetTitle("This is a sample PDF document")

    // Indicates whether the PDF should be generated in lower quality.
    .WithLowQuality()

    // Number of copies to print into the PDF file.
    .SetCopies(2)

    // Indicates whether the PDF should be generated in grayscale.
    .WithGrayScale()

    // Replace [name] with value in header and footer (repeatable)
    .Replace("HTML to PDF Test Page", "HTML to PDF Test Page - Sample 1")

    // Set the starting page number (default 0)
    .SetOffPageOffset(2)

    // Sets the page margins
    .SetPageMargins(10, 10, 10, 10)

    // Sets the page Width. Has priority over "SetPageSize" but "SetPageHeight" has to be also specified.
    .SetPageWidth(210)

    // Sets the page Height. Has priority over "SetPageSize" but "SetPageWidth" has to be also specified.
    .SetPageHeight(297)

    // Set the page Orientation
    .SetPageOrientation(PageOrientation.Landscape)

    // The default page size of the rendered document is A4.
    .SetPageSize(PageSize.A4)

    // Disable SmartSets the page size.
    .DisableSmartShrinking()

    // Turn HTML form fields into pdf form fields
    .EnableForms()

    // Display line below the header
    .DisplayHeaderLine()

    // Set header text
    .SetHeaderText("Header Text Sample 1", TextAlignment.Center, "Verdana", 15)

    // Spacing between footer and content in mm (default 0)
    .SetHeaderSpacing(23)

    // Display line above the footer
    .DisplayFooterLine()

    // Set footer text
    .SetFooterText("Footer Text Sample 1", TextAlignment.Center, "Verdana", 15)

    // Spacing between footer and content in mm (default 0)
    .SetFooterSpacing(23)

    //add current ILogger
    .AddLogger(logger)

    //set timeout convert to PDF
    .TimeoutConvert(10000);


var html =
    """
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>HTML to PDF Test</title>
        <style>
            body {
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 0;
                background-color: #f0f8ff;
            }
            header {
                background-color: #ff7f50;
                color: white;
                text-align: center;
                padding: 20px;
            }
            nav {
                display: flex;
                justify-content: space-around;
                background-color: #4682b4;
                padding: 10px;
            }
            nav a {
                color: white;
                text-decoration: none;
            }
            section {
                padding: 20px;
                display: flex;
                flex-wrap: wrap;
                gap: 20px;
                background-color: #f5f5f5;
            }
            article {
                background-color: #ffefd5;
                border: 2px solid #deb887;
                padding: 15px;
                flex: 1 1 calc(33.33% - 40px);
                box-shadow: 2px 2px 5px rgba(0,0,0,0.3);
            }
            footer {
                text-align: center;
                background-color: #2e8b57;
                color: white;
                padding: 10px;
            }
            .base64-image {
                width: 100%;
                max-width: 300px;
                display: block;
                margin: 0 auto;
            }
            .color-box {
                width: 100px;
                height: 100px;
                display: inline-block;
                margin: 5px;
            }
            form {
                background-color: #e6e6fa;
                padding: 20px;
                margin: 20px 0;
                border: 2px solid #8a2be2;
                border-radius: 10px;
            }
            form label {
                display: block;
                margin: 10px 0 5px;
            }
            form input, form textarea, form select, form button {
                width: 100%;
                padding: 10px;
                margin-bottom: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
            }
        </style>
    </head>
    <body>
        <header>
            <h1>Test HTML to PDF Conversion</h1>
            <p>A page with diverse elements to test your tool</p>
        </header>
        <nav>
            <a href="https://www.microsoft.com">Microsoft</a>
            <a href="https://www.google.com">Google</a>
            <a href="file:./myfile.txt</a>
        </nav>
        <section>
            <article>
                <h2>Article 1</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque facilisis.</p>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/w8AAn8C4iO5fwAAAABJRU5ErkJggg==" alt="Black dot" class="base64-image">
            </article>
            <article>
                <h2>Article 2</h2>
                <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==" alt="Blue square" class="base64-image">
            </article>
            <article>
                <h2>Article 3</h2>
                <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/w8AAn8C4iO5fwAAAABJRU5ErkJggg==" alt="Black dot" class="base64-image">
            </article>
            <article>
            <h2>Article 4</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque facilisis.</p>
                <img src="https://via.placeholder.com/300" alt="Placeholder Image" class="base64-image">
            </article>
                <article>
                    <h2>Article 5</h2>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    <img src="https://via.placeholder.com/150" alt="Placeholder Image" class="base64-image">
                </article>
                <article>
                    <h2>Article 6</h2>
                    <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                    <img src="https://via.placeholder.com/100" alt="Placeholder Image" class="base64-image">
                </article>
        </section>
        <section>
            <h2>Colors</h2>
            <div class="color-box" style="background-color: red;"></div>
            <div class="color-box" style="background-color: green;"></div>
            <div class="color-box" style="background-color: blue;"></div>
            <div class="color-box" style="background-color: yellow;"></div>
            <div class="color-box" style="background-color: purple;"></div>
        </section>
        <section>
            <h2>Feedback Form</h2>
            <form action="#" method="post">
                <label for="name">Name:</label>
                <input type="text" id="name" name="name" placeholder="Enter your name">
    
                <label for="email">Email:</label>
                <input type="text" id="email" name="email" placeholder="Enter your email">
    
                <label for="message">Message:</label>
                <textarea id="message" name="message" rows="5" placeholder="Your message..."></textarea>
    
                <label for="rating">Rating:</label>
                <select id="rating" name="rating">
                    <option value="excellent">Excellent</option>
                    <option value="good">Good</option>
                    <option value="average">Average</option>
                    <option value="poor">Poor</option>
                </select>
    
                <button type="submit">Submit</button>
            </form>
        </section>
        
    <br />
    
        <pre>
                             40m     41m     42m     43m     44m     45m     46m     47m
                    <span style="">  gYw  </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: white; ">  gYw  </span>
            <span style="">    1m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; ">  gYw   </span><span style="font-weight: bold; "></span><span style="font-weight: bold; background-color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: white; ">  gYw  </span>
            <span style="">   30m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; ">  gYw   </span><span style="color: dimgray; "></span><span style="background-color: dimgray; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: red; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: lime; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: yellow; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: #3333FF; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: fuchsia; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: aqua; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: white; color: dimgray; ">  gYw  </span>
            <span style=""> 1;30m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; ">  gYw   </span><span style="font-weight: bold; color: dimgray; "></span><span style="font-weight: bold; background-color: dimgray; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: red; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: lime; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: yellow; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: #3333FF; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: fuchsia; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: aqua; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: white; color: dimgray; ">  gYw  </span>
            <span style="">   31m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; ">  gYw   </span><span style="color: red; "></span><span style="background-color: dimgray; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: red; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: lime; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: yellow; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: #3333FF; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: fuchsia; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: aqua; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: white; color: red; ">  gYw  </span>
            <span style=""> 1;31m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; ">  gYw   </span><span style="font-weight: bold; color: red; "></span><span style="font-weight: bold; background-color: dimgray; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: red; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: lime; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: yellow; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: #3333FF; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: fuchsia; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: aqua; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: white; color: red; ">  gYw  </span>
            <span style="">   32m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; ">  gYw   </span><span style="color: lime; "></span><span style="background-color: dimgray; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: red; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: lime; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: yellow; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: #3333FF; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: fuchsia; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: aqua; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: white; color: lime; ">  gYw  </span>
            <span style=""> 1;32m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; ">  gYw   </span><span style="font-weight: bold; color: lime; "></span><span style="font-weight: bold; background-color: dimgray; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: red; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: lime; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: yellow; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: #3333FF; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: fuchsia; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: aqua; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: white; color: lime; ">  gYw  </span>
            <span style="">   33m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; ">  gYw   </span><span style="color: yellow; "></span><span style="background-color: dimgray; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: red; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: lime; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: yellow; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: #3333FF; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: fuchsia; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: aqua; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: white; color: yellow; ">  gYw  </span>
            <span style=""> 1;33m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; ">  gYw   </span><span style="font-weight: bold; color: yellow; "></span><span style="font-weight: bold; background-color: dimgray; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: red; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: lime; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: yellow; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: #3333FF; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: fuchsia; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: aqua; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: white; color: yellow; ">  gYw  </span>
            <span style="">   34m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; ">  gYw   </span><span style="color: #3333FF; "></span><span style="background-color: dimgray; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: red; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: lime; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: yellow; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: #3333FF; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: fuchsia; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: aqua; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: white; color: #3333FF; ">  gYw  </span>
            <span style=""> 1;34m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; ">  gYw   </span><span style="font-weight: bold; color: #3333FF; "></span><span style="font-weight: bold; background-color: dimgray; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: red; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: lime; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: yellow; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: #3333FF; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: fuchsia; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: aqua; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: white; color: #3333FF; ">  gYw  </span>
            <span style="">   35m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; ">  gYw   </span><span style="color: fuchsia; "></span><span style="background-color: dimgray; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: red; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: lime; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: yellow; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: #3333FF; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: fuchsia; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: aqua; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: white; color: fuchsia; ">  gYw  </span>
            <span style=""> 1;35m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; ">  gYw   </span><span style="font-weight: bold; color: fuchsia; "></span><span style="font-weight: bold; background-color: dimgray; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: red; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: lime; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: yellow; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: #3333FF; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: fuchsia; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: aqua; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: white; color: fuchsia; ">  gYw  </span>
            <span style="">   36m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; ">  gYw   </span><span style="color: aqua; "></span><span style="background-color: dimgray; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: red; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: lime; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: yellow; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: #3333FF; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: fuchsia; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: aqua; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: white; color: aqua; ">  gYw  </span>
            <span style=""> 1;36m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; ">  gYw   </span><span style="font-weight: bold; color: aqua; "></span><span style="font-weight: bold; background-color: dimgray; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: red; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: lime; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: yellow; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: #3333FF; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: fuchsia; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: aqua; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: white; color: aqua; ">  gYw  </span>
            <span style="">   37m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; ">  gYw   </span><span style="color: white; "></span><span style="background-color: dimgray; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: red; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: lime; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: yellow; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: #3333FF; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: fuchsia; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: aqua; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: white; color: white; ">  gYw  </span>
            <span style=""> 1;37m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; ">  gYw   </span><span style="font-weight: bold; color: white; "></span><span style="font-weight: bold; background-color: dimgray; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: red; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: lime; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: yellow; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: #3333FF; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: fuchsia; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: aqua; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: white; color: white; ">  gYw  </span>
        </pre>
        
        <footer>
            <p>&copy; 2024 HTML to PDF Test Page</p>
        </footer>
    </body>
    </html>
    """;
var resultHtml = Converter.FromHtml(html, arguments);
if (resultHtml.HasValue)
{
    File.WriteAllBytes(Path.Combine(pathToSamples, "html2pdfHtml.pdf"), resultHtml.Content!);
}
else
{
    Console.WriteLine($"Erro: {resultHtml.Error?.ToString()}");
}
resultHtml = Converter.FromHtml(Path.Combine(pathToSamples, "html2directpdfHtml.pdf"), html, arguments);
if (!resultHtml.HasValue)
{
    Console.WriteLine($"Erro: {resultHtml.Error?.ToString()}");
}


// ----------------------------------------------------------

var resultUrl = Converter.FromUrl(new("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)"), arguments);
if (resultUrl.HasValue)
{
    File.WriteAllBytes(Path.Combine(pathToSamples, "html2pdfUrl.pdf"), resultUrl.Content!);
}
else
{
    Console.WriteLine($"Erro: {resultUrl.Error?.ToString()}");
}
resultUrl = Converter.FromUrl(Path.Combine(pathToSamples, "html2DirectpdfUrl.pdf"), new("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)"), arguments);
if (!resultUrl.HasValue)
{
    Console.WriteLine($"Erro: {resultUrl.Error?.ToString()}");
}


// ----------------------------------------------------------

var razorTemplate =
"""
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <title>Customer Details</title>
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
        }
        th, td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        th {
            background-color: #f4f4f4;
            text-align: left;
        }
        tr { 
            page-break-inside: avoid; 
        }
    </style>
</head>
<body>
    <h1>Customer Details</h1>
    <p><strong>Name:</strong> @Model.CustomerName</p>
    <p><strong>Address:</strong> @Model.CustomerAddress</p>
    <p><strong>Phone Number:</strong> @Model.CustomerPhoneNumber</p>

    <h2>Products (@Model.Products.Count)</h2>
    @if(Model.Products.Any())
    {
        <table>
            <thead>
                <tr>
                    <th>Product Name</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var product in Model.Products)
                {
                    <tr>
                        <td>@product.Name</td>
                        <td>@product.Price.ToString("C")</td>
                    </tr>
                }
            </tbody>
        </table>
    } 
    else
    {
        <p>No products found.</p>
    }
</body>
</html>
""";

var lstprod = new List<Product>();
for (int i = 0; i < 20; i++)
{
    lstprod.Add(new Product($"Product{i}", 9.99m));
}

var order1 = new Order("Roberto Rivellino", "Rua S&atilde;o Jorge, 777", "+55 11 912345678", lstprod);

var resultRazorTemplate = Converter.FromRazorTemplate(razorTemplate, order1, arguments);
if (resultRazorTemplate.HasValue)
{
    File.WriteAllBytes(Path.Combine(pathToSamples, "html2pdfRazorTemplate.pdf"), resultRazorTemplate.Content!);
}
else
{
    Console.WriteLine($"Erro: {resultHtml.Error?.ToString()}");
}
resultRazorTemplate = Converter.FromRazorTemplate(
    Path.Combine(pathToSamples, "html2DirectpdfRazorTemplate.pdf"), razorTemplate, order1, arguments);
if (!resultRazorTemplate.HasValue)
{
    Console.WriteLine($"Erro: {resultRazorTemplate.Error?.ToString()}");
}


var order2 = new Order("Sócrates", "Rua das Alamedas, 888", "+55 11 912345678", [
    new("Product 1", 2.99m),
    new("Product 2", 4.99m),
    new("Product 3", 6.99m)
]);

var order3 = new Order("Biro Biro", "Avenida das Orquídeas, 999", "+55 11 912345678", [
    new("Product 1", 3.99m),
    new("Product 2", 5.99m),
]);

var order4 = new Order("Casagrande", "Estrada das Flores, 456", "+55 11 912345678", []);

var resultRazorTemplateList = Converter.FromRazorTemplateBatch(razorTemplate, [order1, order2, order3, order4], arguments);
for (int i = 0; i < resultRazorTemplateList.Count; i++)
{
    var itemresult = resultRazorTemplateList.ElementAt(i);
    if (itemresult.HasValue)
    {
        File.WriteAllBytes(Path.Combine(pathToSamples, $"html2pdfRazorTemplate{i}.pdf"), itemresult.Content!);
    }
    else
    {
        Console.WriteLine($"Erro: {itemresult.Error?.ToString()}");
    }
}

Console.WriteLine("End...");

public record Product(string Name, decimal Price);
public record Order(string CustomerName, string CustomerAddress, string CustomerPhoneNumber, List<Product> Products);