## PURPOSE

The intent of this project is to:
1. Make it easy to verify the connection to [KOMBIT Serviceplatformen](https://www.serviceplatformen.dk), using either of its supported security models.
2. Serve as an example on how to implement and configure a client to KOMBIT Serviceplatformen for each of its supported
   security models.

## TARGET 

This file is targeted at C#/.net developers who implement integrations to Serviceplatformen.

## INSTRUCTIONS

### PREREQUISITES

* .NETFramework 4.5.2.

The client is fully configured and should work as is.

### EXECUTION


1. Run the client by executing `run.bat`.
2. Follow the instructions written in the console.


### BUILD

To build application, go to visual studio: `Build` -> `Rebuild Solution`.

### CERTIFICATE

To connect to the KOMBIT Serviceplatformen clients need certificates. Those certificates will installed automatically if you run `run.bat`.
Or you can install them manually. Certificates are stored under `/certificates` folder which contains two folders: personal and trustedPeople.
To install certificates:
- Personal: We have to install private key so we should install certificate from keystore. Here is CMD tool which can do it:
    ```bash
    certutil -p *PASSWORD* -importpfx client.pfx
    ```
    > You can find `*PASSWORD*` in `run.bat`. 
- TrustedPeople: There are two certificates which can be installed by:
    1. Double click on certificate.
    2. Chose: `Install certificate`.
    3. Change store location to: `Local Machine` and press 'Next'.
    4. Allow program to made changes to the computer.
    5. Change certificate location to: `Place all certificates in the followinf store` and click 'Browse...'.
    6. In the list find `Trusted People` and click 'OK'.
    7. 'Next' -> 'Finish' -> 'OK'.

## CONTENT

* `readme.md`: This file
* `run.bat`: Installs certificates and runs .net clients.
* `/certificates`: Contains certificates which should be installed to run clients.
* `/contracts`: Contains wsdl and xsd schemas used to connect to the service.
* `/DemoClient`: Contains the source code and resources of the context client.
* `/DemoTokenClient`: Contains the source code and resources of the token client.run