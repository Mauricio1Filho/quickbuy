@echo off 
set pathfile=D:\Development\Visual Studio\quickbuy\QuickBuy.Web\ClientApp
set command=npm start
echo %pathfile% 
cd %pathfile%
call %command%
pause