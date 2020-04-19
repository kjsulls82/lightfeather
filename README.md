# LighFeather Coding Challenge

## PreRequisites:<br />
.NET Core 3.1 <br />
Windows Terminal or Git Bash Terminal <br />
Postman <br />
Any browser of your liking (I recommend chrome) <br />

## Question 1: WebServer
 - To run the application you must 
   1) Open a windows terminal or git bash terminal 
   2) Navigate to ~/LightFeatherCodeChallenge/WebServer
   3) Run the following command: dotnet run
 - Once the WebServer is running, copy the link that says "Now listening on: https://localhost:23456" 
 - In postman, create a new POST request, paste the above link and send a payload with structure (i.e){	"Shift": 2,	"Message":    "bbbbb 122 ffffff" }. For this example, you will get a response of {"encodedMessage": "ddddd 122 hhhhhh"} and will also find
a file on disk c:\temp\encodedMessage.txt if successful.

## Question 2: WebComponent
- To run this application you must
  1) Open a windows terminal or git bash terminal 
  2) Navigate to ~/LightFeatherCodeChallenge/WebComponent
  3) Run the following command: dotnet run 
- Once the WebServer is running, copy the link that says "Now listening on: http://localhost:59056" and paste into your browser's URL. 

