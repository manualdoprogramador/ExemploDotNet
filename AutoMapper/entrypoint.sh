#!/bin/bash

# Start the .NET API in the background
dotnet /App/MobileApi.dll &

# Start NGINX in the foreground
nginx -g "daemon off;"