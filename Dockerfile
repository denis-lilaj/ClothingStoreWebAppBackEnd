# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file(s) and restore any dependencies
COPY ClothingStoreWebAPI/*.csproj ./ClothingStoreWebAPI/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/

# Restore the dependencies
RUN dotnet restore ./ClothingStoreWebAPI/ClothingStoreWebAPI.csproj

# Copy the rest of the application code
COPY . ./

# Build and publish the application
RUN dotnet publish ./ClothingStoreWebAPI/ClothingStoreWebAPI.csproj -c Release -o out

# Use the official .NET runtime image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the build artifacts from the build stage
COPY --from=build /app/out .

# Expose the port the app runs on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "ClothingStoreWebAPI.dll"]
