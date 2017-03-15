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
	call %windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe DemoClient\DemoClient.sln
	DemoClient\DemoClient\bin\Debug\DemoClient.exe
) else if %option% == 2 (
	call %windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe DemoTokenClient\DemoTokenClient.sln
	DemoTokenClient\DemoTokenClient\bin\Debug\DemoTokenClient.exe
)