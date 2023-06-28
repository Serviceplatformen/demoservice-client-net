@echo off
setlocal EnableExtensions EnableDelayedExpansion
echo Installing certificates...



certutil -addstore -user -f My "certificates\trustedPeople\Den Danske Stat OCES udstedende-CA 1.cer
certutil -addstore -user -f My "certificates\trustedPeople\Den Danske Stat OCES rod-CA.cer
certutil -addstore -user -f My "certificates\trustedPeople\SP_EXTTEST_Signing_1.cer
certutil -addstore -user -f My "certificates\trustedPeople\ADG_EXTTEST_Adgangsstyring_1.cer
certutil -addstore -user -f My "certificates\trustedPeople\star.serviceplatformen.cer




certutil -importpfx -user -p 1kKUWZ,91Zg1 "certificates\personal\SP_DEVTEST4_DEMOKLIENT_SF0101_1.p12"

set "msbuild=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\amd64\MSBuild.exe"
set "vsLink=https://visualstudio.microsoft.com/downloads"

set "msbuildLink=https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools"
if not exist "%msbuild%" (
  echo [101;93m ERROR [0m MSBuild was not found at path ["%msbuild%"].
  echo This means that the demo client cannot be compiled.
  echo You need to install either:
  echo  1. MS Visual Studio 2022 or later: "%vsLink%"
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
