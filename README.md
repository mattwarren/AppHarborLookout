AppHarborLookout
================

An application that runs on your system tray polling for the most recent build update 
on any of your AppHarbor applications.

Original Author: [mattwarren](https://github.com/mattwarren/AppHarborLookout)

At the moment, only the latest change to any of your applications is announced in the system tray, 
consider it a mere announcer (which is all I needed, feel free to re-fork and contribute).

Features
========
* Configurable port, client id, and client secret through App.config
* Announces latest build status change of any AppHarbor application
* Gives details on latest build
* Informs on errors during latest application build process

Pending
=======
* TODO: Consult status per application
* TODO: Beautify UI (text clogs up)
* TODO: Add more tests
* TODO: Fix authorization (make it automatic on app startup)
* TODO: More refactoring
