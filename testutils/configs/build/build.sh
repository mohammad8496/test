#!/bin/bash

set -e

container_name="asp-core-builder-$3"

docker rm -f $container_name 2> /dev/null || true
docker run -d --name $container_name -w=/src microsoft/aspnetcore-build:1.0-1.1-2017-03 sleep infinity
docker cp . $container_name:/src
#docker exec /bin/bash -c "git clean -df; git reset --hard; git pull"
docker exec $container_name /bin/bash -c "dotnet restore ./TestUtils.sln -s $6/api/nuget/nuget && dotnet test ./TestUtilsUnitTests/TestUtilsUnitTests.csproj && dotnet publish ./TestUtils.sln -c Release -o ./obj/Docker/publish"

rm -rf artifact
mkdir -p artifact/obj/Docker
docker cp $container_name:/src/TestUtils/obj/Docker/publish artifact/obj/Docker/
cp TestUtils/Dockerfile artifact/

docker rm -f $container_name