
#!/usr/bin/python

import os, uuid, sys, types, re
import StringIO
import plistlib
import hashlib
import logging
import syslog
import shutil


syslog.openlog( 'DLL Builder Post Processor' )
syslog.syslog( syslog.LOG_ALERT, 'Starting Post Process' + os.getcwd() )


sourceFile = sys.argv[1]
filename = sys.argv[2]
projectRootFolder = '/Users/desaro/Documents/dev/Unity3D/Other/LearningUnits/'

destinationProjects = [ 'LearningUnit' ]

for folder in destinationProjects:
	destination = os.path.join( projectRootFolder, folder, 'Assets/Plugins', filename )
	syslog.syslog( syslog.LOG_ALERT, 'dir: ' + destination )
	
	# delete the file if it exists
	if os.path.exists( destination ):
		os.remove( destination )
	
	# copy the new file over
	shutil.copyfile( sourceFile, destination )