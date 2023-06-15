#!/usr/bin/env sh

docker build -t googleddnsupdater .
docker tag googleddnsupdater:latest googleddnsupdater:staging
docker compose --env-file ./secrets.env  up -d