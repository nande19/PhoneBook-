# PhoneBook Application
VIEW IN  BROWSER USING GOOGLE CHROME! 

TECHNOLOGIES USED: 
Development Environment: Visual Studio 
Programming Language(s): C#, CSS, HTML, JavaScript 
Framework: .NET 8.0 (back-end) Bootstrap (front-end) 
Database: SQL Server 
Version Control: GitHub  
Build Tools and Package Managers: NuGet


DOWNLOAD + INSTALLATION + SETUP:  
ONCE YOU HAVE DOWNLOADED THE ZIPPED FOLDER: 
1. Right click on the downloaded folder (“Nande Mzantsi”) in your File Explorer 
2. Click on “Extract all” 
3. Once all the files have been extracted, click on the folder and open the “PhoneBook 
Application.sln” solution in Visual Studio.  
4. Once that solution is open, open your “Solution Explorer”.  
5. Click on the “appsettings.json” file.  
6. Change line 10 which is the Connection String titled “PhoneBookPortal” from this; 
"PhoneBookPortal": "Server=LAPTOP
PIF45UTQ;Database=DbPhoneBook;Trusted_Connection=True;TrustServerCertifica
 te=True" 
TO THIS  
"PhoneBookPortal": 
"Server=(localdb)\\mssqllocaldb;Database=DbPhoneBook;Trusted_Connection=Tr
 ue;TrustServerCertificate=True" 
7. Once that is changed, click on the Tools tab at the top of the screen 
8. Select/Hover over “NuGet Package Manager”  
9. Click on “Package Manager Console”  
10. Once the console is open, write the follow command [ Update-Database ]  
11. Once it is done updating, there will be a text at the bottom that says “done.”. That 
indicates the completion of our setup. 
