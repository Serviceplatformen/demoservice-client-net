@echo off
setlocal EnableExtensions EnableDelayedExpansion
echo Installing certificates...

certutil -addstore -user -f Root "certificates\trustedPeople\01_systemtest_vii_primary_ca.p7b"
certutil -addstore -user -f Root "certificates\trustedPeople\02_systemtest_xix_ca_trust.cer"
certutil -addstore -user -f Root "certificates\trustedPeople\03_trust2408_systemtest_xxii_ca.cer"
certutil -addstore -user -f Root "certificates\trustedPeople\04_trust2408_oces_primary_ca.cer"
certutil -addstore -user -f Root "certificates\trustedPeople\05_trust2408_oces_ca_ii.cer"
certutil -addstore -user -f Root "certificates\trustedPeople\06_trust2408_oces_ca_iii.cer"
certutil -addstore -user -f My "certificates\trustedPeople\07_sts.cer"
certutil -addstore -user -f My "certificates\trustedPeople\08_kombit_sp_signing_test.cer"
certutil -importpfx -user -p wRFsRP63H3kNEhDU "certificates\personal\09_kombit_sp_t_demo_serv_funktionscertifikat_.p12"

rem This path should be updated appropriately.
set "msbuild=%ProgramFiles(x86)%\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\amd64\MSBuild.exe"
set "vsLink=https://visualstudio.microsoft.com/downloads"
set "msbuildLink=https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools"
if not exist "%msbuild%" (
  echo [101;93m ERROR [0m MSBuild was not found at path ["%msbuild%"].
  echo This means that the demo client cannot be compiled.
  echo You need to install either:
  echo  1. MS Visual Studio 2015 or later: "%vsLink%"
  echo  2. The .NET build tools: "%msbuildLink%"
  echo     Make sure to add all the ".NET Framework 4.6.* targeting packs" and the "NuGet package manager".
  goto :exit
)

echo Please choose a client to execute:
echo 1 - Context client
echo 2 - Token client
Set /p option=
if %option% == 1 (
  call "%msbuild%" DemoClient\DemoClient.sln
  DemoClient\DemoClient\bin\Debug\DemoClient.exe
) else if %option% == 2 (
  call "%msbuild%" DemoTokenClient\DemoTokenClient.sln
  DemoTokenClient\DemoTokenClient\bin\Debug\DemoTokenClient.exe
)


:exit
