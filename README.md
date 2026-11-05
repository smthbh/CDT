This is a copy of the CDT code, provided by Poul Sirius. 
Used for Chrysler Diagnostic Troubleshooting.

Requires [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48), which is included by default with newer versions of Windows.

<img width="900" height="542" alt="CDT-screenshot" src="https://github.com/user-attachments/assets/7cfe30ae-a442-4644-9241-1298a64e8780" />


Instructions for making a cable and connecting, from Defend_Dingo on the Jeep Forums:

Step 1: buy the correct type of USB cable. It's called an FTDI serial cable. Here's a [link](https://a.co/d/0iKE2WQM?utm_source=google&utm_medium=organic) to the exact one I bought from amazon for example but you can get one from anywhere
The only thing that matters is that it has an FT232RL chip controller.

Step 2(optional): buy a OBD1 to OBD2 adapter cable so you can have a proper socket to connect to your Jeep diagnostic port. [here's a link to one for example](https://a.co/d/06xxzz04?utm_source=google&utm_medium=organic). if you have a different Chrysler vehicle you need the matching socket.

Step 3: Using the computer that you will connect to your Jeep, plug your FTDI cable into whatever USB port is most convenient for running the cable into the engine bay where your diagnostic port is. This is because the COM port number changes every time you switch USB ports so this will prevent any annoyances later.
It should register as a COM serial to your computer. It should install the driver automatically through windows update if you are connected to the internet. If it does not, you need to install the COM driver for it manually here

Step 4: Once it is registered as a COM (check USB devices in device manager to view it) you need to "program" the cable to work properly. Download and install the FT_PROG programming utility here

Step 5: open the program. Click the magnifying glass on the menu. It will populate the USB on the screen with all the settings currently stored on it.

Step 6: Click the "hardware specific" drop down. Select "invert RS232 signals" and check the two boxes that show up on the right labeled "invert TXD" and "invert RXD"

Step 7: Select "D2XX" under the "hardware specific" drop down. Check the box on the right that says "load D2XX driver"

Step 8: Click the lightning bolt on the top menu next to the magnifying glass and it will program the chip with these settings. Programming is done and we now need to physically make the cable.

Step 9: This the only physical work we need to do and it's a bit tedious since the wires are small. Unplug your USB from the computer and get your wire repair tools.

Here is my diagram of the 94 Cherokee diagnostic plug in the engine bay, as you are looking down at it. the notch is on the top left
<img width="118" height="95" alt="image" src="https://github.com/user-attachments/assets/30126b73-2ab8-4992-ab6d-eadd569f932c" />

Check to make sure yours either matches this or look at your specific wiring to verify
<img width="1920" height="1583" alt="image" src="https://github.com/user-attachments/assets/e2d9c256-f24d-4c80-9fff-4197e7c4af57" />

If you are only using the FTDI cable and not splicing the OBD1 socket on the end then you can just crimp some spade connectors on the wires we need. The three wires are black, orange, and yellow. Cut the cable the furthest away from USB side so you have the maximum length of cable to work with. If you are splicing the OBD socket on the end then you'll need to match the wiring. I suggest testing your connection first before putting the cable together so you know for sure your wires are correct.

For the FTDI circuit end
BLACK wire goes to GROUND
YELLOW wire goes to TRANSMIT
ORANGE wire goes to RECEIVE

Note: if your wires are in different locations(ex: a Chrysler instead of a Jeep) then match it for your specific plug


Thanks to tetatdo for the reference Jeep image
<img width="1019" height="1167" alt="image" src="https://github.com/user-attachments/assets/11374150-d285-432c-9800-5a4e10e5863f" />


If you are splicing into the OBD1 cable, cut that end furthest away from the OBD1 socket and connect your wires in a way that matches this pinout. I don't know if the color codes match between cable manufacturers so you are on your own for the wire colors of the OBD1 adapter. I used a multimeter to test continuity from the pin I want in order to find what wire color it was.

If in doubt, refer back to the picture of the FTDI cable plugged directly into the diagnostic socket. you want your OBD1 adapter to match that exactly.

REMEMBER - you only have to do this once. Take your time and do it right the first time.
Make sure none of the wires are bare and touching. seal them all up and wrap it in a cable wrap or something so it's protected and ready for use.

Step 10: plug in the FTDI cable to your OBD port and then plug the USB back into the USB port you selected earlier.

Step 11: turn your ignition to RUN but don't start the vehicle

Step 12: Open the .zip file and unzip it wherever you want but make sure everything in there unzips together. Open CDT.exe (don't move any of the files in the folder it comes with) and Click the "settings" menu. Click settings again in that menu. Select your com port from the drop down. If your COM driver is set up correctly it should automatically detect the port number. Click save.

Step 13: Click the "settings" menu. Click connect. If everything is set up you should get a successful connection prompt with all your vehicle info populated on the screen.
