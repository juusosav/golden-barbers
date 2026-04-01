# Golden Barbers - Barbershop Web Application

Golden Barbers is a full-stack appointment booking web application built with **Blazor WebAssembly + ASP.NET Core**.
It allows customers to book barber appointments online while providing an admin panel for managing barbers, services, and appointments.

Live demo: [Golden Barbers](golden-barbers-bmfqbabta6haa2fv.westeurope-01.azurewebsites.net)
---

## Features

### Customer Side

* Browse available services and barbers
* Select appointment time via interactive weekly calendar
* Real-time availability (timeslots)
* Price calculation based on barber level
* Smooth booking flow with guided steps
* Automatic scrolling between booking steps
* Booking confirmation page

---

### Admin Panel

* Manage barbers (create, edit, delete)
* Manage offerings/services (including image uploads)
* Manage appointments (view, filter, delete)
* Server-side filtering and pagination
* Image handling with file storage in `wwwroot`

---

### Localization

* Implemented using `IStringLocalizer`
* Supports:
  * 🇬🇧 English
  * 🇫🇮 Finnish
    
* Language switcher in UI (dropdown)
* Culture persisted via browser storage

>  Note: Identity pages and seeded data are currently not localized. This will be implemented later.

---

### Smart Features

* Dynamic pricing based on barber experience level
* Timeslot-based scheduling system
* Prevents double booking
* Clean separation of Client / Server / Shared layers
* Reusable services (API + File handling)

---

## Tech Stack

### Frontend

* Blazor WebAssembly
* Bootstrap + custom CSS
* JavaScript interop (scrolling, culture persistence)

### Backend

* ASP.NET Core Web API
* Entity Framework Core
* SQLite when deploying to Azure (for development, PostgreSQL was used)

### Architecture

* Client / Server / Shared DTO structure
* Service-based architecture
* RESTful APIs

---

## Project Structure

```text
GoldenBarbers/
├── GoldenBarbers.Client      # Blazor WASM frontend
├── GoldenBarbers.Server      # ASP.NET Core API
├── GoldenBarbers.Shared      # DTOs and shared models
```

---

## Setup & Run

### 1. Clone repository

```bash
git clone https://github.com/your-username/golden-barbers.git
cd golden-barbers
```

---

### 2. Run the application

Using Visual Studio:

* Set **Server** as startup project
* Run the solution

Or via CLI:

```bash
dotnet run --project GoldenBarbers.Server
```

---

### 3. Access the app

```text
https://localhost:xxxx
```

---

## 🗄️ Database

* Uses **SQLite** by default in production (currently PostgreSQL in development)
* Automatically created on startup (if configured)

> For production, consider switching to PostgreSQL or Azure SQL.

---

## Image Uploads

* Images are uploaded via admin panel
* Stored in:

```text
wwwroot/images/
```

---

## Known Limitations

* Identity pages are not localized
* Seed data is not localized
* No advanced role management UI
* Basic error handling (can be improved)
* No payment integration

---

## Future Improvements

* Full localization coverage (including Identity)
* Better validation & UX feedback
* Full pagination UI for large datasets (currently used in Admin Appointments table)
* Azure deployment (App Service + managed DB)
* Image CDN / cloud storage
* Unit & integration testing

---

## Deployment Notes

The project is designed to be deployable to:

* Azure App Service
* SQLite (file-based DB) or external DB

---

## What I Learned

Building Golden Barbers helped me develop a solid understanding of full-stack web development using the .NET ecosystem. Key takeaways include:

### Full-Stack Architecture

* Designing and structuring a **Client / Server / Shared** architecture
* Separating concerns between UI, API, and data layers
* Using DTOs to safely transfer data between frontend and backend

---

### Blazor WebAssembly

* Building interactive UI with components and data binding
* Managing state and lifecycle (`OnInitializedAsync`, `OnParametersSetAsync`)
* Handling forms, validation, and user input
* Using **JavaScript interop** for features like scrolling and local storage

---

### API Design (ASP.NET Core)

* Creating RESTful endpoints with proper HTTP methods (`GET`, `POST`, `PUT`, `DELETE`)
* Understanding the difference between `IActionResult` and `ActionResult<T>`
* Handling errors and status codes correctly (400, 404, 500, etc.)
* Avoiding common pitfalls like returning un-awaited tasks

---

### Entity Framework Core

* Querying efficiently with LINQ
* Projecting entities into DTOs
* Implementing filtering and pagination at the database level
* Avoiding loading unnecessary data into memory

---

### File Upload & Storage

* Handling file uploads using `InputFile`
* Sending multipart/form-data requests
* Saving and deleting files from `wwwroot`
* Preventing orphaned files when deleting entities

---

### Localization

* Implementing localization using `IStringLocalizer`
* Structuring `.resx` files correctly per culture
* Managing culture switching and persistence
* Understanding limitations (e.g., Identity pages and seeded data not localized)

---

### Problem Solving & Debugging

* Debugging HTTP errors like **400, 405, 415, and 500**
* Resolving routing conflicts and ambiguous endpoints
* Fixing serialization issues caused by async mistakes
* Identifying frontend vs backend issues using browser dev tools

---

### UI/UX Improvements

* Building a guided booking flow with progressive steps
* Implementing smooth scrolling between sections
* Improving usability with confirmation dialogs and loading states
* Handling edge cases (e.g., missing selections, date-time mismatches, invalid inputs)

---

### Deployment Considerations

* Understanding trade-offs between SQLite and managed databases
* Preparing an app for deployment to Azure
* Managing configuration and environment differences

---

Overall, this project significantly strengthened my ability to build and debug real-world web applications, and improved my confidence working across the full stack.


## Author

Developed as a full-stack learning project using modern .NET technologies.

---

## License

This project is for educational and portfolio purposes.
