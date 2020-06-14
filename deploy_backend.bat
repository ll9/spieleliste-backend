@ECHO OFF

ssh -i %USERPROFILE%\.ssh\id_rsa pi@raspberrypi cp -r /home/pi/deployments/spieleliste-backend/publish /home/pi/deployments/spieleliste-backend/$(date +'%%y%%m%%d_%%H%%M%%S')_publish

ssh -i %USERPROFILE%\.ssh\id_rsa pi@raspberrypi sudo systemctl stop spieleliste-backend.service

dotnet publish -o publish -r linux-arm
scp -r publish pi@raspberrypi:/home/pi/deployments/spieleliste-backend

ssh -i %USERPROFILE%\.ssh\id_rsa pi@raspberrypi sudo systemctl start spieleliste-backend.service

ECHO "SUCCESS"