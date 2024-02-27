-	Environment :-
  o	Visual studio 2022.
  o	.Net 8.0
  o	.Net Framework 4.7.2
  o	npm V:- 20.11.1
-	Run Application :-
  o	Build the application
  o	Set “StocksTracker” project as startup project (write click on the project name and select “Set as Startup Project”)
  o	Open to “StocksTracker >> appsettings.json >> appsettings.Development.json”   and update “DefaultConnection” under “ConnectionStrings”
  o	From “Tools” menu select “NuGet Package Manager >> Package Manager Console“
  o	In package manager console Add command “Update-DataBase” and press enter
  o	After Database creation write click on “StocksTracker” solution name and select “Configure Startup Projects” then select “Multiple startup projects”
  o	Select “Start” from “Action” column to projects “ServiceHost, StocksTracker, StocksTracker.WCFService, StocksTracker.UI” and then click “ok” button.
  o	Run application by click “F5”
