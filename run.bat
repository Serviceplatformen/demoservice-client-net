@echo OFF
echo Installing certificates...
certutil -p wRFsRP63H3kNEhDU -importpfx "certificates\personal\client.pfx"
certutil -addstore -f "TRUSTEDPEOPLE" "certificates\trustedPeople\kombit-sp-signing-test (funktionscertifikat).cer"
certutil -addstore -f "TRUSTEDPEOPLE" "certificates\trustedPeople\sts.cer"

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