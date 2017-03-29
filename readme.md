## PURPOSE

The intent of this project is to:
1. Make it easy to verify the connection to [KOMBIT Serviceplatformen](https://www.serviceplatformen.dk), using either of its supported security models.
2. Serve as an example on how to implement and configure a client to KOMBIT Serviceplatformen for each of its supported
   security models.

## TARGET AUDIENCE

This file is targeted at C#/.net developers who implement integrations to Serviceplatformen.

## INSTRUCTIONS

### PREREQUISITES

* .NETFramework 4.5.2.
* Visual Studio 2016 (to build the code only)

The client is fully configured and should work as is.

### BUILD

To build application, go to visual studio: `Build` -> `Rebuild Solution`.

### EXECUTION

1. Start a Command Prompt with administrator permissions.
2. Run the client by executing `run.bat`.
3. Follow the instructions written in the console.

### CHANGE CERTIFICATE

It may be desirable for a new Serviceplatformen user system to verify that a connection is possible using their own certificate.
In order to connect to KOMBIT Serviceplatformen, the clients need certificates. These certificates are installed automatically with the command `run.bat`, 
or they can be installed manually. Certificates are stored under the `/certificates` folder which contains the two folders `/personal` and `/trustedPeople`.
To install the certificates:
- Personal: To install the private key, the certificate from the keystore should be installed. Here is a Command Prompt tool that can do it:
    ```bash
    certutil -p *PASSWORD* -importpfx client.pfx
    ```
    > `*PASSWORD*` for current setup is `wRFsRP63H3kNEhDU`. This password should be adjusted to the password for the new certificate.
- TrustedPeople: The two certificates can be installed by:
    1. Double click on certificate.
    2. Chose: `Install certificate`.
    3. Change store location to: `Local Machine` and press 'Next'.
    4. Allow program to make changes.
    5. Change certificate location to: `Place all certificates in the following store` and click 'Browse...'.
    6. In the list find `Trusted People` and click 'OK'.
    7. 'Next' -> 'Finish' -> 'OK'.

## CONTENT

* `readme.md`: This file
* `run.bat`: Installs certificates and runs .net clients.
* `/certificates`: Contains certificates which should be installed to run clients.
* `/contracts`: Contains wsdl and xsd schemas used to connect to the service.
* `/DemoClient`: Contains the source code and resources of the context client.
* `/DemoTokenClient`: Contains the source code and resources of the token client.run