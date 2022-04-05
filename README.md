# Run4Cause

## Setup the database

1. Launch the docker container containing the database :

```
docker-compose up
```

2. Run the migrations :

```
dotnet ef database update
```

## Running the project

1. If you did not already install the node_modules :

```
npm i
```

2. Running the project in watch mode

```
dotnet watch run
```
