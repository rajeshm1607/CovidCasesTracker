# Project Setup

## Prerequisites
Before you begin, ensure you have met the following requirements:
- Node.js and npm installed on your machine. [Install Node.js and npm](https://nodejs.org/)
- Angular CLI installed globally. You can install it by running `npm install -g @angular/cli`
- Visual Studio 2019 or later with the .NET Core cross-platform development workload installed. [Install Visual Studio](https://visualstudio.microsoft.com/)

## Setting up the Angular Project

1. Navigate to the `angular_api` directory:
    ```sh
    cd angular_api
    ```

2. Install the required npm packages:
    ```sh
    npm install
    ```

3. Start the Angular development server:
    ```sh
    ng serve
    ```

By default, the Angular app will run on `http://localhost:4200`.

## Setting up the C# Web API Project

1. Open Visual Studio.

2. Select **Open a project or solution**.

3. Navigate to the `Covid Web API` directory and open the solution file (`.sln`).

4. Restore the required NuGet packages. This should happen automatically when you open the solution, but you can also do this manually by right-clicking on the solution in the Solution Explorer and selecting **Restore NuGet Packages**.

5. Build the project by selecting **Build > Build Solution** from the top menu.

6. Run the Web API by selecting **Debug > Start Debugging** or pressing `F5`.




## Running Both Projects Concurrently

To run both projects concurrently, you can use separate terminal windows or tabs.

1. In the first terminal, navigate to `angular_api` and start the Angular development server:
    ```sh
    cd angular_api
    ng serve
    ```

2. Open Visual Studio and run the Web API project as described in the previous section.

Now, your Angular client should be able to make API calls to your C# Web API.

## Conclusion

You have successfully set up and run both the Angular and C# Web API projects. Your Angular client can now make API calls to the C# Web API. If you encounter any issues, refer to the documentation or check the console for error messages.
