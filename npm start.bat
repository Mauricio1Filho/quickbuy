@echo off 
set pathfile=%~dp0\QuickBuy.Web\ClientApp
set command=npm start
echo %pathfile% 
cd %pathfile%
call %command%
pause