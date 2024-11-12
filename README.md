# Contract Monthly Claim System (CMCS)

## Overview

The **Contract Monthly Claim System (CMCS)** is a .NET MVC application designed to streamline the submission and approval of monthly claims for Independent Contractor (IC) lecturers. It provides features such as claim submission, claim verification by Programme Coordinators and Academic Managers, uploading supporting documents, tracking claim status, and unit testing for consistency and error handling.

This project uses **in-memory storage** with **Entity Framework Core**, so all data is stored in memory during the runtime of the application. Once the application stops, the data will be cleared.

## Features

1. **Lecturer Claim Submission**:
   - A simple form allows lecturers to submit claims.
   - The form captures hours worked, hourly rate, and additional notes.
   - Lecturers can upload supporting documents related to their claims.

2. **Programme Coordinator & Academic Manager Verification**:
   - Coordinators and managers can view pending claims.
   - They have options to approve or reject claims.
   - Each claim shows detailed information necessary for verification.

3. **Document Upload**:
   - Lecturers can upload files when submitting their claims.
   - Uploaded files are linked to the corresponding claim.

4. **Claim Status Tracking**:
   - Claims have statuses (e.g., Pending, Approved, Rejected).
   - The status is updated as the claim moves through the verification process.

5. **Unit Testing**:
   - Unit tests cover core functionalities of the application to ensure reliability.
   - Error handling and validation are built into the system to catch issues and provide meaningful feedback to users.

## Project Structure

### Folders and Files

1. **Controllers**:
   - `HomeController.cs`: Handles the basic routing and main page display.
   - `ClaimsController.cs`: Manages the submission, verification, and approval of claims.

2. **Models**:
   - `Claim.cs`: Represents the data model for claims submitted by lecturers.
   - Additional models can be added for users, roles, or other necessary entities.

3. **Views**:
   - **Shared**:
     - `_Layout.cshtml`: Contains the common layout for all views (header, footer, and navigation).
   - **Home**:
     - `Index.cshtml`: Displays the home page for the CMCS application.
   - **Claims**:
     - `Submit.cshtml`: Form for lecturers to submit claims.
     - `PendingClaims.cshtml`: View for Programme Coordinators and Academic Managers to verify claims.
     - Additional views for managing and displaying claim details.

4. **Data**:
   - `ApplicationDbContext.cs`: The database context used by Entity Framework Core to manage in-memory data.

5. **wwwroot**:
   - Contains static files like CSS, JavaScript, and images used in the UI.

6. **Program.cs**:
   - Sets up the application and registers services, including the **in-memory database**.

### Dependencies

- **Entity Framework Core InMemory**: Used to store data in memory during application runtime.
- **ASP.NET Core MVC**: Provides the MVC framework for handling views and controllers.

### NuGet Packages

To install the necessary packages, use the **Package Manager Console** and run:

```powershell
Install-Package Microsoft.EntityFrameworkCore.InMemory
Install-Package Microsoft.AspNetCore.Mvc
```

## How to Run the Project

### Prerequisites

- Install **Visual Studio 2022** (or later) with the **ASP.NET and web development** workload.
- Install the **.NET SDK 6.0** or later.

### Steps

1. Clone the repository to your local machine.
2. Open the solution file (`.sln`) in **Visual Studio**.
3. Open the **Package Manager Console** and install the necessary NuGet packages by running:
   ```powershell
   Install-Package Microsoft.EntityFrameworkCore.InMemory
   ```
4. Build the solution by navigating to **Build** > **Rebuild Solution** in Visual Studio.
5. Run the application by pressing `Ctrl + F5` or clicking the **Run** button.

### Application Pages

- **Home Page**: Displays the main dashboard of the CMCS system.
- **Submit Claim**: Lecturers can use this form to submit their claims.
- **Pending Claims**: Coordinators and managers can approve or reject pending claims.
- **Uploaded Documents**: Displays the list of uploaded files related to claims.

## Using the Application

### Submitting a Claim

1. Navigate to the **Submit Claim** page from the navigation bar.
2. Fill in the hours worked, hourly rate, and any additional notes.
3. Upload any necessary supporting documents.
4. Click the **Submit** button to send the claim for approval.

### Approving or Rejecting Claims

1. Programme Coordinators and Academic Managers can navigate to the **Pending Claims** page.
2. Review the list of pending claims and click **Approve** or **Reject** for each claim.
3. The status of each claim will be updated automatically.

### Tracking Claim Status

1. Lecturers can view the status of their submitted claims on the **Track Claims** page.
2. The status will change as the claim moves through the approval process.

## Configuration for In-Memory Database

The application uses **in-memory storage** during runtime. This is configured in the `Program.cs` file as shown below:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("CMCSDatabase"));
```

All data will be cleared once the application is stopped.

## Error Handling and Unit Testing

The application includes error handling to manage potential issues during claim submission or approval.

Unit tests have been added to test the key functionalities, ensuring:
- Claims are submitted correctly.
- Claims can be approved or rejected.
- File uploads work as expected.
  
Tests ensure that the application runs smoothly without breaking any core features.

## Future Enhancements

Potential future improvements include:
- Adding role-based authentication for different user types (lecturers, coordinators, managers).
- Expanding the application to support persistent database storage (e.g., SQL Server or MySQL).
- Implementing more detailed tracking with notifications for claim status changes.
  
## Troubleshooting

### Common Issues

- **Database Not Found**: Make sure that the in-memory database is properly configured in `Program.cs`.
- **Layout Not Displaying**: Ensure `_Layout.cshtml` is referenced at the top of your views.
- **Static Files Not Loading**: Make sure `app.UseStaticFiles();` is included in `Program.cs`.


