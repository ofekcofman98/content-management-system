# Abra Umbraco Assignment - Content Management System

## Project Overview
I have implemented a Content Management System using Umbraco, featuring a home page with search functionality and dynamic article pages.

## Technical Architecture
- **Route Hijacking**: Used custom `RenderControllers` (`HomePageController`, `ArticleController`) to manage custom logic.
- **View Models**: Implemented `HomeViewModel` and `ArticleViewModel` to pass data to the views in a strongly-typed and maintainable manner.
- **Search Logic**: Server-side search filtering by article name.
- **Database**: SQLite database is included in the project under `umbraco/Data`.

## How to Run
1. Open the solution in Visual Studio 2022.
2. Ensure the project is set as the Startup Project.
3. Build and Run.
4. The SQLite database is already pre-configured in `appsettings.json`.

## Backoffice Credentials
- **URL**: `/umbraco`
- **User**: ofekcofman98@gmail.com
- **Password**: OfekAbra123!
