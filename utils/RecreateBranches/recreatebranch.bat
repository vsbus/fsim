svn delete -m "remove /dev" https://fsim.googlecode.com/svn/branches/developers/%1/dev
svn copy -m "recreate /dev" https://fsim.googlecode.com/svn/trunk/dev https://fsim.googlecode.com/svn/branches/developers/%1/dev
