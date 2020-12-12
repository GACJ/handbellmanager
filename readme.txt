Handbell Manager (https://handbellmanager.changeringing.co.uk/)
---------------------------------------------------------------
Handbell Manager is a clever bit of software written by Graham John
that enables MotionXL motion controllers (available from Graham) to be used
like virtual handbells to control simulators such as Abel and Beltower.
I have now added RingingRoom as a supported simulator to Handbell Manager.

Assuming you have the motion controllers, the following instructions will guide
you through installing Handbell Manager on a Windows PC computer.

PLEASE NOTE: THIS IS A BETA RELEASE AND THE PROGRAM IS STILL SUBJECT TO CHANGE.
ALL FEEDBACK MUCH APPRECIATED! YOU MAY ENCOUNTER SOME PROBLEMS!

If you run into difficulties please get in touch with me by email:

adrian.nashmail@btinternet.com

Regards,
Adrian Nash


INSTALLATION STEPS
------------------
To install Handbell Manager v 2.1.0:

1. Download HandbellManager140.zip to your computer.

2. Extract the files to a folder: C:\HandbellManager140 by right-clicking on the zip file and
   and select "Extract All". The folder called HandbellManager140 will be created.
(you may require admin rights for this)

3. Navigate into HandbellManager140 folder and right-click on the file called
   HandbellManager.exe. Select Send to... then Desktop (create shortcut). This will
   create a shortcut on your desktop for Handbell Manager.

4. Double-click the short-cut to open Handbell Manager. If your computer warns you not
   to run it, don't worry it is safe! On Windows 10 for example, click on "more info" then
   "Run anyway".

   To use HM with Ding
   -------------------
1. To Start HM with Ding, when Handbell Manager starts, click on Run > Choose Simulator > Ding
2. Then click Run > Ding. Handbell Manager will then launch Ding Unity or Ding Standard.
3. Enter your name and choose or create a tower as usual.  If you have motion
   Controllers set up, you should now find that moving the motion controllers will ring the bells assigned to you.

   To Use HM with RingingRoom
   --------------------------
1. To Start HM with Ringing room, when Handbell Manager starts, click on Run > Choose Simulator > Ringing Room
2. Then click Run > RingingRoom. Handbell Manager will then start a RingingRoom session using
   your default browser (must not be Microsoft Edge or Explorer, but Chrome and Firefox are
   both fine.)
3. Enter your tower ID and name as usual. Click in the Ringingroom window. If you have motion
   Controllers set up, you should now find that moving the motion controllers will cause
   Ringing Room to respond on which ever bells you have assigned (usually 1 and 2 when you
   first enter a "room").

   To Use HM with Muster
   ---------------------
   You need to have the Muster application and the latest version of Abel installed on your computer.
1. Go to the folder where the Muster application has been installed, e.g. C:\Muster 1.0.0.0
2. Right-click on Muster.exe and select "Create Shortcut".
3. Move the Shortcut to the installation folder for HandbellManager e.g. C:\HandbellManager140
4. Rename the shortcut to "Muster" (without the quotes).
5. To Start HM with Muster, when Handbell Mangager starts, click on Run > Choose Simulator > Muster.
6. HM will start Muster. If Abel is not already started, please also start Abel.
7. Click in the Muster Window. You should now find that moving the motion controllers will operate the "bells"
   in Abel via Muster.
   
   Creating Desktop Shortcuts and Command Line Options
   ---------------------------------------------------
   A new feature introduced to HM in version 1.3.0 is command-line options.
   These enable you to set up a desktop shortcut that is already set for a particular use of
   HM e.g. one shortcut for HM + Abel and another for HM + RingingRoom.
   When you create a short-cut by right-clicking on HandbellManager.exe (in your installation folder)
   and selecting "Send to Desktop", a desktop shortcut is created. There are two useful command line options:
   -s <0-4> selects the simulator -s 0 for Abel, -s 1 for Beltower, -s 3 for RingingRoom and -s 4 for Muster.
   -r       tells HM to automatically start the simulator upon startup.
   
   Now, you can modify the settings of this shortcut as follows.
1. Right-click the shortcut and select "Properties".
2. Click in the text box called "Target:", then hit the "End" key. The cursor will move to just past
   ".exe".
3. Place a space character followed by the following (without the quotes)
   " -s 0 -r" To select Abel and automatically start Abel
   " -s 1 -r" To select Beltower and automatically start Beltower
   " -s 3 -r" To select RingingRoom and automatically start a web-browser session. You will then need to enter the tower name
              or ID into RingingRoom (unless you use a shortcut for that; see below)
   " -s 4 -r" To select Muster and automatically start the muster app.
   " -s 5 -r" To select Ding and automatically start Ding Unity or Ding Standard, if it is not already running.

   Note: if you want to set the URL for RingingRoom in the shortcut you can use -u <ringingroom URL>:
   e.g. -s 3 -r -u www.ringingroom.com/mytower where "mytower" can be your tower name or an ID number.

   So The "Target" text would now look something like this example (for starting Muster via the shortcut):
       C:\HandbellManager140\HandbellManager.exe -s 4 -r
4. Click OK to close the Desktop Shortcut properties dialog.
5. Rename your shortcut if you like by right-clicking and selecting "Rename".


VERSION HISTORY
---------------
v. 1.3.0a Initial release
v. 1.3.0b Initial Beta Release, key-stroke defaults for RingingRoom changed. Simulator name displayed in the Title bar.
v. 1.4.0  Added support for Muster
v. 2.0.0  Gyro support for eBells, callibration for any selected axis.  Formal installation release.
v. 2.1.0  Added support for Ding

