@echo off
setlocal EnableExtensions EnableDelayedExpansion
echo Installing certificates...

rem certutil -addstore -user -f Root "certificates\trustedPeople\01_systemtest_vii_primary_ca.p7b"
rem certutil -addstore -user -f Root "certificates\trustedPeople\02_systemtest_xix_ca_trust.cer"
rem certutil -addstore -user -f Root "certificates\trustedPeople\03_trust2408_oces_primary_ca.cer"
rem certutil -addstore -user -f Root "certificates\trustedPeople\04_trust2408_oces_ca_ii.cer"
rem certutil -addstore -user -f Root "certificates\trustedPeople\05_trust2408_oces_ca_iii.cer"
rem certutil -addstore -user -f My "certificates\trustedPeople\06_sts.cer"
rem certutil -addstore -user -f My "certificates\trustedPeople\07_kombit_sp_signing_test.p7b"
rem certutil -importpfx -user -p wRFsRP63H3kNEhDU "certificates\personal\08_kombit_sp_t_demo_serv_funktionscertifikat_.p12"

rem This path should be updated appropriately.
set "msbuild=%ProgramFiles(x86)%\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\amd64\MSBuild.exe"
set "vs2017Link=https://visualstudio.microsoft.com/downloads"
set "msbuildLink=https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools&rel=15"
if not exist "%msbuild%" (
  echo [101;93m ERROR [0m MSBuild was not found at path ["%msbuild%"].
  echo This means that the demo client cannot be compiled.
  echo You need to install either:
  echo  1. MS Visual Studio 2015 or later: "%vs2017Link%"
  echo  2. the .NET build tools: "%msbuildLink%"
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
