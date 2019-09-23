## 1. General information
For general information see the document "Programmers Guide - Serviceplatformen" for details.

## 2. Configuration:
To configure the client the values that need to be changed have a comment attached
shown as `TO_BE_MODIFIED`. These values are both in the different classes but also in the 
App.config file.

## 3. Service Reference
To add a service reference: 
1. Right click the DemoTokenClient project and choose Add -> Service Reference...
2. In the Address field write the path to the service's wsdl file and click "Go".
3. If the service can be located it will appear in the "Services:" window.
4. In the Namespace field write a name for the service reference and click "OK".
5. The reference now appears in the Service References folder.
6. The generated code from the wsdl can now be found in the References.cs class.
7. To see this class press CTRL + N and search for References.cs.

## 4. Certificates:
In order to successfully call the service, the required certificates must first be installed.
The location of the installed certificates must correspond the the location you specify in the App.config 
and the location the CertificateLoader class reads the certificates from.

## 5. Thumbprints: 
If the thumbprints used when configuring the client are copied from MMC in the certificate details, 
it can have an invisible character in front of the thumbprint. If this invisible character is not
removed it will cause an error because the certificate with that thumbprint cannot be found.

To fix this you can either press delete in front of the thumbprint when it has been pasted into the
code or write the thumbprint by hand. 

If you are unsure that the invisible character is the issue if the certificate cannot be found, 
you can try to paste the thumbprint into a command prompt. Here the invisible character will show
as a question mark in front of the thumbprint.

## 6. Starting the client
To start the client either run the Program.cs or run the DemoTokenClient.exe file located in 
`/DemoTokenClient/DemoTokenClient/bin/Debug/DemoTokenClient.exe`