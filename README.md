# Crawford.AutomationTests
A suite of automated tests for API and UI tests.
Repo to clone :  https://github.com/SuryaTamerla99/Crawford.AutomationTests.git

# UI Project Structure
 	Features Folder
  	Pages Folder
  	Step Definitions Folder
  	Utils Folder
# API Project Structure
 	Features Folder
  	Client Folder
  	Services Folder
  	Steps Folder
  	Helpers Folder

 
## Features Folder: 

  This folder has Specflow feature files contains the test scenarios for API and UI Tests.
				
## Pages Folder:
  This folder contains the page class which has all the required page locators.

## Services Folder: 

  This folder contains get user services.

## Helpers Folder: 

  This folder contains user response data model.

## Client Folder: 

  This folder contains  get user client.

## Step Definitions Folder:

  This folder contains the step definitions class where the specflow steps are implemented.
		
## Utils Folder:
```
 Utils folder contains:

    BaseClase: This class contains all the webdriver extension methods which will help in implementing step definitions.
			
    Constants: This class class contains all the required constants.
				
    DriverManger: It contains the logic for multiple browsers.
				
    Hooks: This is used to intiate the browser and close the browser instance.
```	

## Executing the Tests:
	Pre requisites:
	Need to have Chrome browser version(92) to avoid any browser issues.
	
	Need to have a latest firefox browser.
	
## Application Url:

Added the urls to 'App.config' in the app settings.

```<add key="CrawcoUrl" value="https://crawco.co.uk/" />```
```<add key="BaseUrl" value="http://reqres.in/api"/>```
