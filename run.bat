@echo OFF
echo Installing certificates...

certutil -addstore -user -f Root "certificates\trustedPeople\01_systemtest_vii_primary_ca.p7b"
certutil -addstore -user -f Root "certificates\trustedPeople\02_systemtest_xix_ca_trust.cer"
certutil -addstore -user -f My "certificates\trustedPeople\03_sts.cer"
certutil -addstore -user -f My "certificates\trustedPeople\04_kombit_sp_signing_test.p7b"
certutil -importpfx -user -p wRFsRP63H3kNEhDU "certificates\personal\05_kombit_sp_t_demo_serv_funktionscertifikat_.p12" 

echo Please choose a client to execute:
echo 1 - Context client
echo 2 - Token client
Set /p option=
if %option% == 1 (
	rem This path should be updated appropriately.
	call "%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" DemoClient\DemoClient.sln
	DemoClient\DemoClient\bin\Debug\DemoClient.exe
) else if %option% == 2 (
	rem This path should be updated appropriately.
	call "%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" DemoTokenClient\DemoTokenClient.sln
	DemoTokenClient\DemoTokenClient\bin\Debug\DemoTokenClient.exe
)
