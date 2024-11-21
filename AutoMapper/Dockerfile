# Step 1: Build the .NET application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything and restore/build the app
COPY . ./
WORKDIR /App/src/APIAutoMapper
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Step 2: Base image with NGINX and .NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Install NGINX
RUN apt-get update && apt-get install -y nginx && apt-get clean

# Configure NGINX
COPY nginx.conf /etc/nginx/nginx.conf

# Copy the .NET application
WORKDIR /App
COPY --from=build-env /App/src/APIAutoMapper/out /App

# Expose necessary ports
EXPOSE 80 443

# Create an entrypoint script
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# Set the entrypoint script to start both NGINX and .NET
ENTRYPOINT ["/entrypoint.sh"]