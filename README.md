# DGraph
Scans projects from different paths and extracts dependency graph and displays them in a filterable way in an MVC application, using MongoDB for storage.

## Getting started

- Make sure you have IIS installed
- Install MongoDB: https://www.mongodb.org/downloads
- Create `c:\mongodb\data\db`
- Run `setupMongoDb.ps1`
  - Or install it as a service: https://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/#configure-a-windows-service-for-mongodb
- Run the `setup.ps1` script.
- Update the app.config and web.config files with the servers and applications you want.
- Import your logs using the DGraph.ConsoleApp program.

## Roadmap

### Iteration 1
1. Reads all files from directories (using async)
2. Table of dependency for application
3. Rescan all files

### Iteration 2
1. Possibility to scan github for dependency

### Iteration 3
1. Search dependency

### Iteration 4
1. Paging dependency

### Iteration 5
1. Smart re-scanning, journaling the last scan time for each app.
