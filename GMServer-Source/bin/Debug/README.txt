Credits (For all development): brclancy111
Contact: brclancy111@hotmail.com

Configuration:

Example configuration file:

port=194
SQLHost=127.0.0.1\sqlexpress
SQLUser=game
SQLPass=Y87dc#$98
SQLAccDB=AccountServer
SQLGameDB=GameDB

port - What port will the server listen on?
SQLHost - The server that has the SQL Server on it.
SQLUser - username for SQL Server
SQLPass - Password for SQL Server
SQLAccDB - Account Database name
SQLGameDB - Game Database name

Q: How do my users log in?
1. With the ToPAST GM/Admin Client (http://forum.ragezone.com/f440/topast-admin-gm-tool-v-1-3-a-626122/)
2. With their respected GM accounts on the TOP game.

Q: Why use the GM Server Instead of a direct connection to the SQL Server?
1. Logging
2. Secure Login
3. Prevents haxing via SQL Server

Q: How is it bad if my SQL Server port isn't blocked?
1. Since the gameserver has only 1 possible password (They encoded it, and made it impossible to change it),
	It's best to prevent people from guessing the username.

For security:
Block(Don't forward) the port 1433 from external use. (Use windows firewall, whatever).