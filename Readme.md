--------------------------------------------------------
Author: 	Omar Zuniga
Enviroment: 	Web Application
Platform: 	Asp.net core 2.0
Services: 	Azure Active Directory 
Database:	Local DB (SQL Server Express)
Dev Tool:	Visual Studio Community 2017
Name App:	"H-E-B   &   ME" -- (NetGiphyA) 1.0.0.
-------------------------------------------------------
"H-E-B   &   ME" -- (NetGiphyA) 1.0.0.

It is an ASP.NET Core 2.0 web application designed in MVC Framework layer. It interacts with the Giphy Api, LocalDB as a database instance of SQL Server Express and Azure Active Directory.

The project was divided into 4 projects, thus they could be tested separately...
	1. HEB.GiphyA.Connector 		-- API interface with Giphy Api
	2. HEB.NetGiphyA				-- MVC ASP NET Core 2.0  Web app
	3. HEB.NetGiphyA.Business		-- Business Layer
	4. HEB.NetGiphyA.Data			-- Database Layer

To correctly install the application and make it run successfully there are some considerations to take into account, those are as follow :
* Interacting with the Giphy Api, an account needs to be registered with them, in the project is using my registration key... you can change to the personal one... make the changes in the GetterGiphyAApi class
* Install the ASP.NET Core 2.0 at least
* Install the ASP.NET MVC Core
* The DB layer uses EF 6.0 for the simplicity of the app, make sure you have it installed too
* Bootstrap 4.3.0, it is included in the project as part of the dependencies, just make sure it got deployed correctlyafter clonning the project. Check the package.json file and the note_modules folder being created.
* JQuery 3.4.0. Same scenario that Bootstrap
* For Azure Active Directory, the application uses my free suscription. Depending on your business needs, you have the flexibility to decide which audience to sign-in to your application:
	- If you are a Line of Business (LOB) developer, you'll want to [sign-in users in your organization] with their work or school accounts --- This is the case for the Challenge project. Make sure you have an microsoft account to register yourself to the app and send me the account thus I can add you as a user of my account.
	- If you decide to change the suscription for another more professional services account, please make sure you setup the config files for the new account. Go the appsetting and fill up the correct data for ClientId and Authority accordingly.
* For the Email. The app use the Gmail service, so it is neccesary to have an account there too, just to be able to notify the users and admins of its account created. Admins take that email and add the user in the Azure portal to give access to the app.  For this email account "Turn On" Less Secure App access.	




