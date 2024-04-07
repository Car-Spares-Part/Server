# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . .

# Build the application inside the container
RUN dotnet build -c Release

# Set the base image to the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app/bin/Release/net8.0/publish .

# Expose port 80 to the outside world
EXPOSE 80

# Define the command to run the application
CMD ["dotnet", "ServerApplication.dll"]
