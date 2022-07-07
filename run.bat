@echo off
setlocal EnableExtensions EnableDelayedExpansion
echo Installing certificates...


certutil -addstore -user -f My "certificates\trustedPeople\globalsign_ca_for_sp.cer
certutil -addstore -user -f My "certificates\trustedPeople\globalsign_ca_for_sts.cer
certutil -addstore -user -f My "certificates\trustedPeople\sp_oces_signing.cer
certutil -addstore -user -f My "certificates\trustedPeople\sts_oces_signing.cer
certutil -addstore -user -f My "certificates\trustedPeople\star.serviceplatformen.dk.cer



certutil -importpfx -user -p wRFsRP63H3kNEhDU "certificates\personal\09_kombit_sp_t_demo_serv_funktionscertifikat_.p12"
rem C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\amd64
rem This path should be updated appropriately.
rem set "msbuild=%ProgramFiles(x86)%\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\amd64\MSBuild.exe"
set "msbuild=%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\amd64\MSBuild.exe"
set "vsLink=https://visualstudio.microsoft.com/downloads"
rem set "msbuildLink=https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools"
set "msbuildLink=https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools"
if not exist "%msbuild%" (
  echo [101;93m ERROR [0m MSBuild was not found at path ["%msbuild%"].
  echo This means that the demo client cannot be compiled.
  echo You need to install either:
  echo  1. MS Visual Studio 2019 or later: "%vsLink%"
  echo  2. The .NET build tools: "%msbuildLink%"
  echo     Make sure to add all the ".NET Framework 4.7.2 targeting packs" and the "NuGet package manager".
  goto :exit
)

echo Please choose a client to execute:
echo 1 - Context client
echo 2 - Token client
echo 3 - Access Token client
Set /p option=
if %option% == 1 (
  call "%msbuild%" DemoClient\DemoClient.sln
  DemoClient\DemoClient\bin\Debug\DemoClient.exe
) else if %option% == 2 (
  call "%msbuild%" DemoTokenClient\DemoTokenClient.sln
  DemoTokenClient\DemoTokenClient\bin\Debug\DemoTokenClient.exe
)  else if %option% == 3 (
  call "%msbuild%" DemoAccessTokenClient\DemoTokenClient.sln
  DemoAccessTokenClient\DemoTokenClient\bin\Debug\DemoTokenClient.exe
)


:exit
