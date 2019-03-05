# AGI.AnalyticalServices C# Software Dev Kit
AGI hosts a set of micro services for performing complex analyses.  
The services are located here: https://saas.agi.com/V1.
This project provides a C# SDK for interacting with the services.

## How to use this SDK
To use this SDK with AGIs Analytical Services, follow these steps.
1. First contact AGI using one of the methods defined here: https://saas.agi.com/V1/, to obtain an API key.
  Once you have the API key, continue on to the next step.
2. Next, create a file called AGI.AnalyticalServices.config, and place this text in it:
        <?xml version="1.0" encoding="utf-8" ?>
        <configuration>
        <appSettings>
            <add key="ApiKey" value="AGI provided API Key" />
            <add key="BaseUrl" value="https://saas.agi.com" />
        </appSettings>
        </configuration>
Replacing the text "AGI provided API Key" with the actual key AGI provided to you.
3. Place this config file in the root folder of your project that uses this SDK.
4. If you try to use this SDK without an API key, you will receive exceptions.
